using Aliyava.Helpers;
using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aliyava.Controllers
{
    [UserAuthentication]
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            return View();
        }

        //Vista de sumar y restar stock.
        public ActionResult AddStock()
        {

            return View();
        }

        //Vista de crear un nuevo stock.
        //public ActionResult CrearStockV()
        //{

        //    return View();
        //}

        //Crea nuevo stock.
        //public ActionResult CrearStock(DtoStock stock)
        //{
        //    HStock.getInstace().CreateStock(stock);
        //    return RedirectToAction("Home");
        //}

        //Agrega mas cantidad de stock.
        public ActionResult SumaStock(DtoStock stock, string codigoBarras)
        {
            HStock.getInstace().SumStock(stock, codigoBarras);
            return RedirectToAction("AddStock");
        }

        //Quita cantidad de stock.
        public ActionResult BajaStock(DtoStock stock, string codigoBarras)
        {
            HStock.getInstace().BajaStock(stock, codigoBarras);
            return RedirectToAction("AddStock");
        }



    }
}