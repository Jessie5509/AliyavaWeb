using Common.DTO;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistencia
{
    public class PReporte
    {
        /*
        //Aqui saber cuantas veces se repite ese producto en diferentes pedidos, bno preciso recibir nada y puedo devolver un DtoProducto o un DtoEspecial
        public DtoReporte1 Reporte1()
        {
            DtoReporte1 dto = new DtoReporte1();
            List<int> pro = new List<int>();
            using (AliyavaEntities context = new AliyavaEntities())
            {

                 pro = context.Producto.Select(w => w.Codigo).ToList();
                DetallePedido deta = context.DetallePedido.Where(c => c.idProducto == pro);

                
            }
        }

        //devolver 
        public void Reporte3()
        {
            using (AliyavaEntities context = new AliyavaEntities())
            {



            }

        }
        */

        }
}
