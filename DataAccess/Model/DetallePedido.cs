//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetallePedido
    {
        public double CantidadPreparar { get; set; }
        public int idDetallePedido { get; set; }
        public double Cantidad { get; set; }
        public double PrecioU { get; set; }
        public string UbicacionPro { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
    
        public virtual Pedido Pedido { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
