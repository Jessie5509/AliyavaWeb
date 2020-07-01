using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HPedido
    {
        private static HPedido _instance;
        public static HPedido getInstace()
        {
            if (_instance == null)
            {
                _instance = new HPedido();
            }

            return _instance;
        }
        public void AddPedido(List<DtoProducto> colProductosPedidos, string NombreUsu, string password, bool ChkUrgente)
        {
            PPedido pp = new PPedido();
            pp.AgregarPedido(colProductosPedidos, NombreUsu, password, ChkUrgente);
        }

        public List<DtoPedido> GetPedido(DtoPedido dto)
        {
            PPedido pp = new PPedido();
            return pp.GetPedidos(dto);
        }

    }
}
