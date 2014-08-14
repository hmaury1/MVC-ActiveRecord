using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebAppActiveRecord.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        #region Con Razor
        public ActionResult Index()
        {
            var UserList = Aplicacion.User.Lista();
            return View("Index", UserList);
        }

        public ActionResult Save(Entidades.User UserInstance)
        {
            try
            {
                Aplicacion.User.Guardar(UserInstance);
                return Index();
            }
            catch (Exception e)
            {
                this.ViewData.Add("MsgError", e.Message);
                return View("Edit", UserInstance);
            }
        }

        public ActionResult Edit(int id)
        {
            Entidades.User UserInstance = null;
            if (id == 0)
            {
                UserInstance = new Entidades.User();
            }
            else
            {
                UserInstance = Aplicacion.User.Obtener(id);
            }

            return View(UserInstance);
        }

        public ActionResult Delete(int id)
        {
            Aplicacion.User.Eliminar(id);
            return Index();
        }
        #endregion
        
        #region Con Extjs

        public JsonResult Obtener() {
            var UserList = Aplicacion.User.Lista();
            return Json(new { users = UserList },JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Guardar(Entidades.User UserInstance)
        {
            try
            {
                Aplicacion.User.Guardar(UserInstance);
                return Json(new { success = true, errors = ""});
            }
            catch (Exception e)
            {
                return Json(new { success = false, errors = e.Message});
            }
        }
        
        public ActionResult Eliminar(Entidades.User UserInstance)
        {
            Aplicacion.User.Eliminar(UserInstance.Id);
            return Json(new { success = true, msg = "Eliminado correctamente" });
        }
        
        #endregion
        
    }
}
