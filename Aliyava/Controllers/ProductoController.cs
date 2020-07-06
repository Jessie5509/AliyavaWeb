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
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index(string dato)
        {
            

            return View();
        }

 


        public ActionResult RegistrarProducto()
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

            ViewBag.colCategorias = colSelectItems;


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
            return RedirectToAction("ListarProducto");
        }

        //Modifica el producto.
        public ActionResult ConfirmarCambios(DtoProducto dtoPro)
        {
            HProducto.getInstace().ModificarProducto(dtoPro);
            return RedirectToAction("ListarProducto");

        }

        //Vista formulario a modificar.
        public ActionResult ModificarProducto(int Codigo)
        {
            DtoProducto productoFB = new DtoProducto();

            productoFB = HProducto.getInstace().GetProductoM(Codigo);

            List<DtoCategoria> colTipos = HCategoria.getInstace().GetCategoria();

            List<SelectListItem> colSelectItems = new List<SelectListItem>();

            foreach (DtoCategoria item in colTipos)
            {
                SelectListItem opcion = new SelectListItem();
                opcion.Text = item.Nombre;
                opcion.Value = item.Nombre;
                colSelectItems.Add(opcion);
            }

            ViewBag.colCategorias = colSelectItems;


           
            return View(productoFB);
        }

    }
}