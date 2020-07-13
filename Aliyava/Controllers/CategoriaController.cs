using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aliyava.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult RegistrarCategoria()
        {
            if (TempData["Cat"] != null)
            {
                ViewBag.Cat = TempData["Cat"].ToString();

            }

            return View();

        }

        [HttpPost]
        public ActionResult AddCategoria(DtoCategoria nuevacategoria)
        {
            bool msg = HCategoria.getInstace().AddCategoria(nuevacategoria);

            if (msg == true)
            {
                TempData["Cat"] = "Categoría añadida satisfactoriamente!";
            }
            else
            {
                TempData["Cat"] = "Revisa el nombre que quieres ingresar!";
            }

            return RedirectToAction("RegistrarCategoria");
        }


        public ActionResult ListarCategoria()
        {
            List<DtoCategoria> colCategoria = new List<DtoCategoria>();
            colCategoria = HCategoria.getInstace().GetCategoria();
            return View(colCategoria);
        }

        public ActionResult RemoveCategoria(int id)
        {
            HCategoria.getInstace().RemoveCategoria(id);
            return RedirectToAction("ListarCategoria");
        }


        public ActionResult ConfirmarCambios(DtoCategoria dtoCat)
        {
            HCategoria.getInstace().ModificarCategoria(dtoCat);
            return RedirectToAction("ListarCategoria");

        }


        //Vista formulario a modificar.
        public ActionResult ModificarCategoria(int id)
        {
            DtoCategoria cateFB = new DtoCategoria();

            cateFB = HCategoria.getInstace().GetCategoriaM(id);

            return View(cateFB);
        }

    }
}