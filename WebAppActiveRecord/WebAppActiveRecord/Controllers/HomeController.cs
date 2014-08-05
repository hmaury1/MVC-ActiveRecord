using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppActiveRecord.Models;
using Castle.ActiveRecord;

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
            return View("Login",new User());
        }

        [AllowAnonymous]
        public ActionResult Authentication(User user)
        {
            User auth = user.Authentication();
            if (auth != null) {
                return View("Index");
            } else {
                return View("Login",user);
            }
        }

        public JsonResult Hola() {
            return Json(new {value = "Hola, todo bien" },JsonRequestBehavior.AllowGet);
        }
        
    }
}
