using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PowerPeg_SQL_to_CSV
{
    public sealed class Gateway
    {
        private Gateway()
        {
            setGateway();
        }

        private static Gateway _instance;
        private static readonly object _lock = new object();

        public static Gateway getInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Gateway();
                    }
                }
            }
            return _instance;
        }

        private string address;
        private string catalog;
        private string username;
        private string password;
        
        public void setGateway()
        {
            this.address = ConfigurationManager.AppSettings["Address"];
            this.catalog = ConfigurationManager.AppSettings["Catalog"];
            this.username = ConfigurationManager.AppSettings["Username"];
            this.password = ConfigurationManager.AppSettings["Password"];

        }

        public void updateGateway(String a, String c, String u, String p)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            
            configuration.AppSettings.Settings["Address"].Value = a;
            configuration.AppSettings.Settings["Catalog"].Value = c;
            configuration.AppSettings.Settings["Username"].Value = u;
            configuration.AppSettings.Settings["Password"].Value = p;

            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");

            setGateway();

            //Update connection
        }

        public string[] getGatewayInfo()
        {
            string[] currentSetting = {this.address, this.catalog, this.username, this.password};
            return currentSetting;
        }
    }

}
