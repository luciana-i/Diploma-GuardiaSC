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

        public List<AtencionMedica> Atenciones { get; set; }

        public HistoriaClinica()
        {
            FechaAtencion = DateTime.Now;
        }

        public HistoriaClinica(Paciente paciente, string antecedente, string alergias, string observacion)
        {
            FechaAtencion = DateTime.Now;
            Paciente = paciente;
            Antecedente = antecedente;
            Alergias = alergias;
            Observacion = observacion;
        }

        public override string ToString() =>
            $"{FechaAtencion:dd/MM/yyyy} - {Antecedente}";
    }
}
