using log4net;
using PowerPeg_SQL_to_CSV.Log;
using System;
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
            this.selectedTableList = JSONGateway.getInstance().importTable();
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

        private string connectionString;
        private List<string> selectedTableList;

        public void setGateway()
        {
            this.connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            log.Info($"Setup the Database gateway: {this.connectionString}");
        }

        public bool updateGateway(string newConnectionString)
        {
            log.Debug("Update gateway");

            if (isServerConnected(this.connectionString))
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                configuration.AppSettings.Settings["ConnectionString"].Value = newConnectionString;

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

        /// <summary>
        /// Get the current connection information
        /// </summary>
        /// <returns>Return the value of "Address", "Catalog", "full string"</returns>
        public string[] getGatewayInfo()
        {

            SqlConnectionStringBuilder decoder = new SqlConnectionStringBuilder(this.connectionString);

            string[] currentSetting = { decoder.DataSource, decoder.InitialCatalog, this.connectionString };
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
                    log.Warn("Fail to connect to the SQL server");
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

            List<string> result = new List<string>();

            foreach (DataRow dr in sqlOutput.Rows)
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

        public List<string> getSelectedTable()
        {
            return this.selectedTableList;
        }

        public void setSelectedTable(List<string> tableName)
        {
            this.selectedTableList = tableName;
            JSONGateway.getInstance().updateTableJSON(tableName);
        }
    }
}
