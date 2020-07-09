﻿using Common.DTO;
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
            
            List<Reparto> colrep = null;
            double average = 0;
            using (AliyavaEntities context = new AliyavaEntities())
            {

                colrep = context.Reparto.Where(w => w.Estado == "Entregado").ToList();
                
                foreach (Reparto item in colrep)
                {

                    if ((item.FechaSalida >= fecha1) && (item.FechaSalida <= fecha2))
                    {

                         average = context.Reparto.Average(a=> a.idReparto);

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
      

    }
}
