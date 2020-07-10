using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HReparto
    {
        private static HReparto _instance;
        public static HReparto getInstace()
        {
            if (_instance == null)
            {
                _instance = new HReparto();
            }

            return _instance;
        }

        public void AddReparto(DtoReparto nuevoReparto)
        {
            PReparto pr = new PReparto();
            pr.RegistrarReparto(nuevoReparto);

        }

        public List<DtoReparto> GetRepartosEnDefinición()
        {
            PReparto pr = new PReparto();
            return pr.getRepartoDefinición();
            
        }

        public void EliminarRepartoById(int id)
        {
            PReparto pr = new PReparto();
            pr.eliminarRepartoById(id);
        }

        public List<DtoPedido> GetPedidosEnDespacho(int id)
        {
            PReparto pr = new PReparto();
            return pr.getPedidosEnDespacho(id);
        }

        public void AsignarPedido(int idP, int idR, string NombreUsu)
        {
            PReparto pr = new PReparto();
            pr.asignarPedido(idP, idR, NombreUsu);
        }

    }
}
