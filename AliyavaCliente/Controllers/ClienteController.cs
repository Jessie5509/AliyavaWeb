using AliyavaCliente.Helpers;
using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AliyavaCliente.Controllers
{
    //[UserAuthentication]
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegistroCliente()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();

            }

            return View();
        }

        [HttpPost]
        public ActionResult AddCliente(DtoCliente nuevoCliente)
        {
            bool msg = HCliente.getInstace().AddCliente(nuevoCliente);

            if (msg == true)
            {
                TempData["Message"] = "Registrado satisfactoriamente!";
            }
            else
            {
                TempData["Message"] = "Completa todos los campos por favor!";
            }

            return RedirectToAction("RegistroCliente");
        }

        public ActionResult PerfilV()
        {
            string password = Session["Contraseña"].ToString();
            bool existeDir = false;
            Session["existeDir"] = existeDir;
            DtoCliente clienteDB = new DtoCliente();
            clienteDB = HCliente.getInstace().GetDataCliente(password, out existeDir);

            if (existeDir == true)
            {
                TempData["Message"] = existeDir;
            }
            else 
            {
                TempData["Message"] = existeDir;
            }

            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();

            }

            return View(clienteDB);
       
        }

        public ActionResult DireccionForm(string nombreD)
        {
            string password = Session["Contraseña"].ToString();
            DtoDirecciones clienteDB = new DtoDirecciones();
            clienteDB = HCliente.getInstace().getNombreD(password, nombreD);

            return View(clienteDB);
        }

        public ActionResult DireccionFormAdd()
        {
        
            return View();
        }

        public ActionResult AddDireccion(DtoDirecciones nuevaDireccion)
        {
            string password = Session["Contraseña"].ToString();
            HCliente.getInstace().AddDireccion(nuevaDireccion, password);
            return RedirectToAction("ListarDirecciones");
        }

    

        public ActionResult ListarDirecciones()
        {
            string password = Session["Contraseña"].ToString();
            List<DtoDirecciones> colDirecciones = new List<DtoDirecciones>();
            colDirecciones = HCliente.getInstace().GetDirecciones(password);
            return View(colDirecciones);
        }

        public ActionResult EliminarDireccion(int id)
        {
            HCliente.getInstace().EliminarDireccion(id);
            return RedirectToAction("ListarDirecciones");
        }

        public ActionResult ConfirmarCambios(DtoCliente dtoCli)
        {
            HCliente.getInstace().ModificarPerfil(dtoCli);
            return RedirectToAction("PerfilV");

        }





    }
}