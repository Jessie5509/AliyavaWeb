//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        public int idStock { get; set; }
        public string Ubicacion { get; set; }
        public string Motivo { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public int idProducto { get; set; }
        public string nombreUsuEmpleado { get; set; }
    
        public virtual Producto Producto { get; set; }
    }
}
