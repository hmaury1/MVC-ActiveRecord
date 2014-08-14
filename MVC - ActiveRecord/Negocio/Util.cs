using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public static class Util
    {
        public static T setProperties<T>(T instance, object obj){
            
            foreach (var property in typeof(T).GetProperties())
            {
                var t = obj.GetType().GetProperty(property.Name);
                if (t != null)
                {
                    property.SetValue(instance, t);
                }
            }
            return instance;

        }
    }
}
