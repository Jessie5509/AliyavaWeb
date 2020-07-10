using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoDirecciones
    {
        [DisplayName("Ciudad")]
        [Required(ErrorMessage = "La {0} es requerida!")]
        public string Ciudad { get; set; }

        [DisplayName("Barrio")]
        [Required(ErrorMessage = "El {0} es requerido!")]
        public string Barrio { get; set; }

        [DisplayName("Número")]
        [Required(ErrorMessage = "El {0} es requerido!")]
        public double Numero { get; set; }

        [DisplayName("Nro° apartamento")]
        [Required(ErrorMessage = "El {0} es requerido!")]
        public int Apartamento { get; set; }

        [DisplayName("Edificio")]
        [Required(ErrorMessage = "El {0} es requerido!")]
        public string Edificio { get; set; }
        public int idCliente { get; set; }

        [DisplayName("Nombre de la dirección")]
        [Required(ErrorMessage = "El {0} es requerida!")]
        public string nombreDir { get; set; }
    }
}
