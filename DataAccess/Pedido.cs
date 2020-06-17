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
    
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.Cliente = new HashSet<Cliente>();
        }
    
        public string Estado { get; set; }
        public double PrecioTotal { get; set; }
        public int Numero { get; set; }
        public string Usuario { get; set; }
        public string Direccion { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public int idDetallePe { get; set; }
        public int idReserva { get; set; }
        public int idReparto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual DetallePedido DetallePedido { get; set; }
        public virtual Reparto Reparto { get; set; }
        public virtual Reserva Reserva { get; set; }
    }
}
