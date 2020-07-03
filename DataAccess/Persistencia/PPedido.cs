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
    public class PPedido
    {
        public void AgregarPedido(List<DtoProducto> colProductosPedidos, string NombreUsu, string password, bool ChkUrgente)
        {

            using (AliyavaEntities context = new AliyavaEntities())
            {
                Cliente cli = context.Cliente.FirstOrDefault(f => f.NombreUsuario == NombreUsu && f.contraseña == password);
                double precioTotal = 0;

                if (cli.Direccion != null && cli.Telefono != null)
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
                            nuevoPedido.idReserva = 1;
                   
                            context.Pedido.Add(nuevoPedido);
                          

                            //Checkear el tema de como obtener el número del pedido qeu se acaba de ingresar.
                            //Session tal vez.
                            //int Numero = context.Pedido.FirstOrDefault(w => w.Usuario == NombreUsu).Numero;

                            //DetallePedidoAdd
                      
                            foreach (DtoProducto dto in colProductosPedidos)
                            {
                                DetallePedido ingresoDetallePedido = new DetallePedido();
                                ingresoDetallePedido.PrecioU = (double)dto.PrecioVenta;
                                ingresoDetallePedido.idProducto = dto.Codigo;
                                ingresoDetallePedido.idPedido = 1;//Checkear el tema de como obtener el número del pedido qeu se acaba de ingresar.
                                /*ingresoDetallePedido.Pedido = nuevoPedido;*///??

                                Producto pro = context.Producto.Include("Stock").FirstOrDefault(f => f.codigo_barras == dto.codigoBarras);
                                string ubicacionP = context.Stock.FirstOrDefault(f => f.Producto.codigo_barras == pro.codigo_barras).Ubicacion;

                                ingresoDetallePedido.UbicacionPro = ubicacionP;

                                ingresoDetallePedido.CantidadPreparar = (double)dto.CantidadPreparar;

                                context.DetallePedido.Add(ingresoDetallePedido);
                               
                            }

                            context.SaveChanges();

                            //Dar de alta la reserva.

                            AddReserva(colProductosPedidos);


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
                }

            }
        }

        public void AddReserva(List<DtoProducto> colProductosPedidos)
        {
            Stock stockByPro = new Stock();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                foreach (DtoProducto dto in colProductosPedidos)
                {
                    Reserva nuevaReserva = new Reserva();

                    Producto pro = context.Producto.FirstOrDefault(f => f.codigo_barras == dto.codigoBarras);
                    string ubicacionP = context.Stock.FirstOrDefault(f => f.Producto.codigo_barras == pro.codigo_barras).Ubicacion;

                    nuevaReserva.Ubicacion = ubicacionP;
                    nuevaReserva.Estado = "Activo";

                    //int cant = colProductosPedidos.Count(c => c.Codigo == dto.Codigo);

                    nuevaReserva.Cantidad = dto.CantidadPreparar;
                    //Reservar stock por cada producto de la lista.
                    stockByPro = context.Stock.FirstOrDefault(f => f.idProducto == dto.Codigo);
                    stockByPro.Cantidad = stockByPro.Cantidad - dto.CantidadPreparar;

                    context.Reserva.Add(nuevaReserva);
                    context.SaveChanges();

                }


            }


        }

        public void CancelarPedido()
        {

        }

   
        public List<DtoPedido> GetPedidos(DtoPedido dto)
        {
            List<Pedido> colPedidosDB = new List<Pedido>();
            List<DtoPedido> colPedidos = new List<DtoPedido>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                colPedidosDB = context.Pedido.Where(w => w.Usuario == dto.Usuario).ToList();

                foreach (Pedido item in colPedidosDB)
                {
                    DtoPedido pedido = MPedido.MapToDto(item);
                    colPedidos.Add(pedido);
                }


            }

            return colPedidos;
        }
    }
}
