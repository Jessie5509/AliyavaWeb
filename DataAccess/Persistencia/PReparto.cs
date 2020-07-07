using Common.DTO;
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
                        nuevoR.Estado = nuevoReparto.Estado;
                        nuevoR.Chofer = nuevoReparto.Chofer;
                        nuevoR.FechaSalida = DateTime.Today;

                        //Asignar pedidos.
                        List<Pedido> colPed = context.Pedido.Include("Reparto").Where(w => w.Estado == "En despacho").Take(3).ToList();

                        foreach (Pedido item in colPed)
                        {
                            nuevoR.Pedido.Add(item);
                            item.Reparto = nuevoR;
                    
                        }
              
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
    }
}
