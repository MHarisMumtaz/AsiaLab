using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AsiaLabv1.Repositories
{
    public class StaticDbContext
    {
        protected static AsiaLabdb2Entities Context = new AsiaLabdb2Entities();
        public static AsiaLabdb2Entities context
        {
            get
            {
                return Context;
            }
        }
    }
}