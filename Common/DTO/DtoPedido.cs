using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoPedido
    {
        [DisplayName("Estado")]
        public string Estado { get; set; }

        [DisplayName("Precio total")]
        public double PrecioTotal { get; set; }

        [DisplayName("Número")]
        public int Numero { get; set; }

        [DisplayName("Usuario")]
        public string Usuario { get; set; }

        [DisplayName("Dirección")]
        public string Direccion { get; set; }

        [DisplayName("Fecha ingreso")]
        public System.DateTime FechaIngreso { get; set; }

        [DisplayName("Urgente")]
        public string Urgente { get; set; }

        [DisplayName("Código cliente")]
        public int idCliente { get; set; }

        [DisplayName("Código reserva")]
        public int idReserva { get; set; }

        [DisplayName("Código reparto")]
        public Nullable<int> idReparto { get; set; }
    }
}
