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

        
        public List<DtoReporte1> Reporte1()
        {
            List<DtoReporte1> coldto = null;
            using (AliyavaEntities context = new AliyavaEntities())
            {

                coldto = (from detped in context.DetallePedido
                          group detped by detped.idProducto into detgrp
                          select new DtoReporte1
                          {
                              idProducto = detgrp.Key,
                              cantidad = detgrp.Sum(s => s.Cantidad)
                          }).OrderByDescending(o => o.cantidad).ToList();

            }
            return coldto;
        }

/*
        //devolver 
        public void Reporte3()
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {



            }

        }
      */

    }
}
