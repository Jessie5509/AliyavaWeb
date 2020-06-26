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
            List<DtoProducto> colProducto = new List<DtoProducto>();
            DtoProducto producto = new DtoProducto();
            producto = HProducto.getInstace().GetProductoCarrito(id);

            colProducto.Add(producto);

            //ViewBag.colPro = colProducto;
            Session["colProductos"] = colProducto;

            return View(colProducto);
        }

        public ActionResult RealizarPedido(List<DtoProducto> colProductosPedidos, bool urgente)
        {
            //Alta pedido, detalle pedido, reserva y baja del stock, cambio del estado y ver historico de estados.
            string NombreUsu = Session["NombreDeUsuario"].ToString();
            string password = Session["Contraseña"].ToString();
     
            HPedido.getInstace().AddPedido(colProductosPedidos, NombreUsu, password, urgente);


            return View();
        }

    }
}