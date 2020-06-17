using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoStock
    {
       
        public int idStock { get; set; }

        [DisplayName("Ubicacion")]
        [Required(ErrorMessage = "La {0} del stock es requerido!")]
        public string Ubicacion { get; set; }

        [DisplayName("Motivo")]
        [Required(ErrorMessage = "El {0} del cambio en stock es requerido!")]
        public string Motivo { get; set; }

        [DisplayName("Cantidad")]
        public Nullable<double> Cantidad { get; set; }

    }
}
