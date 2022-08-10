using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PowerPeg_SQL_to_CSV
{
    public static class Gateway
    {

        private static String address = ConfigurationManager.AppSettings["Address"];
        private static String catalog = ConfigurationManager.AppSettings["Catalog"];
        private static String username = ConfigurationManager.AppSettings["Username"];
        private static String password = ConfigurationManager.AppSettings["Password"];

        public static void initializeGateway()
        {
            

        }
    }
}
