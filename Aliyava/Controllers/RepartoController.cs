using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aliyava.Controllers
{
    public class RepartoController : Controller
    {
        // GET: Reparto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistroReparto()
        {
       
            return View();
        }

        //Agregar el listado de pedidos en despacho y que se puedan asignar al reparto.
        [HttpPost]
        public ActionResult AddReparto(DtoReparto nuevoReparto)
        {
            HReparto.getInstace().AddReparto(nuevoReparto);
            ViewBag.Message = "Reparto agregado satisfactoriamente!";
            return RedirectToAction("RegistroReparto");
        }

    }
}