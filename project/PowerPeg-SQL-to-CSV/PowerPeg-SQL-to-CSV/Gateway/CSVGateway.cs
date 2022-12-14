using log4net;
using PowerPeg_SQL_to_CSV.Log;
using System.Configuration;
using System.Data;
using System.Text;

namespace PowerPeg_SQL_to_CSV.Gateway.Gateway
{
    public class CSVGateway
    {
        private CSVGateway()
        {
            this.csvPath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["Map"];
            log.Debug($"CSV mapping data filepath {csvPath}");
        }

        private static CSVGateway _instance;
        private static readonly object _lock = new object();
        private static readonly ILog log = LogHelper.getLogger();

        /// <summary>
        /// Get CSVGateway instance
        /// </summary>
        /// <returns>Singleton of CSVGateway object</returns>
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

        private string csvPath;

        /// <summary>
        /// Convert the DataTable and store to CSV file
        /// </summary>
        /// <param name="fileName">CSV filename</param>
        /// <param name="filePath">CSV filepath</param>
        /// <param name="datatable">DataTable for storage</param>
        public void dataTable_to_CSV(string fileName, string filePath, DataTable datatable)
        {
            lock (_lock)
            {
                log.Info($"Processing result to CSV: {fileName}");

                StringBuilder sb = new StringBuilder();

                IEnumerable<string> columnNames = datatable.Columns.Cast<DataColumn>().Select(column => column.ColumnName);
                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in datatable.Rows)
                {
                    IEnumerable<string> fields = row.ItemArray.Select(field =>
                      string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                    sb.AppendLine(string.Join(",", fields));
                }

                log.Debug($"Store the CSV of the Result to {filePath}");
                FileInfo file = new FileInfo(filePath);
                file.Directory.Create();
                File.WriteAllText(filePath + "\\" + fileName + ".csv", sb.ToString());
            }
        }

        public List<string[]> importCSV()
        {
            log.Info($"Importing CSV mapping lookup: {this.csvPath}");

            StreamReader sr = new StreamReader(this.csvPath);
            var lines = new List<string[]>();
            int Row = 0;
            while (!sr.EndOfStream)
            {
                string[] Line = sr.ReadLine().Split(',');
                lines.Add(Line);
                Row++;
            }

            log.Debug($"Finished CSV mapping lookup import");

            return lines;
        }

    }
}
