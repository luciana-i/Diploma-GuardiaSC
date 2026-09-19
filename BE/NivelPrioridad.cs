using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum NivelPrioridad
    {
        Emergencia = 1,       // Nivel 1 - Rojo (Resucitación / Inmediato)
        MuyUrgente = 2,       // Nivel 2 - Naranja (Emergencia)
        Urgente = 3,          // Nivel 3 - Amarillo (Urgente)
        PocoUrgente = 4,      // Nivel 4 - Verde (Poco Urgente)
        NoUrgente = 5         // Nivel 5 - Azul (No Urgente)
    }
}
