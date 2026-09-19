using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class HistoriaClinica
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime FechaAtencion { get; set; }
        public string Antecedente { get; set; }
        public string Alergias { get; set; }
        public string Observacion { get; set; }
        public int? DVH { get; set; }

        public List<AtencionMedica> Atenciones { get; set; }

        public HistoriaClinica()
        {
            FechaAtencion = DateTime.Now;
        }

        public override string ToString() =>
            $"{FechaAtencion:dd/MM/yyyy} - {Antecedente}";
    }
}
