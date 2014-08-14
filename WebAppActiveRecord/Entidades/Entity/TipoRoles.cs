using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Entidades
{
    
    public class TipoRoles
    {
        private int id;
        private string descripcion;
        private bool estado;
        private IList roles = new ArrayList();
       
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

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