using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class User
    {

        public static Entidades.User Authentication(Entidades.User UserInstance)
        {
            return Models.User.Authentication(UserInstance);
        }

        public static Entidades.User[] Lista()
        {
            return Models.User.Lista();
        }

        public static Entidades.User Guardar(Entidades.User UserInstance)
        {
            return Models.User.Guardar(UserInstance);
        }

        public static bool Eliminar(int id)
        {
            return Models.User.Eliminar(id);
        }

        public static Entidades.User Obtener(int id)
        {
            return Models.User.Get(id);
        }
    }
}
