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
        public ActionResult CrearStockV()
        {

            return View();
        }

        //Crea nuevo stock.
        public ActionResult CrearStock(DtoStock stock)
        {
            HStock.getInstace().CreateStock(stock);
            return RedirectToAction("Home");
        }

        //Agrega mas cantidad de stock.
        public ActionResult SumaStock(DtoStock stock)
        {
            HStock.getInstace().SumStock(stock);
            return RedirectToAction("AddStock");
        }

        //Quita cantidad de stock.
        public ActionResult BajaStock(DtoStock stock)
        {
            HStock.getInstace().BajaStock(stock);
            return RedirectToAction("AddStock");
        }



    }
}