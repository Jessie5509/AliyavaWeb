using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HStock
    {
        private static HStock _instance;
        public static HStock getInstace()
        {
            if (_instance == null)
            {
                _instance = new HStock();
            }

            return _instance;
        }

        //public void CreateStock(DtoStock dto)
        //{
        //    PStock ps = new PStock();
        //    ps.AltaStock(dto);
        //}

        public void SumStock(DtoStock dto, string NombreUsu)
        {
            PStock ps = new PStock();
            ps.SumarStock(dto, NombreUsu);
        }

        //public void BajaStock(DtoStock dto)
        //{
        //    PStock ps = new PStock();
        //    ps.DeleteStock(dto);
        //}

        public List<DtoStock> GetAllStock()
        {
        
            PStock ps = new PStock();
            return ps.getAllStock();
          
        }
        public List<DtoHistoricoStock> GetStock()
        {
            PStock ps = new PStock();
            return ps.GetStockHis();
        }

    }
}
