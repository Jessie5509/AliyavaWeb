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
    public class PProducto
    {

        public bool RegistarProducto(DtoProducto dto)
        {
            bool msg;

            using (AliyavaEntities context = new AliyavaEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        int idcat = context.Categoria.Include("Producto").FirstOrDefault(f => f.Nombre == dto.Familia).idCategoria;
                        Categoria cat = context.Categoria.Include("Producto").FirstOrDefault(f => f.idCategoria == idcat);

                        Producto nProducto = new Producto();
                        nProducto.Categoria = cat;
                        nProducto.Descripcion = dto.Descripcion;
                        nProducto.Familia = dto.Familia;
                        nProducto.PrecioVenta = dto.PrecioVenta;
                        nProducto.codigo_barras = dto.codigoBarras;
                        nProducto.ProDescripcion = dto.ProDescripcion;
                        nProducto.ImagenPro = dto.ImagenPro;

                        context.Producto.Add(nProducto);
                        context.SaveChanges();

                        scope.Complete();

                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        return msg = false;
                    }

                    return msg = true;


                }

            }
        }


        public List<DtoProducto> GetProducto()
        {
            List<DtoProducto> colDtoProducto = new List<DtoProducto>();
            using (AliyavaEntities context = new AliyavaEntities())
            {
                
                List<Producto> colProducto = context.Producto.Select(s => s).ToList();

                foreach (Producto pro in colProducto)
                {
                    DtoProducto dto = MProducto.MapToDto(pro);
                    colDtoProducto.Add(dto);
                }
            }
            return colDtoProducto;
        }

        public DtoProducto GetProductoCarrito(int id, out bool stockOk, List<DtoProducto> colProducto)
        {
            DtoProducto dto = new DtoProducto();

            stockOk = true;

            using (AliyavaEntities context = new AliyavaEntities())
            {
                Producto Producto = context.Producto.Include("Stock").FirstOrDefault(f => f.Codigo == id);
                Producto.CantidadPreparar = 1;
                //Validación de stock.
                float cantidad = (float)context.Stock.Include("Producto").FirstOrDefault(f => f.idProducto == id).Cantidad;

                foreach (DtoProducto item in colProducto)
                {
                    if (item.Codigo == Producto.Codigo && item.CantidadPreparar >= cantidad)
                    {
                        stockOk = false;

                    }
                    else
                    {
                        stockOk = true;
                    }

                }

                dto = MProducto.MapToDto(Producto);
                 
                
            }

            return dto;
      
        }


        public List<DtoProducto> getProPreparar(int id)
        {
            List<DtoProducto> colDtoProducto = new List<DtoProducto>();
       
            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<DetallePedido> colDet = context.DetallePedido.Where(w => w.idPedido == id).ToList();

                foreach (DetallePedido det in colDet)
                {
                    DtoProducto dto = new DtoProducto();
                    dto.Codigo = det.idProducto;
                    dto.CantidadPreparar = (int?)det.CantidadPreparar;
                    dto.UbicacionPro = det.UbicacionPro;

                    colDtoProducto.Add(dto);
                }

         
            }
            return colDtoProducto;

        }

        public DtoProducto GetProductoInfo(int id)
        {
            DtoProducto dto = new DtoProducto();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                Producto Producto = context.Producto.FirstOrDefault(f => f.Codigo == id);
                dto = MProducto.MapToDto(Producto);
                



            }

            return dto;

        }

        public List<DtoProducto> GetProductoFamilia(string familia)
        {
            List<DtoProducto> colProducto = new List<DtoProducto>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Producto> colProd = context.Producto.Where(f => f.Familia == familia).ToList();

                foreach (Producto item in colProd)
                {
                    DtoProducto dto = new DtoProducto();
                    dto.Codigo = item.Codigo;
                    dto.Descripcion = item.Descripcion;
                    dto.Familia = item.Familia;
                    dto.PrecioVenta = item.PrecioVenta;
                    dto.codigoBarras = item.codigo_barras;
                    dto.ProDescripcion = item.ProDescripcion;
                    dto.CantidadPreparar = item.CantidadPreparar;
                    dto.ImagenPro = item.ImagenPro;

                    colProducto.Add(dto);
                }

            }

            return colProducto;

        }


        //public void RemoveProducto(int Codigo, string NombreUsu)
        //{
        //    int idEmpl = 0;

        //    using (AliyavaEntities context = new AliyavaEntities())
        //    {
        //        Producto prod = context.Producto.FirstOrDefault(f => f.Codigo == Codigo );
        //        Stock stock = context.Stock.Include("Producto").FirstOrDefault(f => f.idProducto == Codigo);

        //        HistoricoStock hisStock = new HistoricoStock();
        //        //Modificar para productos sin stock.
        //        hisStock.Cantidad = (double)stock.Cantidad;
        //        hisStock.Ubicacion = stock.Ubicacion;
        //        hisStock.Motivo = "Eliminación de producto";
        //        hisStock.CantidadAddOBaja = -(double)stock.Cantidad;

        //        idEmpl = context.Empleado.FirstOrDefault(f => f.NombreUsuario == NombreUsu).idEmpleado;

        //        hisStock.idEmpleado = idEmpl;

        //        RemStockWhenRemovePro(stock, context);

        //        context.HistoricoStock.Add(hisStock);
        //        context.Producto.Remove(prod);

        //        context.SaveChanges();


        //    }


        //}

        //public void RemStockWhenRemovePro(Stock stock, AliyavaEntities context)
        //{
        //    context.Stock.Remove(stock);
        //    context.SaveChanges();
        //}


        public DtoProducto GetProductoM(int Codigo)
        {
            DtoProducto dto = new DtoProducto();
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Producto prod = context.Producto.FirstOrDefault(f => f.Codigo == Codigo);

                dto = MProducto.MapToDto(prod);
            }
            return dto;
        }

        public bool ModificarProducto(DtoProducto DtoProdu)
        {
            bool msg;

            using (AliyavaEntities context = new AliyavaEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Producto updatePro = context.Producto.FirstOrDefault(f => f.Codigo == DtoProdu.Codigo);
                        updatePro.Descripcion = DtoProdu.Descripcion;
                        updatePro.Familia = DtoProdu.Familia;
                        updatePro.PrecioVenta = DtoProdu.PrecioVenta;
                        updatePro.ProDescripcion = DtoProdu.ProDescripcion;
                        updatePro.ImagenPro = DtoProdu.ImagenPro;

                        context.SaveChanges();

                        scope.Complete();

                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                        return msg = false;
                    }

                    return msg = true;

                }

            }
        }

    }
}
