using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AliyavaCliente.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<DtoProducto> colProducto = new List<DtoProducto>();
            colProducto = HProducto.getInstace().GetProducto();    
            return View(colProducto);
        }

        public ActionResult ProductoInfo(int id)
        {
            DtoProducto producto = new DtoProducto();
            producto = HProducto.getInstace().GetProductoInfo(id);

            return View(producto);
        }




    }
}