using AliyavaCliente.Helpers;
using BussinesLogic.Helpers;
using Common.DTO;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AliyavaCliente.Controllers
{
    [UserAuthentication]
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CarritoView()
        {
            
            return View(Session["colProductos"]);
        }
        public ActionResult CarritoV(int id)
        {
            List<DtoProducto> colProducto = null;
            if (Session["colProductos"] == null)
            {
                colProducto = new List<DtoProducto>();
            }
            else {
                colProducto = (List<DtoProducto>)Session["colProductos"];

            }
            Session["stockOk"] = true;
            bool stockOk = (bool)Session["stockOk"];

            DtoProducto producto = new DtoProducto();
            producto = HProducto.getInstace().GetProductoCarrito(id, out stockOk, colProducto);

            Session["stockOk"] = stockOk;

            if (stockOk == false && colProducto.Count != 0)
            {
                TempData["ErrorStock"] = "¡No queda más stock de este producto!";

                return RedirectToAction("MsgStock");
            }
            else
            {


                if (colProducto.Count == 0)
                {
                    colProducto.Add(producto);
                }
                else
                {
                    bool existe = false;

                    foreach (DtoProducto item in colProducto)
                    {
                        if (item.Codigo == producto.Codigo)
                        {
                            item.CantidadPreparar++;
                            existe = true;
                            break;
                        }

                    }

                    if (existe == false)
                    {
                        colProducto.Add(producto);
                    }
                }

                Session["colProductos"] = colProducto;
                return RedirectToAction("Index", "Home");
            }

            
        }

        public ActionResult MsgStock()
        {
            if (TempData["ErrorStock"] != null)
            {
                ViewBag.ErrorStock = TempData["ErrorStock"].ToString();

            }

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RealizarPedido(FormCollection form, bool ChkUrgente)
        {
            ViewData["ChkUrgente"] = ChkUrgente;
        
            //Alta pedido, detalle pedido, reserva y baja del stock, cambio del estado y ver historico de estados.
            string NombreUsu = Session["NombreDeUsuario"].ToString();
            string password = Session["Contraseña"].ToString();
            List<DtoProducto> colProductosPedidos = (List<DtoProducto>)Session["colProductos"];

            bool error = HPedido.getInstace().AddPedido(colProductosPedidos, NombreUsu, password, ChkUrgente);

            if (error)
            {
                TempData["Pedido"] = "Debe ingresar su teléfono y dirección!";
                return RedirectToAction("MsgErrorPedido");
            }
    
            return RedirectToAction("ListadoPedidosCli");
        }

        public ActionResult MsgErrorPedido()
        {
            if (TempData["Pedido"] != null)
            {
                ViewBag.Pedido = TempData["Pedido"].ToString();

            }

            return View();
        }

        public ActionResult ListadoPedidosCli()
        {
            string NombreUsu = Session["NombreDeUsuario"].ToString();
            List<DtoPedido> colPedidosCli = HPedido.getInstace().GetPedidoCli(NombreUsu);
            return View(colPedidosCli);

        }

        public ActionResult ListadoPedidosCliEnPrep()
        {
            string NombreUsu = Session["NombreDeUsuario"].ToString();
            List<DtoPedido> colPedidosCli = HPedido.getInstace().GetPedidoCliPrep(NombreUsu);
            return View(colPedidosCli);

        }

        public ActionResult HistoricoEstado(int id)
        {
            List<DtoHistoricoEstado> colHisEstado = HPedido.getInstace().GetHisEstado(id);
            return View(colHisEstado);
        }

        public ActionResult DetallePedidosCli(int id)
        {
            List<DtoDetallePedido> colDetallesByPedido = HPedido.getInstace().GetDetallePedido(id);
            return View(colDetallesByPedido);
        }

        public ActionResult CancelarPedido(int idPedido)
        {
            string NombreUsu = Session["NombreDeUsuario"].ToString();
            HPedido.getInstace().CancelarPed(idPedido, NombreUsu);
            return RedirectToAction("ListadoPedidosCliEnPrep");
        }

        public ActionResult EliminarProCarrito(int cod)
        {
            List<DtoProducto> colPro = (List<DtoProducto>)Session["colProductos"];
            DtoProducto pro = null;
            bool existe = false;

            foreach (DtoProducto item in colPro)
            {
                if (item.Codigo == cod)
                {
                    if (item.CantidadPreparar > 1)
                    {
                        item.CantidadPreparar--;

                    }
                    else
                    {
                        existe = true;
                        pro = item;
                       
                    }
                

                }

            }

            if (existe)
            {
                colPro.Remove(pro);

            }

            return RedirectToAction("CarritoView");
        }

    }
}