using log4net;
using PowerPeg_SQL_to_CSV.Log;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PowerPeg_SQL_to_CSV.Gateway
{
    public sealed class DatabaseGateway
    {
        private DatabaseGateway()
        {
            setGateway();
        }

        private static DatabaseGateway _instance;
        private static readonly object _lock = new object();
        private static readonly ILog log = LogHelper.getLogger();

        public static DatabaseGateway getInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseGateway();
                    }
                }
            }
            return _instance;
        }

        private string address;
        private string catalog;
        private string username;
        private string password;
        string connectionString;

        public void setGateway()
        {
            address = ConfigurationManager.AppSettings["Address"];
            catalog = ConfigurationManager.AppSettings["Catalog"];
            username = ConfigurationManager.AppSettings["Username"];
            password = ConfigurationManager.AppSettings["Password"];

            connectionString = createConnectionString(address, catalog, username, password);

            log.Info($"Setup the Database gateway and create connection string: {connectionString}");
        }

        public string createConnectionString(string address, string catalog, string username, string password)
        {
            return "Server=" + address + ";Database=" + catalog + ";Trusted_Connection=True; User Id=" + username + ";Password=" + password + ";";
        }

        public bool updateGateway(string newAddress, string newCatalog, string newUsername, string newPassword)
        {
            log.Debug("Update gateway");

            if (isServerConnected(createConnectionString(newAddress, newCatalog, newUsername, newPassword)))
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                configuration.AppSettings.Settings["Address"].Value = newAddress;
                configuration.AppSettings.Settings["Catalog"].Value = newCatalog;
                configuration.AppSettings.Settings["Username"].Value = newUsername;
                configuration.AppSettings.Settings["Password"].Value = newPassword;

                configuration.Save(ConfigurationSaveMode.Full, true);
                ConfigurationManager.RefreshSection("appSettings");

                setGateway();

                return true;
            }
            else
            {
                return false;
            }
        }

        public string[] getGatewayInfo()
        {
            string[] currentSetting = { address, catalog, username, password };
            return currentSetting;
        }

        private bool isServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    log.Info("Able to connect to SQL server");
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    log.Error("Fail to connect to the SQL server");
                    return false;
                }
            }
        }

        public List<string> getDBTableColName()
        {
            log.Info("Request Database for Table column infomation.");

            //Use the stored procedure cmd
            DataTable sqlOutput;

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_gateway_get_table_1_col", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        sqlOutput = new DataTable();

                        da.Fill(sqlOutput);
                    }
                }
            }

            List<string> result = datatableToString1DList(sqlOutput);

            return result;
        }

        public List<string> datatableToString1DList(DataTable d)
        {
            List<string> result = new List<string>();

            foreach (DataRow dr in d.Rows)
            {
                result.Add(dr[0].ToString());
            }

            return result;
        }

        private string createSelectColString(List<string> selectColumn)
        {
            string output = "";
            if (selectColumn.Contains("*"))
            {
                return "*";
            }
            else
            {
                return "[" + string.Join("],[", selectColumn) + "]";
            }
        }

        public DataTable getDBTable01(DateTime startSearchDay, DateTime endSearchDay, List<string> selectColumn)
        {
            log.Info("Request Database for Table data.");

            //Use the stored procedure cmd
            DataTable sqlOutput;

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_gateway_search_table_1", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Change to sql itemes formate
                    cmd.Parameters.Add("@selectCol", SqlDbType.VarChar).Value = createSelectColString(selectColumn);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        sqlOutput = new DataTable();

                        da.Fill(sqlOutput);
                    }
                }
            }

            return sqlOutput;
        }
    }
}
