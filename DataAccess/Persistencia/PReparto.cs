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
    public class PReparto
    {
        public void RegistrarReparto(DtoReparto nuevoReparto)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        Reparto nuevoR = new Reparto();
                        nuevoR.MatriculaVehiculo = nuevoReparto.MatriculaVehiculo;
                        nuevoR.Estado = "En definición";
                        nuevoR.Chofer = nuevoReparto.Chofer;
                        nuevoR.FechaSalida = DateTime.Today;

                        context.Reparto.Add(nuevoR);
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

        public void asignarPedido(int idP, int idR, string NombreUsu)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                //Asignar pedidos.
                Pedido Ped = context.Pedido.Include("Reparto").FirstOrDefault(f => f.Numero == idP);
                Reparto rep = context.Reparto.Include("Pedido").FirstOrDefault(f => f.idReparto == idR);

                Ped.Reparto = rep;
                rep.Pedido.Add(Ped);

                Ped.Estado = "En viaje";
                rep.Estado = "En viaje";

                Historico_de_Cambio_de_estados hisEstado = new Historico_de_Cambio_de_estados();
                hisEstado.Accion = "El pedido ya está en viaje.";
                hisEstado.Estados = "En viaje";
                hisEstado.numPedido = Ped.Numero;
                hisEstado.Funcionario = NombreUsu;
                hisEstado.FechaCambio = DateTime.Today;

                context.Historico_de_Cambio_de_estados.Add(hisEstado);
                context.SaveChanges();
            }
       


        }


        public List<DtoReparto> getRepartoDefinición()
        {
            List<DtoReparto> colDtoRe = new List<DtoReparto>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Reparto> colRepDB = context.Reparto.Where(w => w.Estado == "En definición").ToList();

                foreach (Reparto item in colRepDB)
                {
                    DtoReparto dto = MReparto.MapToDto(item);
                    colDtoRe.Add(dto);
                }

            }

           return colDtoRe;
        }

        public void eliminarRepartoById(int id)
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {
                Reparto reparto = context.Reparto.FirstOrDefault(f => f.idReparto == id);

                context.Reparto.Remove(reparto);
                context.SaveChanges();
            }


        }

        public List<DtoPedido> getPedidosEnDespacho(int id)
        {
            List<DtoPedido> colDtoP = new List<DtoPedido>();

            using (AliyavaEntities context = new AliyavaEntities())
            {
                List<Pedido> colPedDB = context.Pedido.Where(w => w.Estado == "En despacho").ToList();

                foreach (Pedido item in colPedDB)
                {
                    DtoPedido dto = MPedido.MapToDto(item);
                    colDtoP.Add(dto);
                }

            }

            return colDtoP;
        }

      

    }
}
