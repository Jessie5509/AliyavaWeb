using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HEmpleado
    {
        private static HEmpleado _instance;
        public static HEmpleado getInstace()
        {
            if (_instance == null)
            {
                _instance = new HEmpleado();
            }

            return _instance;
        }

        public bool ExisteEmpleado(DtoEmpleado dto)
        {
            PEmpleado pe = new PEmpleado();
            return pe.existeEmpleado(dto);
        }


    }
}
