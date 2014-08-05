using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppActiveRecord.Models;
using Castle.ActiveRecord;

namespace WebAppActiveRecord.Controllers
{
    public class RolController : Controller
    {
        //
        // GET: /Rol/

        public JsonResult Index()
        {
            var RolInstance = new Rol();
            RolInstance.Estado = true;
            RolInstance.Descripcion = "Public";
            var tipo = ActiveRecordBase<TipoRoles>.Find(2);
            RolInstance.Tipo = tipo;
            RolInstance.Save();
            return Json(RolInstance,JsonRequestBehavior.AllowGet);
        }

        public JsonResult RolesPorTipo()
        {
            var TipoRolInstance = ActiveRecordBase<TipoRoles>.Find(2);
            return Json(TipoRolInstance, JsonRequestBehavior.AllowGet);
        }

    }
}
