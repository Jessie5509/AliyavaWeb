using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AliyavaCliente.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        public ActionResult Index()
        {

            List<DtoReporte1> colProd1 = new List<DtoReporte1>();
            colProd1 = HReporte.getInstace().GetReporte1();
            return View(colProd1);
            
        }




    }
}