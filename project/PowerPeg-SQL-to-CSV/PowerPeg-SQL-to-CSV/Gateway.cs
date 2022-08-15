using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

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

        public string createConnectionString()
        {
            // TODO -- location
            return "Server=" + this.address + ";Database=" + this.catalog + ";Trusted_Connection=True; User Id="+ this.username +";Password=" + this.password +";";
        }

        public bool updateGateway(string newAddress, string newCatalog, string newUsername, string newPassword)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            configuration.AppSettings.Settings["Address"].Value = newAddress;
            configuration.AppSettings.Settings["Catalog"].Value = newCatalog;
            configuration.AppSettings.Settings["Username"].Value = newUsername;
            configuration.AppSettings.Settings["Password"].Value = newPassword;

            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");

            setGateway();

            return isServerConnected(createConnectionString());
        }

        public string[] getGatewayInfo()
        {
            string[] currentSetting = { this.address, this.catalog, this.username, this.password };
            return currentSetting;
        }

        private bool isServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public DataTable runSQLCommand(string storedCmdName)
        {
            string connectionString = createConnectionString();

            DataTable dt;

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedCmdName, sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        dt = new DataTable();

                        da.Fill(dt);
                    }
                }
            }

            return dt;
        }

        public List<string> getDBTableColName()
        {
            //Use the stored cmd
            DataTable d = runSQLCommand("sp_gateway_get_table_1_col");

            List<string> result = datatableToString1DList(d);

            return result;
        }

        public List<string> datatableToString1DList(DataTable d)
        {
            List<string> result = new List<string>();

            foreach (DataRow dr in d.Rows)
            {
                //Debug.Write(dr[0]);
                result.Add(dr[0].ToString());
            }

            return result;
        }

        public DataTable getDBTable01()
        {
            //Use the stored cmd
            DataTable d = runSQLCommand("sp_gateway_get_table_1_col");

            return d;
        }

        public void printDataTable(DataTable dt)
        {
            foreach (DataRow dataRow in dt.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Debug.Write(item + "\t");
                }
                Debug.WriteLine("");
            }
        }
    }

}
