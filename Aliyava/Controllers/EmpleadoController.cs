﻿using BussinesLogic.Helpers;
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
            //ViewBag.Message = null;
            return View();
        }

        [HttpPost]
        public ActionResult AddEmpleado(DtoEmpleado nuevoEmpleado)
        {
            HEmpleado.getInstace().AddEmpleado(nuevoEmpleado);
            ViewBag.Message = "Empleado registrado satisfactoriamente!";
            return RedirectToAction("RegistroEmpleado");
        }

    }
}