using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppActiveRecord
{
    public sealed class LogonAuthorize : AuthorizeAttribute {
        public override void OnAuthorization(AuthorizationContext filterContext) {

            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)|| filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);

            if (!skipAuthorization) {
                if (filterContext.HttpContext.Session["user"] == null)
                {
                    var url = new UrlHelper(filterContext.RequestContext);
                    var logonUrl = url.Action("Login", "Home");
                    filterContext.Result = new RedirectResult(logonUrl);
                    //base.OnAuthorization(filterContext);
                }
            }
        }
    }
}