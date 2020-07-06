using Aliyava.Helpers;
using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aliyava.Controllers
{
    [UserAuthentication]
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetallePedidos(int id)
        {
            List<DtoDetallePedido> colDetallesByPedido = HPedido.getInstace().GetDetallePedido(id);
            return View(colDetallesByPedido);

        }


        public ActionResult ListarPedidoUrgente()
        { 
            List<DtoPedido> colPedidosUrg = HPedido.getInstace().GetPedidoUrg();
            return View(colPedidosUrg);   
        }

        public ActionResult ListarPedidosNoUrgentes()
        {
            List<DtoPedido> colPedidos = HPedido.getInstace().GetPedido();
            return View(colPedidos);
        }


    }
}