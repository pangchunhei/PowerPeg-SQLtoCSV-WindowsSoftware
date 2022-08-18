using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV.Gateway.Gateway
{
    public class CSVGateway
    {
        private CSVGateway()
        {

        }

        private static CSVGateway _instance;
        private static readonly object _lock = new object();

        public static CSVGateway getInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CSVGateway();
                    }
                }
            }
            return _instance;
        }

        public void dataTable_to_CSV(string fileName, string filePath, DataTable dt)
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>
                  string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(filePath + "\\" + fileName + ".csv", sb.ToString());
        }

    }
}
