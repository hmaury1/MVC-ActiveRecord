using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using Castle.Components.Validator;
using System.Collections;
using Omu.ValueInjecter;

namespace Models
{
    
    [ActiveRecord(Table = "tipo_roles", Schema = "test")]
    public class TipoRoles : ActiveRecordValidationBase<TipoRoles>
    {
        private int id;
        private string descripcion;
        private bool estado;
        private IList roles = new ArrayList();

        public TipoRoles()
        {
           
        }
        
        public TipoRoles(string descripcion, bool estado)
        {
            // TODO: Complete member initialization
            this.descripcion = descripcion;
            this.estado = estado;
        }



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

        [HasMany(typeof(Rol), Table = "roles", ColumnKey = "tipo", Cascade=ManyRelationCascadeEnum.All )]
        public IList Roles
        {
            get { return (from r in (List<Rol>) roles select (Entidades.Rol)new Entidades.Rol().InjectFrom(r)).ToList(); }
            set { roles = (from r in (List<Entidades.Rol>)value select (Models.Rol) new Models.Rol().InjectFrom(r)).ToList(); }
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