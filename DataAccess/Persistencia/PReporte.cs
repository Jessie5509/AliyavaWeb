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
            using (AliyavaEntities context = new AliyavaEntities())
            {

                colrep = context.Pedido.Where(w => w.Estado == "Entregado").ToList();
                
                foreach (Pedido item in colrep)
                {

                    if ((item.FechaIngreso.Day >= fecha1.Day && item.FechaIngreso.Month >= fecha1.Month && item.FechaIngreso.Year >= fecha1.Year) && (item.Reparto.FechaSalida.Day <= fecha2.Day && item.Reparto.FechaSalida.Month <= fecha2.Month && item.Reparto.FechaSalida.Year <= fecha2.Year))
                    {

                         average = context.Pedido.Average(a=> a.Numero);

                    }

                }

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

        public List<decimal> getLatEntregado()
        {
            List<decimal> colLat = new List<decimal>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Pedido> colP = context.Pedido.Include("Cliente").Where(w => w.Estado == "Entregado").ToList();
                List<Cliente> colc = context.Pedido.Include("Cliente").Select(s => s.Cliente).ToList();
                //List<Cliente> colcli = context.Cliente.Include("Pedido").Select(s => s).ToList();

                foreach (Cliente item in colc)
                {
                    foreach (Pedido ped in item.Pedido)
                    {
                        if (item.idCliente == ped.Cliente.idCliente)
                        {
                            decimal lat = (decimal)item.latitud;

                            colLat.Add(lat);

                        }
                    }
                   
                }

            }

            return colLat;
        }

        public List<decimal> getLngEntregado()
        {
            List<decimal> colLng = new List<decimal>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Pedido> colP = context.Pedido.Include("Cliente").Where(w => w.Estado == "Entregado").ToList();
                List<Cliente> colc = context.Pedido.Include("Cliente").Select(s => s.Cliente).ToList();
                //List<Cliente> colcli = context.Cliente.Include("Pedido").Select(s => s).ToList();

                foreach (Cliente item in colc)
                {
                    foreach (Pedido ped in item.Pedido)
                    {
                        if (item.idCliente == ped.Cliente.idCliente)
                        {
                            decimal lng = (decimal)item.longitud;

                            colLng.Add(lng);

                        }
                    }

                }

            }

            return colLng;
        }
    }
}
