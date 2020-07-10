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

        public bool AddProducto(DtoProducto dto)
{
            PProducto pc = new PProducto();
            return pc.RegistarProducto(dto);
        }

        public List<DtoProducto> GetProducto()
        {
            PProducto pc = new PProducto();
            return pc.GetProducto();
        }

        public DtoProducto GetProductoCarrito(int id, out bool stockOk, List<DtoProducto> colProducto)
        {
            PProducto pp = new PProducto();
            return pp.GetProductoCarrito(id, out stockOk, colProducto);
        }

        public DtoProducto GetProductoInfo(int id)
        {
            PProducto pp = new PProducto();
            return pp.GetProductoInfo(id);
        }

        public List<DtoProducto> GetProPreparar(int id, string NombreUsu)
        {
            PProducto pp = new PProducto();
            return pp.getProPreparar(id, NombreUsu);
        }
        

        //public void RemoveProducto(int Codigo, string NombreUsu)
        //{
        //    PProducto ps = new PProducto();
        //    ps.RemoveProducto(Codigo, NombreUsu);
        //}

        public List<DtoProducto> GetProductoFamilia(string familia)
        {
            PProducto pc = new PProducto();
            return pc.GetProductoFamilia(familia);
        }

        public DtoProducto GetProductoM(int Codigo)
        {
            PProducto pc = new PProducto();
            return pc.GetProductoM(Codigo);
        }

        public bool ModificarProducto(DtoProducto dto)
        {
            PProducto pc = new PProducto();
            return pc.ModificarProducto(dto);
        }

    }
}
