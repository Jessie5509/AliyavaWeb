using AliyavaCliente.Helpers;
using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AliyavaCliente.Controllers
{
    [UserAuthentication]
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult CarritoV()
        //{
        //    List<DtoProducto> colProducto = new List<DtoProducto>();
        //    colProducto = HProducto.getInstace().GetProductoCarrito();
            
        //    return View(colProducto);
        //}
        public ActionResult ListarCarrito()
        {


            return View();
        }

    }
}