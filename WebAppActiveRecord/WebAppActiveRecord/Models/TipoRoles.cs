using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using Castle.Components.Validator;
using System.Web.Script.Serialization;
using System.Collections;

namespace WebAppActiveRecord.Models
{
    
    [ActiveRecord(Table = "tipo_roles", Schema = "test")]
    public class TipoRoles : ActiveRecordValidationBase<TipoRoles>
    {
        private int id;
        private string descripcion;
        private bool estado;
        private IList roles = new ArrayList();

        [PrimaryKey(PrimaryKeyType.Native)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Property]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [Property]
        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        [HasMany(typeof(Rol), Table = "roles", ColumnKey = "tipo"), ScriptIgnore]
        public IList Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public string RolesList {
            get {
                string lista = "";
                foreach (Rol rol in this.Roles)
                {
                    lista += rol.Descripcion + " - ";
                }
                return lista;
            }
        }

    }
}