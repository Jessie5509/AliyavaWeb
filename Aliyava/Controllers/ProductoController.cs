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


            if (TempData["MessageP"] != null)
            {
                ViewBag.MessageP = TempData["MessageP"].ToString();

            }


            return View();
        }

        [HttpPost]
        public ActionResult AddProducto(DtoProducto nuevoproducto)
        {
            bool msg = HProducto.getInstace().AddProducto(nuevoproducto);

            if (msg == true)
            {
                TempData["MessageP"] = "Producto agregado satisfactoriamente!";
            }
            else
            {
                TempData["MessageP"] = "Error, verifique los datos por favor!";
            }

            return RedirectToAction("RegistrarProducto");
        }


        public ActionResult ListarProducto()
        {
            List<DtoProducto> colProducto = new List<DtoProducto>();
            colProducto = HProducto.getInstace().GetProducto();
            return View(colProducto);
        }

        //public ActionResult RemoveProducto(int Codigo)
        //{
        //    string NombreUsu = Session["NombreDeUsuario"].ToString();
        //    HProducto.getInstace().RemoveProducto(Codigo, NombreUsu);
        //    return RedirectToAction("ListarProducto");
        //}

        //Modifica el producto.
        public ActionResult ConfirmarCambios(DtoProducto dtoPro)
        {
            bool msg = HProducto.getInstace().ModificarProducto(dtoPro);

            if (msg == true)
            {
                TempData["Message"] = "Cambios modificados correctamente!";

            }
            else
            {
                TempData["Message"] = "Error, verifique los datos por favor!";
            }

            return RedirectToAction("MsgModificar");


        }
        public ActionResult MsgModificar()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();

            }

            return View();
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