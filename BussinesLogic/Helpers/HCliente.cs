﻿using Common.DTO;
using DataAccess.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Helpers
{
    public class HCliente
    {
        private static HCliente _instance;
        public static HCliente getInstace()
        {
            if (_instance == null)
            {
                _instance = new HCliente();
            }

            return _instance;
        }

        public void AddCliente(DtoCliente dto)
        {
            PCliente pc = new PCliente();
            pc.RegistrarCliente(dto);
        }

        public DtoCliente GetDataCliente()
        {
            PCliente pc = new PCliente();
            return pc.getDataCli();
            
        }

    }
}
