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

        public void SumarStock(DtoStock dto, string NombreUsu)
        {
            double cantidadAlta = (double)dto.Cantidad;
            double cantResto = 0;
            Stock stock = new Stock();
            
            //Validación: Depende que motivo lo que se hace con la cantidad.

            using (AliyavaEntities context = new AliyavaEntities())
            {

                bool existeProducto = context.Stock.Include("Producto").Any(a => a.Producto.codigo_barras == dto.codigoBarras);


                    if (existeProducto)
                    {
                        stock = context.Stock.FirstOrDefault(f => f.Producto.codigo_barras == dto.codigoBarras);

                        //stock = MStock.MapToEntity(dto);
                        cantResto = (double)(cantidadAlta + stock.Cantidad);
                        stock.Cantidad = cantResto;

                        context.SaveChanges();
                    }
                    else
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {

                            Producto pro = context.Producto.FirstOrDefault(f => f.codigo_barras == dto.codigoBarras);
                            
                            try
                            {
                                Stock nuevoStock = new Stock();
                                nuevoStock.Producto = pro;
                                nuevoStock.Ubicacion = dto.Ubicacion;
                                nuevoStock.Motivo = dto.Motivo;
                                nuevoStock.Cantidad = dto.Cantidad;
                                nuevoStock.nombreUsuEmpleado = NombreUsu;

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

                    

                
            }
        }

        public void DeleteStock(DtoStock dto)
        {
            double cantidadBaja = (double)dto.Cantidad;
            double cantResto = 0;
            Stock stock = new Stock();

            using (AliyavaEntities context = new AliyavaEntities())
            {

                bool existeProducto = context.Stock.Include("Producto").Any(a => a.Producto.codigo_barras == dto.codigoBarras);


                if (existeProducto)
                {
                    stock = context.Stock.FirstOrDefault(f => f.Producto.codigo_barras == dto.codigoBarras);

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
                else
                {
                    //Mensaje de error sobre "No existe el producto a dar de baja"

                }

            }

        }

        public List<DtoHistoricoStock> GetStockHis()
        {
            List<DtoHistoricoStock> colHis = new List<DtoHistoricoStock>();
            List<DtoStock> coldto = new List<DtoStock>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Stock> colStock = context.Stock.Select(s => s).ToList();
                int idEmpl;

                foreach (Stock stock in colStock)
                {
                    DtoStock dtoTo = MStock.MapToDto(stock);
                    coldto.Add(dtoTo);
                }

                foreach (DtoStock dtoStock in coldto)
                {
                    DtoHistoricoStock dtoHis = new DtoHistoricoStock();
                    dtoHis.Ubicacion = dtoStock.Ubicacion;
                    dtoHis.Cantidad = (double)dtoStock.Cantidad;
                    dtoHis.Motivo = dtoStock.Motivo;
                   
                    idEmpl = context.Empleado.FirstOrDefault(f => f.NombreUsuario == dtoStock.nombreUsuEmpleado).idEmpleado;

                    dtoHis.idEmpleado = idEmpl;
                
                    colHis.Add(dtoHis);
     
                }
                


            }

            return colHis;


        }
    }
}
