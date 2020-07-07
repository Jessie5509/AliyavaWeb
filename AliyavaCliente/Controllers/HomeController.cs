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
        public ActionResult Index(string sortOrder, string searchString)
        {

            ViewBag.PriceSort = sortOrder == "Price" ? "price_desc" : "Price";

            List<DtoProducto> colProducto = new List<DtoProducto>();
            

            colProducto = HProducto.getInstace().GetProducto();
            //Buscador por nombre de producto
            if (!String.IsNullOrEmpty(searchString))
            {
                colProducto = colProducto.Where(s => s.Descripcion.Contains(searchString)).ToList();
            }
            else 
            {

                colProducto = HProducto.getInstace().GetProducto();
            }
            //Filtrado por precio
            switch (sortOrder)
            {

                case "Price":
                    colProducto = colProducto.OrderBy(s => s.PrecioVenta).ToList();
                    break;
                default:
                    colProducto = colProducto.OrderByDescending(s => s.PrecioVenta).ToList();
                    break;
            }

            //Cargar viebag de familia
            List<DtoCategoria> colTipos = HCategoria.getInstace().GetCategoria();

            List<SelectListItem> colSelectItems = new List<SelectListItem>();

            foreach (DtoCategoria item in colTipos)
            {
                SelectListItem opcion = new SelectListItem();
                opcion.Text = item.Nombre;
                opcion.Value = item.Nombre;
                colSelectItems.Add(opcion);
            }

            ViewBag.colFamilias = colSelectItems;



            return View(colProducto);
        }

        [HttpPost]
        public ActionResult FiltrarFamilia(string familia)
        {
            List<DtoProducto> ProdFam = new List<DtoProducto>();
            if (familia == "")
            {
                ProdFam = HProducto.getInstace().GetProducto();
            }
            else {

                ProdFam = HProducto.getInstace().GetProductoFamilia(familia);
            }
            
             
            return PartialView("_listaProductos",ProdFam);
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

            string stock = "no entro¿";
            List<DtoStock> colstock = new List<DtoStock>();
            colstock = HStock.getInstace().GetAllStock();

            colstock = colstock.Where(s => s.idProducto == id).ToList();
            
            foreach (DtoStock item in colstock)
            {

                if (id == item.idProducto && item.Cantidad > 0)
                {

                    stock = "In Stock";

                }
                else
                {

                    stock = "Out of Stock";

                }

            }
            ViewBag.Stock = stock;

            

            return View(producto);
        }



    }
}