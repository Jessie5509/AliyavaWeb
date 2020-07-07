﻿using Common.DTO;
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

        //Clientes
        public void AddPedido(List<DtoProducto> colProductosPedidos, string NombreUsu, string password, bool ChkUrgente)
        {
            PPedido pp = new PPedido();
            pp.AgregarPedido(colProductosPedidos, NombreUsu, password, ChkUrgente);
        }

        public List<DtoPedido> GetPedidoCli(string NombreUsu)
        {
            PPedido pp = new PPedido();
            return pp.getPedidoCli(NombreUsu);
        }



      //-------------------------------------------------------------------------------------------------------




        //Empleados
        public List<DtoPedido> GetPedidoUrg()
        {
            PPedido pp = new PPedido();
            return pp.getPedidoUrg();
        }

        public List<DtoPedido> GetPedido()
        {
            PPedido pp = new PPedido();
            return pp.GetPedidos();
        }
        
        //Cliente/Empleado
        public List<DtoDetallePedido> GetDetallePedido(int id)
        {
            PPedido pp = new PPedido();
            return pp.GetDetalle(id);
        }
        //----------------

        public void CambiarEstadoPedido(List<DtoProducto> colProPreparar)
        {
            PPedido pp = new PPedido();
            pp.cambiarEstadoPedido(colProPreparar);
        }

    }
}
