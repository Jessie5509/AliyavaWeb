using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aliyava.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Reportes()
        {
            return View();
        }

        public ActionResult MapaTermico()
        {
            List<decimal> colLat = HReporte.getInstace().getLatEntregado();
            List<decimal> colLng = HReporte.getInstace().getLngEntregado();
            TempData["ColLat"] = colLat;
            TempData["ColLng"] = colLng;

            //ViewBag.ColLat = TempData["ColLat"].ToString();
            //ViewBag.ColLng = TempData["ColLng"].ToString();

            return View();
        }

        public ActionResult ReporteProMasVendido()
        {
            List<DtoReporteMasVendido> colProd1 = new List<DtoReporteMasVendido>();
            colProd1 = HReporte.getInstace().GetReporte1();

            return View(colProd1);
        }

        public ActionResult ReportePromedioEntrega()
        {

            
            return View();
        }
        public ActionResult ReportePromedioEntrega1(DateTime fecha1,DateTime fecha2 )
        {

            double promedio = 0;
            promedio = HReporte.getInstace().GetReporte2(fecha1, fecha2);

            TempData["Promedio"] = promedio;
            return RedirectToAction("ReportePromedioEntrega");
        }
        
        public ActionResult ReporteVolumenPedidodia()
        {

            List<DtoReporteVolumenPedidodia> colProd3 = new List<DtoReporteVolumenPedidodia>();
            colProd3 = HReporte.getInstace().GetReporte3();


            return View(colProd3);
        }


    }
}