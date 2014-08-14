using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppActiveRecord.Controllers
{
    [LogonAuthorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ES1000()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login() {
            return View("Login", new Entidades.User());
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Authentication(Entidades.User UserInstance)
        {
            UserInstance = Aplicacion.User.Authentication(UserInstance);
            if (UserInstance.Id != 0)
            {
                Session["user"] = UserInstance;
                return Redirect("/Home");
            } else {
                this.ViewData.Add("MsgError", "Usuario o contraseña incorrecto!!!");
                return View("Login", UserInstance);
            }
        }
    }
}
