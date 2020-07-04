using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HReporte
    {

        private static HReporte _instance;
        public static HReporte getInstace()
        {
            if (_instance == null)
            {
                _instance = new HReporte();
            }

            return _instance;
        }


        public List<DtoReporteMasVendido> GetReporte1()
        {
            PReporte pc = new PReporte();
            return pc.Reporte1();
        }

    }
}
