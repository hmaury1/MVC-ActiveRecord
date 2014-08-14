using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class Rol 
    {
        private int id;
        private string descripcion;
        private bool estado;
        private TipoRoles tipo;
       
        
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

        public TipoRoles Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

    }
}