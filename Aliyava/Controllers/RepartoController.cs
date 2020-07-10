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

       
        [HttpPost]
        public ActionResult AddReparto(DtoReparto nuevoReparto)
        {
            HReparto.getInstace().AddReparto(nuevoReparto);
            //ViewBag.Message = "Reparto agregado satisfactoriamente!";
            return RedirectToAction("RegistroReparto");
        }

        public ActionResult ListadoRepartos()
        {
            List<DtoReparto> colDtoReparto = new List<DtoReparto>();
            colDtoReparto = HReparto.getInstace().GetRepartosEnDefinición();
            return View(colDtoReparto);
        }

        public ActionResult EliminarReparto(int id)
        {
            HReparto.getInstace().EliminarRepartoById(id);
            return RedirectToAction("ListadoRepartos");
        }

        public ActionResult PedidosEnDespacho(int id)
        {
            Session["IdReparto"] = id;
            List<DtoPedido> colDtoPedido = new List<DtoPedido>();
            colDtoPedido = HReparto.getInstace().GetPedidosEnDespacho(id);
            return View(colDtoPedido);
        }

        public ActionResult AsignarPedido(int idP)
        {
            string NombreUsu = Session["NombreDeUsuario"].ToString();
            int idR = (int)Session["IdReparto"];
            HReparto.getInstace().AsignarPedido(idP, idR, NombreUsu);
            return RedirectToAction("ListadoRepartos");
        }

    }
}