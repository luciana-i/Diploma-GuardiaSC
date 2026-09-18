using DAL;
using Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servicios
{
    public class IdiomaService
    {

        private static List<IIdiomaObserver> _observadores = new List<IIdiomaObserver>();

        // El diccionario en memoria con las traducciones del idioma actual
        public static Dictionary<string, string> TraduccionesActuales { get; private set; }

        public static void Suscribir(IIdiomaObserver observador) 
        {
            _observadores.Add(observador);
            if (TraduccionesActuales != null)
            {
                observador.UpdateIdioma(TraduccionesActuales);
            }
        }

        public static void Desuscribir(IIdiomaObserver observador)
        {
            _observadores.Remove(observador);
        }

        public static void CambiarIdioma(int idiomaId) 
        {
            SessionManager.getInstance().IdiomaActual = idiomaId;

            TraduccionesActuales = IdiomaDAL.ObtenerTraducciones(idiomaId);

            foreach (var obs in _observadores)
            {
                obs.UpdateIdioma(TraduccionesActuales);
            }
        }
    }
}
