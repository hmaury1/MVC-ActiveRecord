using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppActiveRecord.Models;
using Castle.ActiveRecord;


namespace WebAppActiveRecord.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        #region Con Razor
        public ActionResult Index()
        {
            var UserList = ActiveRecordBase<User>.FindAll().ToList();
            return View("Index", UserList);
        }

        public ActionResult Save(User UserInstance)
        {
            if (UserInstance.IsValid())
            {
                UserInstance.Save();
                return Index();
            }
            else
            {
                return View("Edit", UserInstance);
            }

        }

        public ActionResult Edit(int id)
        {
            // comment
            User UserInstance = null;
            if (id == 0)
            {
                UserInstance = new User();
            }
            else
            {
                UserInstance = ActiveRecordBase<User>.Find(id);
            }

            return View(UserInstance);
        }

        public ActionResult Delete(int id)
        {
            var UserInstance = ActiveRecordBase<User>.Find(id);
            UserInstance.Delete();
            return Index();
        }

        public JsonResult Encode(int id)
        {
            var UserInstance = ActiveRecordBase<User>.Find(id);
            return Json(UserInstance, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Con Extjs

        public JsonResult Obtener() {
            var UserList = ActiveRecordBase<User>.FindAll().ToList();
            return Json(new { users = UserList },JsonRequestBehavior.AllowGet);
        }

        public ActionResult Guardar(User UserInstance)
        {
            User user = UserInstance.Id == 0 ? UserInstance : ActiveRecordBase<User>.Find(UserInstance.Id);
            user.setProperties(UserInstance);

            if (user.IsValid())
            {
                user.Save();
                return Json(new { success=true, msg="Guardado correctamente"});
            }
            else
            {
                return Json(new { success = false, msgs = user.ValidationErrorMessages[0].ToString(), errors = UserInstance.ValidationErrorMessages });
            }

        }

        public ActionResult Eliminar(User UserInstance)
        {
            UserInstance.Delete();
            return Json(new { success = true, msg = "Eliminado correctamente" });
        }

        #endregion
    }
}
