using Common.DTO;
using DataAccess.Mappers;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Persistencia
{
    public class PPedido
    {
        //Clientes
        public bool AgregarPedido(List<DtoProducto> colProductosPedidos, string NombreUsu, string password, bool ChkUrgente)
        {
            bool error = false;

            using (AliyavaEntities context = new AliyavaEntities())
            {
                Cliente cli = context.Cliente.FirstOrDefault(f => f.NombreUsuario == NombreUsu && f.contraseña == password);
                double precioTotal = 0;
                bool tieneDirecciones = context.Direcciones.Any(a => a.idCliente == cli.idCliente);

                if (cli.Direccion != null && cli.Telefono != null && tieneDirecciones == true)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        try
                        {
                            Pedido nuevoPedido = new Pedido();

                            nuevoPedido.Direccion = cli.Direccion;
                            nuevoPedido.Estado = "Pendiente";
                            nuevoPedido.FechaIngreso = DateTime.Today;

                            //Precio total de productos en el pedido.
                            foreach (DtoProducto item in colProductosPedidos)
                            {
                                precioTotal = (double)(item.PrecioVenta + precioTotal);

                            }

                            //Validación de si es urgente o no.
                            if (ChkUrgente == true)
                            {
                                precioTotal = precioTotal + 10;
                                nuevoPedido.Urgente = "Si";
                            }
                            else
                            {
                                nuevoPedido.Urgente = "No";
                            }

                            nuevoPedido.PrecioTotal = precioTotal;
                            nuevoPedido.Usuario = cli.NombreUsuario;
                            nuevoPedido.idCliente = cli.idCliente;
                            
                            //DetallePedidoAdd
                      
                            foreach (DtoProducto dto in colProductosPedidos)
                            {
                                DetallePedido ingresoDetallePedido = new DetallePedido();
                                ingresoDetallePedido.PrecioU = (double)dto.PrecioVenta;
                                ingresoDetallePedido.idProducto = dto.Codigo;

                                Producto pro = context.Producto.Include("Stock").FirstOrDefault(f => f.codigo_barras == dto.codigoBarras);
                                string ubicacionP = context.Stock.FirstOrDefault(f => f.Producto.codigo_barras == pro.codigo_barras).Ubicacion;

                                ingresoDetallePedido.UbicacionPro = ubicacionP;

                                ingresoDetallePedido.CantidadPreparar = (double)dto.CantidadPreparar;

                                nuevoPedido.DetallePedido.Add(ingresoDetallePedido);
                               
                            }

                            //Dar de alta la reserva.

                            AddReserva(colProductosPedidos, nuevoPedido, context);

                            context.Pedido.Add(nuevoPedido);
                            context.SaveChanges();

                            scope.Complete();

                        }
                        catch (Exception ex)
                        {
                            scope.Dispose();

                        }
                    }

                }
                else
                {
                    //Msj de error porque no ingreso esos datos.
                    error = true;
                }

            }

            return error;
        }

        public void AddReserva(List<DtoProducto> colProductosPedidos, Pedido nuevoPedido, AliyavaEntities context)
        {
            Stock stockByPro = new Stock();
              
              foreach (DtoProducto dto in colProductosPedidos)
              {
                  Reserva nuevaReserva = new Reserva();

                  Producto pro = context.Producto.FirstOrDefault(f => f.codigo_barras == dto.codigoBarras);
                  string ubicacionP = context.Stock.Include("Producto").FirstOrDefault(f => f.Producto.codigo_barras == pro.codigo_barras).Ubicacion;

                  nuevaReserva.Ubicacion = ubicacionP;
                  nuevaReserva.Estado = "Activo";
                  nuevaReserva.Cantidad = dto.CantidadPreparar;
                  //Reservar stock por cada producto de la lista.
                  stockByPro = context.Stock.FirstOrDefault(f => f.idProducto == dto.Codigo);
                  stockByPro.Cantidad = stockByPro.Cantidad - dto.CantidadPreparar;

                  nuevoPedido.Reserva.Add(nuevaReserva);
                  
              }

        }

        public void cancelarPed(int idPedido, string NombreUsu)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Pedido ped = context.Pedido.Include("Reserva").FirstOrDefault(f => f.Numero == idPedido);
                        //List<DetallePedido> coldet = context.DetallePedido.Include("Pedido, Reserva").Where(w => w.idPedido == idPedido).ToList();

                        Stock stockByPro = new Stock();
                        ped.Estado = "Cancelado";

                        foreach (DetallePedido det in ped.DetallePedido)
                        {
                            foreach (Reserva res in ped.Reserva)
                            {
                                res.Estado = "Inactiva";
                                stockByPro = context.Stock.FirstOrDefault(w => w.idProducto == det.idProducto);

                                if (stockByPro != null)
                                {
                                    stockByPro.Cantidad = stockByPro.Cantidad + det.CantidadPreparar;
                                }

                            }

                        }

                        Historico_de_Cambio_de_estados hisEstado = new Historico_de_Cambio_de_estados();
                        hisEstado.Accion = "Se canceló su pedido.";
                        hisEstado.Estados = "Cancelado";
                        hisEstado.numPedido = ped.Numero;
                        hisEstado.Funcionario = NombreUsu;
                        hisEstado.FechaCambio = DateTime.Today;

                        context.Historico_de_Cambio_de_estados.Add(hisEstado);
                        context.SaveChanges();

                        scope.Complete();

                    }
                    catch (Exception ex)
                    {
                        scope.Dispose();
                       
                    }
                }

            }
        }

        public List<DtoPedido> getPedidoCli(string NombreUsu)
        {
            List<Pedido> colPedidosDB = new List<Pedido>();
            List<DtoPedido> colPedidos = new List<DtoPedido>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                colPedidosDB = context.Pedido.Where(w => w.Usuario == NombreUsu).ToList();

                foreach (Pedido item in colPedidosDB)
                {
                    DtoPedido pedido = MPedido.MapToDto(item);
                    colPedidos.Add(pedido);
                }


            }

            return colPedidos;
        }

        public List<DtoPedido> getPedidoCliPrep(string NombreUsu)
        {
            List<Pedido> colPedidosDB = new List<Pedido>();
            List<DtoPedido> colPedidos = new List<DtoPedido>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                colPedidosDB = context.Pedido.Where(w => w.Usuario == NombreUsu).ToList();
                colPedidosDB = context.Pedido.Where(w => w.Estado == "En preparación" || w.Estado == "Pendiente").ToList();

                foreach (Pedido item in colPedidosDB)
                {
                    DtoPedido pedido = MPedido.MapToDto(item);
                    colPedidos.Add(pedido);
                }


            }

            return colPedidos;
        }


        //-----------------------------------------------------------------------------------------------------------



        //Empleados
        public void cambiarEstadoPedido(int idPedido, string NombreUsu)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Pedido pedido = context.Pedido.FirstOrDefault(f => f.Numero == idPedido);
                pedido.Estado = "En despacho";

                Historico_de_Cambio_de_estados hisEstado = new Historico_de_Cambio_de_estados();
                hisEstado.Accion = "Se confirmó que la preparación del pedido culminó, pasó a despacho.";
                hisEstado.Estados = "En despacho";
                hisEstado.numPedido = idPedido;
                hisEstado.Funcionario = NombreUsu;
                hisEstado.FechaCambio = DateTime.Today;

                context.Historico_de_Cambio_de_estados.Add(hisEstado);
                context.SaveChanges();

            }
        }

        public List<DtoPedido> getAllPedidos()
        {
            List<Pedido> colPedidosDB = new List<Pedido>();
            List<DtoPedido> colPedidos = new List<DtoPedido>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                colPedidosDB = context.Pedido.Select(s => s).ToList();

                foreach (Pedido item in colPedidosDB)
                {
                    DtoPedido pedido = MPedido.MapToDto(item);
                    colPedidos.Add(pedido);
                }

            }

            return colPedidos;
        }


        public void confirmarProPre(int id, List<DtoProducto> colProPreparar)
        {
            DtoProducto dto = new DtoProducto();

            using (AliyavaEntities context = new AliyavaEntities()) 
            {
                foreach (DtoProducto item in colProPreparar)
                {
                    if (item.Codigo == id)
                    {
                        dto = item;

                    }

                }

                colProPreparar.Remove(dto);

            }

        }


        public List<DtoPedido> getPedidoUrg()
        {
            List<Pedido> colPedidosDB = new List<Pedido>();
            List<DtoPedido> colPedidos = new List<DtoPedido>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                colPedidosDB = context.Pedido.Where(w => w.Urgente == "Si" && w.Estado == "Pendiente").ToList();

                foreach (Pedido item in colPedidosDB)
                {
                    DtoPedido pedido = MPedido.MapToDto(item);
                    colPedidos.Add(pedido);
                }


            }

            return colPedidos;
        }

        public List<DtoPedido> GetPedidos()
        {
            List<Pedido> colPedidosDB = new List<Pedido>();
            List<DtoPedido> colPedidos = new List<DtoPedido>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                colPedidosDB = context.Pedido.Where(w => w.Urgente == "No" && w.Estado == "Pendiente").ToList();

                foreach (Pedido item in colPedidosDB)
                {
                    DtoPedido pedido = MPedido.MapToDto(item);
                    colPedidos.Add(pedido);
                }


            }

            return colPedidos;
        }

        //Cliente/Empleado
        public List<DtoDetallePedido> GetDetalle(int id)
        {
            List<DtoDetallePedido> colDtoDetalle = new List<DtoDetallePedido>();
            List<DetallePedido> colDetalleDB = new List<DetallePedido>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                colDetalleDB = context.DetallePedido.Where(w => w.idPedido == id).ToList();

                foreach (DetallePedido item in colDetalleDB)
                {
                    DtoDetallePedido detalle = MDetalle.MapToDto(item);
                    colDtoDetalle.Add(detalle);
                }


            }


            return colDtoDetalle;
        }

        public List<DtoHistoricoEstado> getHisEstado(int id)
        {
            List<Historico_de_Cambio_de_estados> colHisDB = new List<Historico_de_Cambio_de_estados>();
            List<DtoHistoricoEstado> colHis = new List<DtoHistoricoEstado>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                colHisDB = context.Historico_de_Cambio_de_estados.Where(w => w.numPedido == id).ToList();

                foreach (Historico_de_Cambio_de_estados item in colHisDB)
                {
                    DtoHistoricoEstado his = MHisEstado.MapToDto(item);
                    colHis.Add(his);
                }


            }

            return colHis;
        }

        //-------------------------------------------------------------
    }
}
