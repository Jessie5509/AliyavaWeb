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

        public ActionResult RemoveProducto(int Codigo)
        {
            HProducto.getInstace().RemoveProducto(Codigo);
            return RedirectToAction("RemoveProducto");
        }

        public ActionResult ConfirmarCambios(DtoProducto dtoPro)
        {
            HProducto.getInstace().ModificarProducto(dtoPro);
            return RedirectToAction("ListarProducto");

        }

        public ActionResult ModificarProducto(int Codigo)
        {
            DtoProducto productoFB = new DtoProducto();

            productoFB = HProducto.getInstace().GetProductoM(Codigo);

            return View(productoFB);
        }

    }
}