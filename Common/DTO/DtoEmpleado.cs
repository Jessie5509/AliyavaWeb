using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoEmpleado
    {
        public int idEmpleado { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "El {0} del empleado es requerido!")]
        [StringLength(75, ErrorMessage = "El {0} del empleado no debe superar los {1} caracteres")]
        public string email { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La {0} del empleado es requerida!")]
        public string contraseña { get; set; }

        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El {0} del empleado es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del empleado no debe superar los {1} caracteres")]
        public string NombreUsuario { get; set; }
    }
}
