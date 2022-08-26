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
        /// Run the stored procedures search and Get the list of the database column name
        /// </summary>
        /// <returns>List of database column name string</returns>
        public List<string> getDBTableColName()
        {
            log.Info("Request Database for Table column infomation.");

            //Use the stored procedure cmd
            DataTable sqlOutput;

            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                //Local test
                //using (SqlCommand cmd = new SqlCommand("sp_gateway_get_table_1_col", sqlcon))
                //Prod
                using (SqlCommand cmd = new SqlCommand("sp_Gateway_GetSelectedTable_ColumnName", sqlcon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //Prod
                    cmd.Parameters.Add("@tableName", SqlDbType.VarChar).Value = createSelectedTableStatementString();

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

        /// <summary>
        /// Create the SQL selecte statement [column name 1],[column name 2], .....
        /// </summary>
        /// <returns>SQL string</returns>
        private string createSelectStatementString(List<string> selectColumn)
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

        /// <summary>
        /// Test (Only 1 Table)
        /// </summary>
        /// <returns>DataTable of the search result</returns>
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
                    cmd.Parameters.Add("@selectCol", SqlDbType.VarChar).Value = createSelectStatementString(selectColumn);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        sqlOutput = new DataTable();

                        da.Fill(sqlOutput);
                    }
                }
            }

            return sqlOutput;
        }

        /// <summary>
        /// Run the stored procedures search and Get the DataTable of the result (Only 1 Table)
        /// </summary>
        /// <returns>DataTable of the search result</returns>
        public DataTable getDBTableData(DateTime startSearchDate, DateTime endSearchDate, string tableName)
        {
            log.Info("Request Database for Table data.");

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

        /// <summary>
        /// Create the SQL table statement 'Table Name 1','Table Name 2', .....
        /// </summary>
        /// <returns>SQL string</returns>
        private string createSelectedTableStatementString()
        {
            //return "\'" + string.Join("\', \' ", this.selectedTableList) + "\'";
            return string.Join(",", this.selectedTableList);
        }
    }
}
