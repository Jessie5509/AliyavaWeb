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
    public class PPedido
    {
        public void AgregarPedido(DtoPedido dto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Pedido nuevoPedido = new Pedido();
                nuevoPedido.Direccion = dto.Direccion;
                nuevoPedido.Estado = dto.Estado;
                nuevoPedido.FechaIngreso = dto.FechaIngreso;
                nuevoPedido.PrecioTotal = dto.PrecioTotal;
                nuevoPedido.Usuario = dto.Usuario;
              
                context.Pedido.Add(nuevoPedido);
                context.SaveChanges();

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
