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
        string connectionString;

        public void setGateway()
        {
            this.address = ConfigurationManager.AppSettings["Address"];
            this.catalog = ConfigurationManager.AppSettings["Catalog"];
            this.username = ConfigurationManager.AppSettings["Username"];
            this.password = ConfigurationManager.AppSettings["Password"];

            this.connectionString = createConnectionString(this.address, this.catalog, this.username, this.password);
        }

        public string createConnectionString(string address, string catalog, string username, string password)
        {
            // TODO -- location
            return "Server=" + address + ";Database=" + catalog + ";Trusted_Connection=True; User Id="+ username +";Password=" + password +";";
        }

        public bool updateGateway(string newAddress, string newCatalog, string newUsername, string newPassword)
        {
            if(isServerConnected(createConnectionString(newAddress, newCatalog, newUsername, newPassword))){
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

        public List<string> getDBTableColName()
        {
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
                //Debug.Write(dr[0]);
                result.Add(dr[0].ToString());
            }

            return result;
        }

        private string createSelectColString(List<string> selectColumn)
        {
            string output = "";
            if(selectColumn.Contains("*")){
                return "*";
            }
            else
            {
                return "[" + string.Join("],[", selectColumn) + "]";
            }
        }

        public DataTable getDBTable01(DateOnly startSearchDay, DateOnly endSearchDay, List<string> selectColumn)
        {
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
