using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Aplicacion
{
    public class User
    {
        public static Entidades.User Authentication(Entidades.User UserInstance)
        {
            Models.User userDal = new Models.User();
            return userDal.Authentication(UserInstance);
        }
    }
}
