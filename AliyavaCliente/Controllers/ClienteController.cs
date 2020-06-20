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

            return View();
        }

        [HttpPost]
        public ActionResult AddCliente(DtoCliente nuevoCliente)
        {
            HCliente.getInstace().AddCliente(nuevoCliente);
            return RedirectToAction("RegistroCliente");
        }

        public ActionResult PerfilV()
        {

            return View();
        }

        public ActionResult PerfilCliente()
        {
            string password = Session["Contraseña"].ToString();
            HCliente.getInstace().GetDataCliente();

            return RedirectToAction("PerfilV");
        }



        //public void AddReserva(DtoReserva nuevaReserva)
        //{
        //    using (HotelEntities context = new HotelEntities())
        //    {
        //        Reserva ingresoReserva = new Reserva();
        //        ingresoReserva.cantidadDias = nuevaReserva.cantDias;
        //        ingresoReserva.fechaIngreso = nuevaReserva.fechaIngreso;
        //        ingresoReserva.nombreCliente = nuevaReserva.nombreCliente;
        //        ingresoReserva.documentoCliente = nuevaReserva.documentoCliente;

        //        context.Reserva.Add(ingresoReserva);
        //        context.SaveChanges();

        //        foreach (DtoDetalleReserva dto in nuevaReserva.colDetalle)
        //        {
        //            DetalleReserva ingresoDetalleReserva = new DetalleReserva();
        //            ingresoDetalleReserva.idHabitacion = dto.idHabitacion;
        //            ingresoDetalleReserva.observaciones = dto.observaciones;
        //            ingresoDetalleReserva.numReserva = ingresoReserva.numReserva;

        //            context.DetalleReserva.Add(ingresoDetalleReserva);
        //            context.SaveChanges();
        //        }

        //    }
        //}


    }
}