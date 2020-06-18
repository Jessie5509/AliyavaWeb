using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aliyava.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult RegistrarProducto()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddProducto(DtoProducto nuevoproducto)
        {
            HProducto.getInstace().AddProducto(nuevoproducto);
            return RedirectToAction("RegistrarProducto");
        }


        public ActionResult ListarProducto()
        {
            List<DtoProducto> colProducto = new List<DtoProducto>();
            colProducto = HProducto.getInstace().GetProducto();
            return View(colProducto);
        }

        public ActionResult RemoveProducto(DtoProducto prod)
        {
            HProducto.getInstace().RemoveProducto(prod);
            return RedirectToAction("RemoveProducto");
        }

    }
}