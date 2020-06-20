using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aliyava.Helpers
{
    public class UserAuthentication : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
          
            return base.AuthorizeCore(httpContext);


        }
    }
}