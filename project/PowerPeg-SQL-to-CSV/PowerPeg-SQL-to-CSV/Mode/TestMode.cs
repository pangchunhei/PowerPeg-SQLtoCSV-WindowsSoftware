using log4net;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Log;
using PowerPeg_SQL_to_CSV.ProcessTask;
using System.Data;
using System.Diagnostics;

namespace PowerPeg_SQL_to_CSV.Mode
{
    /// <summary>
    /// For testing async and background
    /// </summary>
    public class TestMode : IMode
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
        public TestMode(DateTime triggerDate, List<string> selection)
        {
            modeName = "TestMode";
            triggerDateTime = triggerDate;
            selectColumn = selection;
            lastRunDateTime = new DateTime(1999, triggerDate.Month,triggerDate.Day, triggerDate.Hour, triggerDate.Minute, triggerDate.Second);
        }

        /// <summary>
        /// Check if the provided time is needed to run the function
        /// </summary>
        /// <param name="runDateTime"></param>
        /// <returns>Return bool</returns>
        private bool needRun(DateTime runDateTime)
        {
            int minuteLength = 1;

            int minuteFromLastRun = (int)runDateTime.Subtract(lastRunDateTime).TotalMinutes;

            if (minuteFromLastRun >= minuteLength)
            {
                log.Info($"Run search as last run time: {this.lastRunDateTime} time from last run: {minuteFromLastRun} minutes");
                return true;
            }
            else
            {
                log.Info($"No run search as last run time: {this.lastRunDateTime} time from last run: {minuteFromLastRun} minutes");
                return false;
            }
        }

        public Result runSearch(DateTime runDateTime)
        {
            log.Info($"Trigger minute mode search: " + String.Join(", ", getInfo()));
            
            if (needRun(runDateTime))
            {

                DateTime startSearchDay = new DateTime(2022, 8, 1, 00, 00, 00);
                DateTime endSearchDay = new DateTime(2022, 9, 1, 00, 00, 00);
                
                Result res = new Result(runDateTime);

                res = SQLProcessFunction.processAllDBTable(startSearchDay, endSearchDay, this.selectColumn, res);

                this.lastRunDateTime = runDateTime;

                return res;
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

        public override string ToString()
        {
            return $"Mode: {this.modeName}\r\nFirst trigger Day (Inclusive): {this.triggerDateTime.ToString()}\r\nLast Search Day (Exclusive): {this.lastRunDateTime.ToString()}\r\nSelected Field: {string.Join(",", this.selectColumn)}";
        }
    }
}
