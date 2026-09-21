using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ConsultaBL
    {

        public ConsultaBL() { }
        private EvaluacionEnfermeriaBL evaluacionEnfermeriaBL = new EvaluacionEnfermeriaBL();

        public List<Consulta> ObtenerConsultasActivas()
        {
            return ConsultaDAL.ListarConsultasActivas();
        }

        public Consulta ObtenerPorDNI(int id)
        {
            return ConsultaDAL.ObtenerPorId(id);
        }

        public int AgregarConsulta(Consulta consulta)
        {
            return ConsultaDAL.Insertar(consulta);
        }

        

        public void AvanzarSiguienteEstado(Consulta consulta)
        {
            EstadoConsulta nuevoEstado;

            switch (consulta.EstadoConsulta)
            {
                case EstadoConsulta.EnEsperaEnfermeria: // 1
                    nuevoEstado = EstadoConsulta.EnEnfermeria; // 2
                    break;

                case EstadoConsulta.EnEnfermeria: // 2
                    nuevoEstado = EstadoConsulta.EnEsperaAtencionMedica; // 3
                    break;

                case EstadoConsulta.EnEsperaAtencionMedica: // 3
                    nuevoEstado = EstadoConsulta.EnAtencionMedica; // 4
                    break;

                case EstadoConsulta.EnAtencionMedica: // 4
                    nuevoEstado = EstadoConsulta.Finalizado; // 6 
                    break;

                default:
                    throw new InvalidOperationException($"La consulta en estado '{consulta.EstadoConsulta}' no puede avanzar de forma secuencial.");
            }

            ConsultaDAL.CambiarEstado(consulta.Id, nuevoEstado);
        }

        public List<Consulta> ObtenerConsultasParaMedcicosConPrioridad()
        {
            var listaConsultas = ConsultaDAL.ListarConsultasParaAtencionMedica();

            foreach (var consulta in listaConsultas)
            {
                var evaluacion = evaluacionEnfermeriaBL.ObtenerPorConsultaId(consulta.Id);

                if (evaluacion != null)
                {
                    consulta.EvaluacionEnfermeria = evaluacion;
                }
            }

            return listaConsultas;

        }

        public List<Consulta> ObtenerConsultasConPrioridad()
        {
            var listaConsultas = ConsultaDAL.ListarConsultasActivas();

            foreach (var consulta in listaConsultas)
            {
                var evaluacion = evaluacionEnfermeriaBL.ObtenerPorConsultaId(consulta.Id);

                if (evaluacion != null)
                {
                    consulta.EvaluacionEnfermeria = evaluacion;
                }
            }

            return listaConsultas;

        }
    }
}
