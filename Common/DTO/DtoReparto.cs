using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoReparto
    {
        public int idReparto { get; set; }

        [DisplayName("Matrícula del vehículo")]
        [Required(ErrorMessage = "La {0} es requerida!")]
        public string MatriculaVehiculo { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "El {0} del reparto es requerido!")]
        public string Estado { get; set; }

        [DisplayName("Chofer")]
        [Required(ErrorMessage = "El {0} es requerido!")]
        public string Chofer { get; set; }

        [DisplayName("Fecha de salida")]
        [Required(ErrorMessage = "La {0} es requerida!")]
        public System.DateTime FechaSalida { get; set; }
    }
}
