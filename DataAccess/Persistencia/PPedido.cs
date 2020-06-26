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
        public void AgregarPedido(List<DtoProducto> colProductosPedidos, string NombreUsu, string password, bool urgente)
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

                            foreach (DtoProducto item in colProductosPedidos)
                            {
                                precioTotal = (double)(item.PrecioVenta + precioTotal);

                            }

                            if (urgente == true)
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
                            


                            context.Pedido.Add(nuevoPedido);

                            //DetallePedidoAdd










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
