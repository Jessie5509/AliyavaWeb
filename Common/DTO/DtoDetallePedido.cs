using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoDetallePedido
    {
        [DisplayName("Cantidad a preparar")]
        public double CantidadPreparar { get; set; }

        [DisplayName("Código detalle")]
        public int idDetallePedido { get; set; }

        [DisplayName("Precio unitario")]
        public double PrecioU { get; set; }

        [DisplayName("Ubicación producto")]
        public string UbicacionPro { get; set; }

        [DisplayName("Código pedido")]
        public int idPedido { get; set; }
        [DisplayName("Código producto")]
        public int idProducto { get; set; }
    }
}
