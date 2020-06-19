using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoCliente
    {
        public int idCliente { get; set; }

        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [DisplayName("Teléfono")]
        [StringLength(20, ErrorMessage = "El {0} del cliente no debe superar los {1} caracteres")]
        public string Telefono { get; set; }
       
        [DisplayName("NombreUsuario")]
        [Required(ErrorMessage = "El {0} del cliente es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del cliente no debe superar los {1} caracteres")]
        public string NombreUsuario { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El {0} del cliente es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del cliente no debe superar los {1} caracteres")]
        public string Nombre { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "El {0} del cliente es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del cliente no debe superar los {1} caracteres")]
        public string Apellido { get; set; }

        [DisplayName("email")]
        [Required(ErrorMessage = "El {0} del cliente es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del cliente no debe superar los {1} caracteres")]
        public string email { get; set; }

        public string contraseña { get; set; }




    }
}
