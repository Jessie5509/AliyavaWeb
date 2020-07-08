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

        public ActionResult ReporteProMasVendido()
        {
            List<DtoReporteMasVendido> colProd1 = new List<DtoReporteMasVendido>();
            colProd1 = HReporte.getInstace().GetReporte1();

            return View(colProd1);
        }


    }
}