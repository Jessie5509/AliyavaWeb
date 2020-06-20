using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AliyavaCliente.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult LoginV()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                return Redirect("/Home");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            //SignOut() Limpia la Cookie de Autenticación
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("LoginV");
        }

   
        public ActionResult Login(DtoCliente dto)
        {
            if (dto.NombreUsuario == "jessi" && dto.contraseña == "1234")
            {
                //Crea la Cookie para que el usuario sea autenticado
                FormsAuthentication.SetAuthCookie(dto.NombreUsuario, false);
                Session["NombreDeUsuario"] = dto.NombreUsuario;
                Session["Contraseña"] = dto.contraseña;

                return Redirect("/Home");
            }

            return View();
        }
    }
}