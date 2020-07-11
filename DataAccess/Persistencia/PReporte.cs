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

        public double Reporte2(DateTime fecha1, DateTime fecha2)
        {
            
            List<Pedido> colrep = null;
            double average = 0;
            double aux = 0;

            List<double> min = new List<double>();
            using (AliyavaEntities context = new AliyavaEntities())
            {
                
                colrep = context.Pedido.Where(w => w.Estado == "Entregado" &&  (w.FechaIngreso >= fecha1 ||  w.FechaIngreso >= fecha2 && w.Reparto.FechaSalida >= fecha1 || w.Reparto.FechaSalida >= fecha2)).ToList();
                foreach (Pedido item in colrep)
                {
                    
                    aux = (item.FechaIngreso - item.Reparto.FechaSalida).TotalMinutes;                    
                    min.Add(aux);
                    aux = 0;
                }

                
                
                average = min.Average() /colrep.Count();


            }
            return average;
        }


        public List<DtoReporteVolumenPedidodia> Reporte3()
        {
            DateTime dia = DateTime.Now;
            List<DtoReporteVolumenPedidodia> coldto = null;
            using (AliyavaEntities context = new AliyavaEntities())
            {

                coldto = (from detped in context.DetallePedido
                          where detped.Pedido.FechaIngreso.Day == dia.Day && detped.Pedido.FechaIngreso.Month == dia.Month && detped.Pedido.FechaIngreso.Year == dia.Year
                          group detped by detped.Pedido.FechaIngreso into detgrp
                          select new DtoReporteVolumenPedidodia
                          {
                              Volumen = detgrp.Sum(s => s.CantidadPreparar),
                              cantPedidos = detgrp.Select(s => s.idPedido).Distinct().Count()
                          }).OrderByDescending(o => o.Volumen).ToList();

            }
            return coldto;
        }
      

    }
}
