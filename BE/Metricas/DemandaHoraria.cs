using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Metricas
{
    [Serializable]
    public class DemandaHoraria
    {
        public int Hora { get; set; }                    
        public int CantidadRayosReal { get; set; }       
        public int CantidadLabReal { get; set; }         
        public double CantidadProyectada { get; set; }   
    }
}