using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HProducto
    {

        private static HProducto _instance;
        public static HProducto getInstace()
        {
            if (_instance == null)
            {
                _instance = new HProducto();
            }

            return _instance;
        }

        public void AddProducto(DtoProducto dto)
{
            PProducto pc = new PProducto();
            pc.RegistarProducto(dto);
        }

        public List<DtoProducto> GetProducto()
        {
            PProducto pc = new PProducto();
            return pc.GetProducto();
        }

        public void RemoveProducto(DtoProducto dto)
        {
            PProducto ps = new PProducto();
            ps.RemoveProducto(dto);
        }

    }
}
