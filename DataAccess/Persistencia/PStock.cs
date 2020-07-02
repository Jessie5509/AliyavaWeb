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
            int idEmpl;

            using (AliyavaEntities context = new AliyavaEntities())
            {

                bool existeProducto = context.Stock.Include("Producto").Any(a => a.Producto.codigo_barras == dto.codigoBarras);


                    if (existeProducto)
                    {
                        stock = context.Stock.FirstOrDefault(f => f.Producto.codigo_barras == dto.codigoBarras);

                        if (cantidadAlta > 0)
                        {
                            //stock = MStock.MapToEntity(dto);
                            cantResto = (double)(cantidadAlta + stock.Cantidad);
                            stock.Cantidad = cantResto;

                            HistoricoStock hisStock = new HistoricoStock();
                            hisStock.Cantidad = (double)stock.Cantidad;
                            hisStock.Ubicacion = stock.Ubicacion;
                            hisStock.Motivo = dto.Motivo;
                            hisStock.CantidadAddOBaja = (double)cantidadAlta;

                            idEmpl = context.Empleado.FirstOrDefault(f => f.NombreUsuario == stock.nombreUsuEmpleado).idEmpleado;

                            hisStock.idEmpleado = idEmpl;
                            context.HistoricoStock.Add(hisStock);
                            context.SaveChanges();

                        }
                        else if(cantidadAlta < 0)
                        {
                            DeleteStock(dto);

                        }


                    }
                    else
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {

                            Producto pro = context.Producto.FirstOrDefault(f => f.codigo_barras == dto.codigoBarras);
                            
                            try
                            {

                                if (cantidadAlta > 0)
                                {
                                    Stock nuevoStock = new Stock();
                                    nuevoStock.Producto = pro;
                                    nuevoStock.Ubicacion = dto.Ubicacion;
                                    nuevoStock.Motivo = dto.Motivo;
                                    nuevoStock.Cantidad = dto.Cantidad;
                                    nuevoStock.nombreUsuEmpleado = NombreUsu;

                                    context.Stock.Add(nuevoStock);
                                    context.SaveChanges();

                                    HistoricoStock hisStock = new HistoricoStock();
                                    hisStock.Cantidad = (double)nuevoStock.Cantidad;
                                    hisStock.Ubicacion = nuevoStock.Ubicacion;
                                    hisStock.Motivo = nuevoStock.Motivo;
                                    hisStock.CantidadAddOBaja = (double)cantidadAlta;

                                    idEmpl = context.Empleado.FirstOrDefault(f => f.NombreUsuario == nuevoStock.nombreUsuEmpleado).idEmpleado;

                                    hisStock.idEmpleado = idEmpl;
                                    context.HistoricoStock.Add(hisStock);

                                    context.SaveChanges();
                                }
                                else
                                {
                                    //Error estas tratando de dar de baja cant de producto que no tiene stock.
                                    //El producto no tiene stock.
                                }

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
            int idEmpl;

            using (AliyavaEntities context = new AliyavaEntities())
            {

                bool existeProducto = context.Stock.Include("Producto").Any(a => a.Producto.codigo_barras == dto.codigoBarras);


                if (existeProducto)
                {
                    stock = context.Stock.FirstOrDefault(f => f.Producto.codigo_barras == dto.codigoBarras);

                    stock.Cantidad = (-stock.Cantidad);
                    cantResto = (double)(cantidadBaja - (stock.Cantidad));
                    stock.Cantidad = cantResto;

                    HistoricoStock hisStock = new HistoricoStock();
                    hisStock.Cantidad = (double)stock.Cantidad;
                    hisStock.Ubicacion = stock.Ubicacion;
                    hisStock.Motivo = dto.Motivo;
                    hisStock.CantidadAddOBaja = cantidadBaja;

                    idEmpl = context.Empleado.FirstOrDefault(f => f.NombreUsuario == stock.nombreUsuEmpleado).idEmpleado;

                    hisStock.idEmpleado = idEmpl;
                    context.HistoricoStock.Add(hisStock);
                    context.SaveChanges();

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

        public List<DtoStock> getAllStock()
        {
            List<DtoStock> colDtoStock = new List<DtoStock>();
            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Stock> colStock = context.Stock.Select(s => s).ToList();

                foreach (Stock s in colStock)
                {
                    DtoStock dto = MStock.MapToDto(s);
                    colDtoStock.Add(dto);
                }
            }
            return colDtoStock;
        }
        public List<DtoHistoricoStock> GetStockHis()
        {
            List<DtoHistoricoStock> colHis = new List<DtoHistoricoStock>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<HistoricoStock> colHisDB = context.HistoricoStock.Select(s => s).ToList();

                foreach (HistoricoStock hisstock in colHisDB)
                {
                    DtoHistoricoStock dtoTo = MHisStock.MapToDto(hisstock);
                    colHis.Add(dtoTo);
                }

    
            }

            return colHis;


        }
    }
}
