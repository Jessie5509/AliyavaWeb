using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aliyava.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPedidoV()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddPedido(DtoPedido nuevoPedido)
        {
            HPedido.getInstace().AgregarPedido(nuevoPedido);
            return RedirectToAction("AddPedidoV");
        }



        public ActionResult ListarPedidosCarrito(DtoPedido dto)
        { 
            List<DtoPedido> colPedidos = HPedido.getInstace().GetPedido(dto);
            return View(colPedidos);   
        }


    }
}