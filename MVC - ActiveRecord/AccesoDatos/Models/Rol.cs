using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using Castle.Components.Validator;

namespace Models
{
    [ActiveRecord(Table = "roles", Schema = "test")]
    public class Rol : ActiveRecordValidationBase<Rol>
    {
        private int id;
        private string descripcion;
        private bool estado;
        private TipoRoles tipo;
       
        public Rol(string descripcion, bool estado)
        {
            this.descripcion = descripcion;
            this.estado = estado;
            
        }

        public Rol()
        {
            // TODO: Complete member initialization
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

        [BelongsTo("tipo",NotNull = false)]
        public TipoRoles Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

    }
}