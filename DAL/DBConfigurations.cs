using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace DAL
{
    public static class DBConfigurations
    {
        public static string getDbConectionString()
        {
            return ConfigurationManager.ConnectionStrings["dbconection"].ConnectionString;

        }
    }
}
