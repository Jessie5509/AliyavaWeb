using Common.DTO;
using DataAccess.Mappers;
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
        public void AgregarStock(DtoStock dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Stock nuevoStock = new Stock();
                nuevoStock.Ubicacion = dto.Ubicacion;
                nuevoStock.Motivo = dto.Motivo;
                nuevoStock.Cantidad = dto.Cantidad;
           
                context.Stock.Add(nuevoStock);
                context.SaveChanges();

            }
        }

        public void DeleteStock(DtoStock dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {

                Stock stock = MStock.MapToEntity(dto);

                context.Stock.Remove(stock);
                context.SaveChanges();

            }


        }
    }
}
