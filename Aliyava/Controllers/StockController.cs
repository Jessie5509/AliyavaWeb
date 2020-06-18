using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aliyava.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddStock()
        {

            return View();
        }

        public ActionResult AgregarStock(DtoStock stock)
        {
            //HStock.getInstace().AddCliente(stock);
            return RedirectToAction("AddStock");
        }

        public ActionResult BajaStock(DtoStock stock)
        {
            HStock.getInstace().BajaStock(stock);
            return RedirectToAction("AddStock");
        }



    }
}