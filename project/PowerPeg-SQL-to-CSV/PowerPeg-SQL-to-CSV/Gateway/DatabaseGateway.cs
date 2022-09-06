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

            setSelectTableList();   
        }

        /// <summary>
        /// Set the selected table list from the App Config file
        /// </summary>
        private void setSelectTableList()
        {
            this.selectedTableList = JSONGateway.getInstance().importTable();
            log.Info($"Setup the selected Database Table, number of tables: {selectedTableList.Count}");
        }

        private static DatabaseGateway _instance;
        private static readonly object _lock = new object();
        private static readonly ILog log = LogHelper.getLogger();

        /// <summary>
        /// Get DatabaseGateway instance
        /// </summary>
        /// <returns>Singleton of DatabaseGateway object</returns>
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

        /// <summary>
        /// Set the connection string from the App Config file
        /// Data Source=192.168.0.212\ION;Database=SYP_8F_AC_Plant_RM;User ID=EMSD;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        /// Data Source=DELL-INSPIRON14;Database=mainDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        /// </summary>
        public void setGateway()
        {
            this.connectionString = ConfigurationManager.AppSettings["ConnectionString"];

            log.Info($"Setup the Database gateway: {this.connectionString}");
        }

        /// <summary>
        /// Update and test the Database communcation setting with new connection string.
        /// </summary>
        /// <param name="newConnectionString">The updated connection string</param>
        /// <returns></returns>
        public bool updateGateway(string newConnectionString)
        {
            log.Info("Update gateway");

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

        /// <summary>
        /// Check if the connection string able to connect with the server
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>Boolean of the check</returns>
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

        /// <summary>
        /// Run the stored procedures search and Get the DataTable of the result (Only 1 Table)
        /// </summary>
        /// <returns>DataTable of the search result</returns>
        public DataTable searchForDBTableData(DateTime startSearchDate, DateTime endSearchDate, string tableName)
        {
            log.Debug($"Request Database data of: {tableName}, {startSearchDate}, {endSearchDate}");

            //Use the stored procedure cmd
            DataTable sqlOutput;

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_Gateway_SearchTable", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Change to sql itemes formate
                    cmd.Parameters.Add("@table", SqlDbType.VarChar).Value = tableName;
                    cmd.Parameters.Add("@startDateTime", SqlDbType.DateTime).Value = startSearchDate;
                    cmd.Parameters.Add("@endDateTime", SqlDbType.DateTime).Value = endSearchDate;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        sqlOutput = new DataTable();

                        da.Fill(sqlOutput);

                        log.Info($"Recieved Database data of tablename: {tableName}, start search date: {startSearchDate}, end search date: {endSearchDate}");
                    }
                }
            }

            return sqlOutput;
        }

        /// <summary>
        /// Get the list of selected Database table
        /// </summary>
        /// <returns>List of selected Database table name string</returns>
        public List<string> getSelectedTable()
        {
            return this.selectedTableList;
        }

        /// <summary>
        /// Update the selected Database table list
        /// </summary>
        /// <param name="tableName">Name of the table</param>
        public void updateSelectedTableList(List<string> tableName)
        {
            JSONGateway.getInstance().updateTableJSON(tableName);
            setSelectTableList();
        }
    }
}
