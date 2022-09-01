using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Gateway.Gateway;
using PowerPeg_SQL_to_CSV.ProcessTask;
using PowerPeg_SQL_to_CSV.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using log4net;

namespace PowerPeg_SQL_to_CSV.Mode
{
    internal static class SQLProcessFunction
    {
        private static List<string[]> lookupTable = CSVGateway.getInstance().importCSV();
        private static readonly ILog log = LogHelper.getLogger();

        /// <summary>
        /// Lookup for the site name
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        private static string findLookup(string device)
        {
            foreach (string[] name in lookupTable)
            {
                if (name[0] == device)
                {
                    return name[1];
                }
            }
            return "Not Found";
        }

        /// <summary>
        /// Connect all the DataTables with the parimary key
        /// </summary>
        /// <param name="datatables">Array of DataTable</param>
        /// <returns></returns>
        private static DataTable FullOuterJoinDataTables(params DataTable[] datatables) // supports as many datatables as you need.
        {
            log.Debug($"Outer Join DataTables");

            DataTable result = datatables.First().Clone();

            var commonColumns = result.Columns.OfType<DataColumn>();

            foreach (var dt in datatables.Skip(1))
            {
                commonColumns = commonColumns.Intersect(dt.Columns.OfType<DataColumn>(), new DataColumnComparer());
            }

            result.PrimaryKey = commonColumns.ToArray();

            foreach (var dt in datatables)
            {
                result.Merge(dt, false, MissingSchemaAction.AddWithKey);
            }

            return result;
        }


        /// <summary>
        /// Combine 2 datatable into one datatable
        /// </summary>
        /// <param name="dt1">DataTable 1</param>
        /// <param name="dt2">DataTable 2</param>
        /// <returns></returns>
        private static DataTable CombileDataTable(DataTable dt1, DataTable dt2)
        {
            string keyColumn = "Timestamp";

            dt1.PrimaryKey = new DataColumn[] { dt1.Columns[keyColumn] };
            dt2.PrimaryKey = new DataColumn[] { dt2.Columns[keyColumn] };
            
            log.Debug($"Define 2 DataTables primary key, now trigger combine");
            return FullOuterJoinDataTables(new DataTable[] { dt1, dt2 });
        }

        /// <summary>
        /// Trigger the SQL query and modify the datatable
        /// </summary>
        /// <param name="startSearchDay">Start day of the search</param>
        /// <param name="endSearchDay">End day of the search</param>
        /// <param name="selectColumn">Selected column of the search</param>
        /// <param name="res">Result object for storage</param>
        /// <returns></returns>
        internal static Result processAllDBTable(DateTime startSearchDay, DateTime endSearchDay, List<string> selectColumn, Result res)
        {

            List<string> selectedTableName = DatabaseGateway.getInstance().getSelectedTable();

            foreach (string name in selectedTableName)
            {
                if (selectColumn.Contains(name) || selectColumn[0] == "*")
                {
                    //TODO-- Check if select such column
                    DataTable output = DatabaseGateway.getInstance().searchForDBTableData(startSearchDay, endSearchDay, name);

                    log.Debug($"Modify the DataTable column of the search: {name}");
                    //Remove column
                    output.Columns.Remove("ID");
                    output.Columns.Remove("TimeChange");
                    output.Columns.Remove("LogStatus");
                    output.Columns.Remove("StatusFlags");
                    
                    //Lookup
                    string lookup = findLookup(name);
                    log.Debug($"Lookup {name}: {lookup}");

                    if (lookup.Equals("Not Found"))
                    {
                        output.Columns[1].ColumnName += " " + lookup;
                    }
                    else
                    {
                        output.Columns[1].ColumnName = lookup;
                    } 
                    
                    res.updateDataTable(CombileDataTable(res.getResultTable(), output));
                }
            }

            log.Info($"SQL and DataTable process completed");

            return res;
        }
    }

    /// <summary>
    /// Enable the full outer join
    /// </summary>
    public class DataColumnComparer : IEqualityComparer<DataColumn>
    {
        public bool Equals(DataColumn x, DataColumn y) { return x.Caption == y.Caption; }

        public int GetHashCode(DataColumn obj) { return obj.Caption.GetHashCode(); }

    }
}
