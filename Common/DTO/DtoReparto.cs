using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoReparto
    {
        public int idReparto { get; set; }
        public string MatriculaVehiculo { get; set; }
        public string Estado { get; set; }
        public string Chofer { get; set; }
        public System.DateTime FechaSalida { get; set; }
    }
}
