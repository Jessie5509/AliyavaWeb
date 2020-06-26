using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoHistoricoStock
    {
        public int idHistorico { get; set; }
        public string Ubicacion { get; set; }
        public string Motivo { get; set; }
        public double Cantidad { get; set; }
        public int idEmpleado { get; set; }
    }
}
