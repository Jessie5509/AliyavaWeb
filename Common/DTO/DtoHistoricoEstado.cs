using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoHistoricoEstado
    {
        public int idHistorico { get; set; }
        public string Accion { get; set; }
        public string Funcionario { get; set; }
        public string Estados { get; set; }
        public System.DateTime FechaCambio { get; set; }
        public int numPedido { get; set; }


    }
}
