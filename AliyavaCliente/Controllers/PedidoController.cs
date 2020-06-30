using AliyavaCliente.Helpers;
using BussinesLogic.Helpers;
using Common.DTO;
using System;
using System.Collections.Generic;
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

            DtoProducto producto = new DtoProducto();
            producto = HProducto.getInstace().GetProductoCarrito(id);
            colProducto.Add(producto);
            Session["colProductos"] = colProducto;


            return RedirectToAction("Index", "Home");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RealizarPedido(FormCollection form, bool ChkUrgente)
        {
            ViewData["ChkUrgente"] = ChkUrgente;
        
            //Alta pedido, detalle pedido, reserva y baja del stock, cambio del estado y ver historico de estados.
            string NombreUsu = Session["NombreDeUsuario"].ToString();
            string password = Session["Contraseña"].ToString();
            List<DtoProducto> colProductosPedidos = (List<DtoProducto>)Session["colProductos"];

            HPedido.getInstace().AddPedido(colProductosPedidos, NombreUsu, password, ChkUrgente);


            return View();
        }

    }
}