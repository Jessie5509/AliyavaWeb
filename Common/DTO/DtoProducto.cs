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
        [DisplayName("Código Producto")]
        [Required(ErrorMessage = "El {0} del producto es requerido!")]
       
        public int Codigo { get; set; }

        [DisplayName("Código de barras")]
        [Required(ErrorMessage = "El {0} es requerido!")]
        public string codigoBarras { get; set; }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "La {0} del producto es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del producto no debe superar los {1} caracteres")]
        public string Descripcion { get; set; }

        [DisplayName("Familia")]
        [Required(ErrorMessage = "La {0} del producto es requerido!")]
        [StringLength(20, ErrorMessage = "El {0} del producto no debe superar los {1} caracteres")]
        public string Familia { get; set; }

        [DisplayName("Precio venta")]
        [Required(ErrorMessage = "El {0} del producto es requerido!")]
        public Nullable<double> PrecioVenta { get; set; }

        [DisplayName("Descripción del producto ")]
        public string ProDescripcion { get; set; }

        public Nullable<int> CantidadPreparar { get; set; }


    }
}
