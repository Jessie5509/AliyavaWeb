﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO
{
    public class DtoPedido
    {
        public string Estado { get; set; }
        public double PrecioTotal { get; set; }
        public int Numero { get; set; }
        public string Usuario { get; set; }
        public string Direccion { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public int idDetallePe { get; set; }
        public int idReserva { get; set; }
        public int idReparto { get; set; }
    }
}