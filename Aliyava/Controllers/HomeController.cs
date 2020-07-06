using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aliyava.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string sortOrder, string searchString)
        {

            ViewBag.PriceSort = sortOrder == "Price" ? "price_desc" : "Price";

            List<DtoProducto> colProducto = new List<DtoProducto>();


            colProducto = HProducto.getInstace().GetProducto();

            if (!String.IsNullOrEmpty(searchString))
            {
                colProducto = colProducto.Where(s => s.Descripcion.Contains(searchString)).ToList();
            }
            else
            {

                colProducto = HProducto.getInstace().GetProducto();
            }

            switch (sortOrder)
            {

                case "Price":
                    colProducto = colProducto.OrderBy(s => s.PrecioVenta).ToList();
                    break;
                default:
                    colProducto = colProducto.OrderBy(s => s.Descripcion).ToList();
                    break;
            }




            return View(colProducto);
        }


        public ActionResult Index1()
        {
            List<DtoCategoria> colTipos = HCategoria.getInstace().GetCategoria();

            List<SelectListItem> colSelectItems = new List<SelectListItem>();

            foreach (DtoCategoria item in colTipos)
            {
                SelectListItem opcion = new SelectListItem();
                opcion.Text = item.Nombre;
                opcion.Value = item.Nombre;
                colSelectItems.Add(opcion);
            }

            ViewBag.colTiposCategoria = colSelectItems;

            return View();
        }


        public ActionResult Filtrado(string familia)
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