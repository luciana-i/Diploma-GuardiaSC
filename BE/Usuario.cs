using System.Collections.Generic;

namespace BE
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        public Idioma IdiomaDefault { get; set; }
        public int DVH { get; set; } 

        private readonly List<Perfil> listaPerfiles = new List<Perfil>();

        public Usuario() { }
        // nuevo usuario
        public Usuario( string username, string password, string mail) 
        {
            Username = username;
            Password = password;
            Mail = mail;
            IntentosFallidos = 0;
            Bloqueado = false;
        }

        public bool TienePermiso(string patenteNombre)
        {
            foreach (Perfil perfil in listaPerfiles)
            {
                if (perfil != null && perfil.Contiene(patenteNombre))
                {
                    return true;
                }
            }
            return false;
        }

        public void AgregarPermiso(Perfil perfil)
        {
            if (perfil != null && !listaPerfiles.Contains(perfil))
            {
                listaPerfiles.Add(perfil);
            }
        }
        public IReadOnlyList<Perfil> listaReadonlyPerfiles => listaPerfiles;


    }
}