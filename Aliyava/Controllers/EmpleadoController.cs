using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aliyava.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistroEmpleado()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();

            }
            
            return View();
        }

        [HttpPost]
        public ActionResult AddEmpleado(DtoEmpleado nuevoEmpleado)
        {
            bool msg = HEmpleado.getInstace().AddEmpleado(nuevoEmpleado);

            if (msg == true)
            {
                TempData["Message"] = "Empleado registrado satisfactoriamente!";
            }
            else
            {
                TempData["Message"] = "Completa todos los campos por favor!";
            }

            return RedirectToAction("RegistroEmpleado");
        }

    }
}