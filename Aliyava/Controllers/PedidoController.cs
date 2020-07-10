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
            string NombreUsu = Session["NombreDeUsuario"].ToString();
            List<DtoProducto> colProPreparar = HProducto.getInstace().GetProPreparar(id, NombreUsu);
            Session["colProPreparar"] = colProPreparar;
            Session["idPedido"] = id;
            return View(colProPreparar);

        }

        public ActionResult ConfirmarPreparación(int id)
        {
            List<DtoProducto> colProPreparar = (List<DtoProducto>)Session["colProPreparar"];
            HPedido.getInstace().ConfirmarProPre(id, colProPreparar);
          
            return RedirectToAction("ListaProPrep");

        }

        public ActionResult ListaProPrep()
        {
            List<DtoProducto> colProPreparar = (List<DtoProducto>)Session["colProPreparar"];
            return View(colProPreparar);
        }


        public ActionResult ConfirmarPedido()
        {
            int idPedido = (int)Session["idPedido"];
            List<DtoProducto> colProPreparar = (List<DtoProducto>)Session["colProPreparar"];
            string NombreUsu = Session["NombreDeUsuario"].ToString();
            if (colProPreparar.Count == 0)
            {
                HPedido.getInstace().CambiarEstadoPedido(idPedido, NombreUsu);
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

        public ActionResult HistoricoEstado(int id)
        {
            List<DtoHistoricoEstado> colHisEstado = HPedido.getInstace().GetHisEstado(id);
            return View(colHisEstado);
        }

        public ActionResult TodosLosPedidos()
        {
            List<DtoPedido> colPed = HPedido.getInstace().GetAllPedidos();
            return View(colPed);
        }

    }
}