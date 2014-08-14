using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class Util
    {
        public static void Initialize()
        {
            ActiveRecordStarter.Initialize();
        }
    }
}
