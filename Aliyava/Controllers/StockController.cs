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
        public ActionResult SumaStock(DtoStock stock)
        {
            string NombreUsu = Session["NombreDeUsuario"].ToString();
       
            HStock.getInstace().SumStock(stock, NombreUsu);
            return RedirectToAction("AddStock");
        }

        public ActionResult ListarStock()
        {
            List<DtoStock> colStock = new List<DtoStock>();
            colStock = HStock.getInstace().GetAllStock();
            return View(colStock);
        }


        public ActionResult HistoricoStockV()
        { 
            List<DtoHistoricoStock> colStockH = new List<DtoHistoricoStock>();
            colStockH = HStock.getInstace().GetStock();

            return View(colStockH);
        }

    }
}