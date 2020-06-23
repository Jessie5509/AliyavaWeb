using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoProducto
    {
        [DisplayName("Codigo Producto")]
        [Required(ErrorMessage = "El {0} del producto es requerido!")]
        //[StringLength(20, ErrorMessage = "El {0} del producto no debe superar los {1} caracteres")]
        public int Codigo { get; set; }

        [DisplayName("Descripcion Producto")]
        [Required(ErrorMessage = "La {0} del producto es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del producto no debe superar los {1} caracteres")]
        public string Descripcion { get; set; }

        [DisplayName("Familia Producto")]
        [Required(ErrorMessage = "La {0} del producto es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del producto no debe superar los {1} caracteres")]
        public string Familia { get; set; }

        [DisplayName("Precio venta Producto")]
        [Required(ErrorMessage = "El {0} del producto es requerido!")]
        public Nullable<double> PrecioVenta { get; set; }

    }
}
