using log4net;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Log;
using PowerPeg_SQL_to_CSV.ProcessTask;
using System.Data;
using System.Diagnostics;

namespace PowerPeg_SQL_to_CSV.Mode
{
    /// <summary>
    /// For testing async
    /// </summary>
    public class MinuteMode : IMode
    {
        private string modeName;
        private DateTime triggerDateTime;
        private DateTime lastRunDateTime;
        private List<string> selectColumn = new List<string>();
        private static readonly ILog log = LogHelper.getLogger();

        /// <summary>
        /// Create and change mode of Minutes Testing Mode
        /// </summary>
        /// <param name="triggerDate">First time of Trigger DateTime of the search</param>
        /// <param name="selection">List of selected column name</param>
        public MinuteMode(DateTime triggerDate, List<string> selection)
        {
            modeName = "Minute Mode";
            triggerDateTime = triggerDate;
            selectColumn = selection;
            lastRunDateTime = new DateTime(1999, triggerDate.Month,triggerDate.Day, triggerDate.Hour, triggerDate.Minute, triggerDate.Second);
        }

        public override string ToString()
        {
            return this.modeName;
        }

        /// <summary>
        /// Check if the provided time is needed to run the function
        /// </summary>
        /// <param name="runDateTime"></param>
        /// <returns>Return bool</returns>
        private bool needRun(DateTime runDateTime)
        {
            int minuteLength = 1;

            int minuteFromLastRun = (runDateTime - this.lastRunDateTime).Minutes;

            if (minuteFromLastRun >= minuteLength)
            {
                log.Info($"Need to run search as last run time: {this.lastRunDateTime} time from last run: {minuteFromLastRun} minutes");
                return true;
            }
            else
            {
                log.Info($"No need to run search as last run time: {this.lastRunDateTime} time from last run: {minuteFromLastRun} minutes");
                return false;
            }
        }

        private Result processAllDBTable(DateTime startSearchDay, DateTime endSearchDay, Result res)
        {
            List<string> selectedTableName = DatabaseGateway.getInstance().getSelectedTable();

            foreach (string name in selectedTableName)
            {
                if (this.selectColumn.Contains(name) || selectColumn[0] == "*")
                {
                    //TODO-- Check if select such column
                    DataTable output = DatabaseGateway.getInstance().getDBTableData(startSearchDay, endSearchDay, name);

                    //Remove column
                    output.Columns.Remove("ID");
                    output.Columns.Remove("TimeChange");
                    output.Columns.Remove("LogStatus");
                    output.Columns.Remove("StatusFlags");


                    res.mergeDataTable(output);
                }

            }

            return res;
        }

        public Result runSearch(DateTime runDateTime)
        {
            log.Info($"Trigger minute mode search: " + String.Join(", ", getInfo()));
            
            if (needRun(runDateTime))
            {
                DateTime startSearchDay;
                DateTime endSearchDay;

                endSearchDay = runDateTime;
                this.lastRunDateTime = runDateTime;

                int length = DateTime.DaysInMonth(endSearchDay.Year, endSearchDay.Month);

                startSearchDay = endSearchDay.AddMinutes(-1);

                DateTime pStartSearchDay = new DateTime(startSearchDay.Year, startSearchDay.Month, startSearchDay.Day, 00, 00, 00);
                DateTime pEndSearchDay = new DateTime(endSearchDay.Year, endSearchDay.Month, endSearchDay.Day, 23, 59, 59);

                Result res = new Result(runDateTime);

                return processAllDBTable(pStartSearchDay, pEndSearchDay, res);
            }
            else
            {
                return null;
            }
            
        }

        public string[] getInfo()
        {
            string selectionStr = string.Join(", ", selectColumn);

            string[] output = { modeName, triggerDateTime.ToString(), selectionStr };

            return output;
        }

        public DateTime getTriggerDateTime()
        {
            return triggerDateTime;
        }

        public List<string> getSelectColumn()
        {
            return selectColumn;
        }
    }
}
