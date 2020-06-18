using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class PStock
    {
        public void AddStock(DtoStock dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Stock nuevoStock = new Stock();
                nuevoStock.Ubicacion = dto.Ubicacion;
                nuevoStock.Cantidad = dto.Cantidad;
                nuevoStock.Motivo = dto.Motivo;
      
                context.Stock.Add(nuevoStock);
                context.SaveChanges();

            }
        }


    }
}
