using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoDetallePedido
    {
        public double CantidadPreparar { get; set; }
        public int idDetallePedido { get; set; }

        public double PrecioU { get; set; }
        public string UbicacionPro { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
    }
}
