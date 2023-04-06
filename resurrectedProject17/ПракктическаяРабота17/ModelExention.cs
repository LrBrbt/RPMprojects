using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПракктическаяРабота17
{
    public partial class lab17Entities : DbContext
    {
        private static lab17Entities context; //статичная ссылка на контент

        public static lab17Entities GetContext()
        {
            if (context == null)
            {
                context = new lab17Entities();
            }
            return context;
        }
    }
}
