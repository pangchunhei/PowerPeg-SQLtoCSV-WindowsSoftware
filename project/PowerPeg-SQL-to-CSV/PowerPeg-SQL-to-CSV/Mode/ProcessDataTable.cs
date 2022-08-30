using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Gateway.Gateway;
using PowerPeg_SQL_to_CSV.ProcessTask;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV.Mode
{
    internal static class ProcessDataTable
    {
        private static List<string[]> lookupTable = CSVGateway.getInstance().importCSV();

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

        private static DataTable CombileDataTable(DataTable dt1, DataTable dt2)
        {
            DataTable dtNew = new DataTable();
            foreach (DataColumn col in dt1.Columns)
            {
                dtNew.Columns.Add(col.ColumnName);
            }
            foreach (DataColumn col in dt2.Columns)
            {
                if (!dtNew.Columns.Contains(col.ColumnName))
                {
                    dtNew.Columns.Add(col.ColumnName);
                }
            }
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr = dtNew.NewRow();
                foreach (DataColumn col in dt1.Columns)
                {
                    dr[col.ColumnName] = dt1.Rows[i][col.ColumnName];
                }
                foreach (DataColumn col in dt2.Columns)
                {
                    dr[col.ColumnName] = dt2.Rows[i][col.ColumnName];
                }
                dtNew.Rows.Add(dr);
                dtNew.AcceptChanges();
            }

            return dtNew;
        }

        internal static Result processAllDBTable(DateTime startSearchDay, DateTime endSearchDay, List<string> selectColumn, Result res)
        {
            List<string> selectedTableName = DatabaseGateway.getInstance().getSelectedTable();

            foreach (string name in selectedTableName)
            {
                if (selectColumn.Contains(name) || selectColumn[0] == "*")
                {
                    //TODO-- Check if select such column
                    DataTable output = DatabaseGateway.getInstance().getDBTableData(startSearchDay, endSearchDay, name);

                    //Remove column
                    output.Columns.Remove("ID");
                    output.Columns.Remove("TimeChange");
                    output.Columns.Remove("LogStatus");
                    output.Columns.Remove("StatusFlags");

                    //TODO--Lookup

                    string lookup = findLookup(output.Columns[1].ColumnName);

                    if (lookup.Equals("Not Found"))
                    {
                        output.Columns[1].ColumnName += " " + lookup;
                    }
                    else
                    {
                        output.Columns[1].ColumnName = lookup;
                    }                

                    res.updateDataTable(CombileDataTable(output, res.getResultTable()));
                }
            }

            return res;
        }
    }
}
