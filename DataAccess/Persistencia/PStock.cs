using Common.DTO;
using DataAccess.Mappers;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Persistencia
{
    public class PStock
    {
        //public void AltaStock(DtoStock dto)
        //{
        //    using (AliyavaEntities context = new AliyavaEntities())
        //    {
        //        using (TransactionScope scope = new TransactionScope())
        //        {
        //            try
        //            {
        //                Stock nuevoStock = new Stock();
        //                nuevoStock.idProducto = dto.idProducto;
        //                nuevoStock.Ubicacion = dto.Ubicacion;
        //                nuevoStock.Motivo = dto.Motivo;
        //                nuevoStock.Cantidad = dto.Cantidad;

        //                context.Stock.Add(nuevoStock);
        //                context.SaveChanges();

        //                scope.Complete();

        //            }
        //            catch (Exception ex)
        //            {
        //                scope.Dispose();

        //            }
                    
        //        }

        //    }
        //}

        public void SumarStock(DtoStock dto, string codigoBarras)
        {
            double cantidadAlta = (double)dto.Cantidad;
            double cantResto = 0;
            Stock stock = new Stock();
            //Validación: Depende que motivo lo que se hace con la cantidad.

            using (AliyavaEntities context = new AliyavaEntities())
            {

                    bool existeStock = context.Stock.Any(a => a.idProducto == dto.idProducto);
                    bool existeProducto = context.Stock.Include("Producto").Any(a => a.Producto.codigo_barras == codigoBarras);

                    if (existeStock)
                    {
                        stock = context.Stock.FirstOrDefault(f => f.idProducto == dto.idProducto);
                    }
                    else
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            try
                            {
                                Stock nuevoStock = new Stock();
                                nuevoStock.idProducto = dto.idProducto;
                                nuevoStock.Ubicacion = dto.Ubicacion;
                                nuevoStock.Motivo = dto.Motivo;
                                nuevoStock.Cantidad = dto.Cantidad;

                                context.Stock.Add(nuevoStock);
                                context.SaveChanges();

                                scope.Complete();
                            }
                            catch(Exception ex)
                            {
                                scope.Dispose();
                            }
                        }
                    }

                    stock = MStock.MapToEntity(dto);
                    cantResto = (double)(cantidadAlta + stock.Cantidad);
                    stock.Cantidad = cantResto;

                    context.SaveChanges();

                
            }
        }

        public void DeleteStock(DtoStock dto, string codigoBarras)
        {
            double cantidadBaja = (double)dto.Cantidad;
            double cantResto = 0;

            using (AliyavaEntities context = new AliyavaEntities())
            { 
                Stock stock = context.Stock.FirstOrDefault(f => f.idStock == dto.idStock && f.idProducto == dto.idProducto);

                stock = MStock.MapToEntity(dto);

                cantResto = (double)(cantidadBaja - stock.Cantidad);
                stock.Cantidad = cantResto;

                if (stock.Cantidad == 0)
                {
                    context.Stock.Remove(stock);
                    context.SaveChanges();
                }
                else
                {
                    context.SaveChanges();
                }

            }


        }
    }
}
