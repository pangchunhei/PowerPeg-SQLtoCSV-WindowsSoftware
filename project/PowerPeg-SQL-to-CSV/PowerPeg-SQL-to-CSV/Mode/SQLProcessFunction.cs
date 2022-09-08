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
        /// Lookup for the site name in the lookup table csv
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static string searchLookupTable(string table)
        {
            foreach (string[] name in lookupTable)
            {
                if (name[0] == table)
                {
                    log.Debug($"Lookup for {table}, match to {name[1]}");
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
            log.Debug($"Outer Join all DataTables");

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
        private static DataTable combileDataTable(DataTable dt1, DataTable dt2)
        {
            string keyColumn = "Timestamp";

            dt1.PrimaryKey = new DataColumn[] { dt1.Columns[keyColumn] };
            dt2.PrimaryKey = new DataColumn[] { dt2.Columns[keyColumn] };

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

            DataTable resultDt = new DataTable();

            foreach (string name in selectedTableName)
            {
                if (selectColumn.Contains(name) || selectColumn[0] == "*")
                {
                    //TODO-- Check if select such field


                    DataTable output = DatabaseGateway.getInstance().searchForDBTableData(startSearchDay, endSearchDay, name);

                    log.Debug($"DataTable table: {name} obtained, Modify the DataTable columnto keep: {output.Columns["Timestamp"].ColumnName}, {output.Columns[5].ColumnName}");

                    //Remove column
                    output.Columns.Remove("ID");
                    output.Columns.Remove("TimeChange");
                    output.Columns.Remove("LogStatus");
                    output.Columns.Remove("StatusFlags");

                    //Lookup for device column name
                    string lookup = searchLookupTable(name);

                    if (lookup.Equals("Not Found"))
                    {
                        output.Columns[1].ColumnName += " " + lookup;
                    }
                    else
                    {
                        output.Columns[1].ColumnName = lookup;
                    }

                    resultDt = combileDataTable(resultDt, output);
                }
            }

            //Rounding
            log.Info($"Rounding DataTable");
            foreach (DataRow dtRow in resultDt.Rows)
            {
                for (int i = 1; i < resultDt.Columns.Count; i++)
                {
                    double rowValue;
                    double.TryParse(dtRow[i].ToString(), out rowValue);
                    dtRow[i] = Math.Round(rowValue, 2);
                }
            }

            //Sorting
            log.Info($"Sorting DataTable");
            resultDt.DefaultView.Sort = "Timestamp";
            resultDt = resultDt.DefaultView.ToTable();

            res.updateDataTable(resultDt);

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
