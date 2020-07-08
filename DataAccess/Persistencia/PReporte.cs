using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class PReporte
    {

        
        public List<DtoReporteMasVendido> Reporte1()
        {
            List<DtoReporteMasVendido> coldto = null;
            using (AliyavaEntities context = new AliyavaEntities())
            {

                coldto = (from detped in context.DetallePedido
                          group detped by detped.idProducto into detgrp
                          select new DtoReporteMasVendido
                          {
                              idProducto = detgrp.Key,
                              cantidad = detgrp.Sum(s => s.CantidadPreparar)
                          }).OrderByDescending(o => o.cantidad).ToList();

            }
            return coldto;
        }


        //devolver 
        //Revisalo porque daban error los dos campos.
        public List<DtoReporteVolumenPedidodia> Reporte3(DateTime dia)
        {
            List<DtoReporteVolumenPedidodia> coldto = null;
            using (AliyavaEntities context = new AliyavaEntities())
            {

                coldto = (from detped in context.DetallePedido
                          group detped by detped.idProducto into detgrp
                          select new DtoReporteVolumenPedidodia
                          {
                              Volumen = detgrp.Key,
                              cantPedidos = (float)detgrp.Sum(s => s.CantidadPreparar)
                          }).OrderByDescending(o => o.cantPedidos).ToList();

            }
            return coldto;
        }
      

    }
}
