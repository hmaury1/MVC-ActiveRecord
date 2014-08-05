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

        public ActionResult guardar(User UserInstance)
        {
            if (UserInstance.IsValid())
            {
                UserInstance.Save();
                return Json(new { success=true, msg="OK"  });
            }
            else
            {
                return Json(new { success = false, msg = UserInstance.ValidationErrorMessages[0].ToString() });
            }

        }

        // esto es un comentario!!!...

        #endregion
    }
}
