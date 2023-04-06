using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace project17
{
    public partial class lab17Entities1 : DbContext
    {
        private static lab17Entities1 context; //статичная ссылка на контент

        public static lab17Entities1 GetContext()
        {
            if(context == null)
            {
                context = new lab17Entities1();
            }
            return context;
        }
    }
}
