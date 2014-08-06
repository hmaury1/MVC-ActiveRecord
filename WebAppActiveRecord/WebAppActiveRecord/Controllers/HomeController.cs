using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppActiveRecord.Models;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;

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

        [HttpPost, AllowAnonymous]
        public ActionResult Authentication(User UserInstance)
        {
            User user = new User();            
            SimpleQuery<User> q = new SimpleQuery<User>(@" from User u where u.Name = :name And u.Password = :password");
            q.SetParameter("name", UserInstance.Name);
            q.SetParameter("password", UserInstance.Password);
            var list = q.Execute().ToList();
            if (list.Count() > 0) {
                user = list[0];
            } else {
                user.MsgError = "Usuario o contraseña incorrecto";
            }

            if (user.Id != null && user.Id != 0) {
                Session["user"] = user;
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
