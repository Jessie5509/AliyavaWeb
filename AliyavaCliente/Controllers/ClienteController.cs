using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AliyavaCliente.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistroCliente()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCliente(DtoCliente nuevoCliente)
        {
            HCliente.getInstace().AddCliente(nuevoCliente);
            return RedirectToAction("RegistroCliente");
        }

        public ActionResult LoginCliente()
        {

            return View();
        }

    }
}