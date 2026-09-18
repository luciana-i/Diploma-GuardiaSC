using BE;
using BLL.Servicios;
using DAL;
using Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BLL
{
    public class UsuarioBL
    {

        public UsuarioBL() { }


        public Usuario ObtenerPorNombre(string username)
        {
            return UsuarioDAL.ObtenerPorNombre(username);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            usuario.DVH = CalcularDVH(usuario);
            UsuarioDAL.ActualizarPorId(usuario);
        }

        public void ActualizarContraseña(string passVieja, string passNueva)
        {
           
            // hasheo para ver si concide
            CryptoManager crypto = new CryptoManager();
            string passViejaHashed = crypto.GenerarHashMD5(passVieja); 
            
            Usuario usuario = ObtenerPorNombre(SessionManager.getInstance().ObtenerUsuario().Username);
     
            // coincide -- hasheo la nueva
            if (string.Equals(usuario.Password, passViejaHashed, StringComparison.OrdinalIgnoreCase))
            {
                usuario.Password = crypto.GenerarHashMD5(passVieja); // igual!
                ActualizarUsuario(usuario);
                BitacoraBL bitacora = new BitacoraBL();
                bitacora.IngresarBitacora(usuario.Id, usuario.Username, "ActualizarContraseña", "Contraseña actualizada", "", SeveridadLog.Info);
            }else
            {// no coincide le digo que vuelva a intentar
                throw new Exception("La contraseña existente no coincide, por favor vuelva a ingresarla");
            }
            
        }

        public int CrearUsuario(string username, string password, string mail)
        {
            
            Usuario usuario = ObtenerPorNombre(username);
            if (usuario == null)// no puede haber dos usuarios iguales
            {
                // hashear contraseña
                CryptoManager  crypto = new CryptoManager();
                string hashedPassw =crypto.GenerarHashMD5(password); 
                
                // creo objeto con 0 intentos y false no bloqueado
                usuario = new Usuario(username, hashedPassw, mail);

                usuario.DVH= CalcularDVH(usuario);
                // guardo en base
                int ultimoID = UsuarioDAL.InsertarUsuario(usuario);

                //creo una entrada en Historial con el mail que acaba de ingresar // ahora cuando hay un nuevo usuario tiene que actualizar el historial de cambios
                HistorialBL historialBL = new HistorialBL(); 
                historialBL.Insertar(usuario.Mail, ultimoID);
                
                // bitacora
                BitacoraBL bitacora = new BitacoraBL();
                bitacora.IngresarBitacora(ultimoID, username, "Nuevo Usuario", "usuario creado con exito", "", SeveridadLog.Info);
                return ultimoID;
            }
            else
            {
                throw new Exception("Ya existe un usuario con ese nombre, por favor intente con otro nombre");
            }

        }

        public  List<Usuario> ObtenerUsuarios()
        {
            return UsuarioDAL.Listar();
        }
        // este metodo busca los permisos de un usuario (lista) para despues agregarlo en la lista de permisos del usuario
        public Usuario ObtenerPermisos(Usuario usuario)
        {
            AdministrarPermisosService admPermServices = new AdministrarPermisosService();

            foreach (var item in admPermServices.ObtenerArbolUsuario(usuario.Id))
            {
                usuario.AgregarPermiso(item);
            }
           return usuario;
        }
        public int CalcularDVH(Usuario usuario) 
        {
            string usuarioFila =
              usuario.Id.ToString()
            + (usuario.Username ?? "")
            + (usuario.Password ?? "")
            + (usuario.Mail ?? "")
            + usuario.IntentosFallidos.ToString()
            + usuario.Bloqueado.ToString() 
            + (usuario.IdiomaDefault?.Id.ToString() ?? "0");

            int dvh = 0;

            for (int i = 0; i < usuarioFila.Length; i++)
            {
                // se multiplica el valor ASCII del carácter por su posición (i + 1)
                dvh += (int)usuarioFila[i] * (i + 1);
            }

            return dvh;

        }

        public void CambiarMailHistorialCambios(int id, string mail) 
        {
            Usuario usuario = ObtenerPorId(id);
            usuario.Mail = mail;

            ActualizarUsuario(usuario);

            BitacoraBL bitacora = new BitacoraBL();
            bitacora.IngresarBitacora(usuario.Id, usuario.Username, "Se modifico el mail", "operacion exitosa", "", SeveridadLog.Info);
        }

        private Usuario ObtenerPorId(int id) 
        {
            return UsuarioDAL.ObtenerPorId(id);
        }

        public long CalcularDVV() // dvv
        {
            return UsuarioDAL.CalcularDVVUsuario();
        }
        
        public long UpdateDVH(int id, long dvh) // dvh
        {
            return UsuarioDAL.UpdateDvH(id, dvh);
        }
       
       

 

    }
}
