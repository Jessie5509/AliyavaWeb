using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AliyavaCliente.Helpers
{
    public class UserAuthentication : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //string nombreUsuario = httpContext.Session["NombreDeUsuario"].ToString();
            return base.AuthorizeCore(httpContext);

  
        }

    }
}