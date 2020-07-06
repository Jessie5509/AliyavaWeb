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

    }
}
