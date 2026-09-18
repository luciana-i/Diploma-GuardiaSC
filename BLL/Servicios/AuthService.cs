using BE;
using Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public enum LoginResult
    {
        Exito,
        UsuarioNoEncontrado,
        UsuarioBloqueado,
        CredencialesInvalidas,
        BloqueadoPorIntentos,
        IntegridadViolada
    }
    public class AuthService
    {
        private readonly UsuarioBL _usuarioBL = new UsuarioBL();
        private readonly BitacoraBL _bitacoraBL = new BitacoraBL();
        private readonly IdiomaBL idiomaBL = new IdiomaBL();
        private readonly CryptoManager _crypto = new CryptoManager();
        private readonly AdministrarPermisosService _admPermisosService = new AdministrarPermisosService();
        private readonly DVVBL _dVVBL = new DVVBL();

        public AuthService() { }
        public LoginResult Login(string username, string passwordIngresada, int idIdioma, bool checkDefault)
        {
            if (SessionManager.getInstance().HaySessionIniciada())
            {
                throw new System.Exception($"Ya existe una sesión activa en el sistema.");
            }


            Usuario usuario = _usuarioBL.ObtenerPorNombre(username);

            if (usuario == null)
            {
                return LoginResult.UsuarioNoEncontrado;
            }


            if (usuario.Bloqueado)
            {
                _bitacoraBL.IngresarBitacora(usuario.Id, usuario.Username, "Bloqueado", "No puede ingresar", string.Empty, SeveridadLog.Warn);
                return LoginResult.UsuarioBloqueado;
            }

            
            if (coincidePassw(passwordIngresada, _crypto, usuario.Password))
            {
                usuario = _usuarioBL.ObtenerPermisos(usuario);
                bool hayInconsistencias = _dVVBL.EvaluarInconsistencia();

                if (hayInconsistencias && !EsAdmin(usuario.listaReadonlyPerfiles))
                {
                    return LoginResult.IntegridadViolada;
                }   

              
                if ((checkDefault && idIdioma!=0) && usuario.IdiomaDefault?.Id !=idIdioma) 
                {
                    usuario.IdiomaDefault = idiomaBL.Obtener().FirstOrDefault(x => x.Id ==idIdioma);
                    _usuarioBL.ActualizarUsuario(usuario);
                }

                if(usuario.IdiomaDefault != null) // si tiene seteado el idioma por default, debo cambiar para notificar a los formularios
                {
                    IdiomaService.CambiarIdioma(usuario.IdiomaDefault.Id);
                }
                SessionManager.getInstance().CrearSession(usuario);
                
                if (hayInconsistencias) 
                {
                    SessionManager.getInstance().IntegridadBaseDatos = true;
                }

                _bitacoraBL.IngresarBitacora(usuario.Id, usuario.Username, "Ingreso Exitoso", "Se blanquea intentos fallidos", string.Empty, SeveridadLog.Info);

                if (usuario.IntentosFallidos != 0)
                {
                    usuario.IntentosFallidos = 0;
                    _usuarioBL.ActualizarUsuario(usuario);
                }

                return LoginResult.Exito;
            }
            else
            {
                usuario.IntentosFallidos++;

                if (usuario.IntentosFallidos >= 3)
                {
                    usuario.Bloqueado = true;
                    _bitacoraBL.IngresarBitacora(usuario.Id, usuario.Username, "Bloqueado", "Alcanzo 3 intentos", string.Empty, SeveridadLog.Warn);
                    _usuarioBL.ActualizarUsuario(usuario);
                    return LoginResult.UsuarioBloqueado;
                }

                _bitacoraBL.IngresarBitacora(usuario.Id, usuario.Username, "Credenciales Erroneas", "Se actualiza intento fallido", string.Empty,SeveridadLog.Warn);
                _usuarioBL.ActualizarUsuario(usuario);
                return LoginResult.CredencialesInvalidas;
            }
        }

        private bool EsAdmin(IReadOnlyList<Perfil> listaReadonlyPerfiles)
        {
            if (listaReadonlyPerfiles == null) { return false; }
           
            return listaReadonlyPerfiles.Any(x => x.Tag != null && x.Tag.Equals("ADMIN_FULL"));
        }

        private bool coincidePassw(string passwordIngresada, CryptoManager _crypto, string password)
        {
            string hashIngresado = _crypto.GenerarHashMD5(passwordIngresada);
            return string.Equals(password, hashIngresado, StringComparison.OrdinalIgnoreCase);
        }

        public void Logout()
        {
           
            if (SessionManager.getInstance().ObtenerUsuario() != null)
            {
                _bitacoraBL.IngresarBitacora(SessionManager.getInstance().ObtenerUsuario().Id, SessionManager.getInstance().ObtenerUsuario().Username, "Se cierra sesion", string.Empty, string.Empty, SeveridadLog.Info);
                _dVVBL.RestaurarIntegridad();
                SessionManager.getInstance().CerrarSesion();
            }
            else
            {
                throw new Exception("Sesión no iniciada");
            }

        }
    }
}
