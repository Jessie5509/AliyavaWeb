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
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetallePedidos(int id)
        {
            List<DtoDetallePedido> colDetallesByPedido = HPedido.getInstace().GetDetallePedido(id);
            return View(colDetallesByPedido);

        }

        public ActionResult PrepararPedidosV(int id)
        {
            List<DtoProducto> colProPreparar = HProducto.getInstace().GetProPreparar(id);
            List<DtoProducto> colProSinRemove = HProducto.getInstace().GetProPreparar(id);
            Session["colProPreparar"] = colProPreparar;
            Session["colProSinRemove"] = colProSinRemove;
            return View(colProPreparar);

        }

        public ActionResult ConfirmarPreparación(int id, int cantP)
        {
            List<DtoProducto> colProPreparar = (List<DtoProducto>)Session["colProPreparar"];
            HPedido.getInstace().ConfirmarProPre(id, cantP, colProPreparar);
          
            return RedirectToAction("ListaProPrep");

        }

        public ActionResult ListaProPrep()
        {
            List<DtoProducto> colProPreparar = (List<DtoProducto>)Session["colProPreparar"];
            return View(colProPreparar);
        }


        public ActionResult ConfirmarPedido()
        {
            List<DtoProducto> colProSinRemove = (List<DtoProducto>)Session["colProSinRemove"];
            List<DtoProducto> colProPreparar = (List<DtoProducto>)Session["colProPreparar"];
            if (colProPreparar.Count == 0)
            {
                HPedido.getInstace().CambiarEstadoPedido(colProSinRemove);
                return View("ListarPedidoUrgente");
            }
            else 
            {
                TempData["ErrorPedido"] = "¡Error, faltan pedidos por confirmar!";

                return RedirectToAction("MsgConfirmarPedido");
            }

          
        }

        public ActionResult MsgConfirmarPedido()
        {
            if (TempData["ErrorPedido"] != null)
            {
                ViewBag.ErrorPedido = TempData["ErrorPedido"].ToString();

            }

            return View();
        }

        public ActionResult ListarPedidoUrgente()
        { 
            List<DtoPedido> colPedidosUrg = HPedido.getInstace().GetPedidoUrg();
            return View(colPedidosUrg);   
        }

        public ActionResult ListarPedidosNoUrgentes()
        {
            List<DtoPedido> colPedidos = HPedido.getInstace().GetPedido();
            return View(colPedidos);
        }


    }
}