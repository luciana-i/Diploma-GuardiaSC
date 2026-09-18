using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Familia : Perfil
    {
        public override void AgregarHijo(Perfil p)
        {
            listaPerfiles.Add(p);
        }

        public override void QuitarHijo(Perfil p)
        {
            listaPerfiles.Remove(p);
        }
        public override bool Contiene(string patenteTag)
        {
            if (base.Contiene(patenteTag)) return true; 

            
            foreach (var hijo in listaPerfiles)
            {
                if (hijo.Contiene(patenteTag)) return true; 
            }

            return false;
        }
    }
}
