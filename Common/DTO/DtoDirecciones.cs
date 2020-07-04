using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoDirecciones
    {
        public string Ciudad { get; set; }
        public string Barrio { get; set; }
        public double Numero { get; set; }
        public int Apartamento { get; set; }
        public string Edificio { get; set; }
        public int idCliente { get; set; }
        [DisplayName("Nombre dirección")]
        public string nombreDir { get; set; }
    }
}
