﻿using BussinesLogic.Helpers;
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
            HStock.getInstace().AddStock(stock);
            return RedirectToAction("AddStock");
        }



    }
}