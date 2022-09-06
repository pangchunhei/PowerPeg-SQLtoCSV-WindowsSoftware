using log4net;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Log;
using PowerPeg_SQL_to_CSV.ProcessTask;
using System.Data;
using System.Diagnostics;

namespace PowerPeg_SQL_to_CSV.Mode
{
    public class MonthMode : IMode
    {
        private string modeName;
        private DateTime triggerDateTime;
        private DateTime lastRunDateTime;
        private bool selectThisMonth;
        private List<string> selectColumn = new List<string>();

        private static readonly ILog log = LogHelper.getLogger();

        /// <summary>
        /// Create and change mode of Month Mode
        /// </summary>
        /// <param name="triggerDate">First time of Trigger DateTime of the search</param>
        /// <param name="selectThis">Select the duration, for the true: use trigger month's day; for false, use trigger month's previous month day</param>
        /// <param name="selection">List of selected column name</param>
        public MonthMode(DateTime triggerDate, bool selectThis, List<string> selection)
        {
            modeName = "MonthMode";
            triggerDateTime = triggerDate;
            this.selectThisMonth = selectThis;
            selectColumn = selection;
            lastRunDateTime = new DateTime(1999, triggerDate.Month,triggerDate.Day, triggerDate.Hour, triggerDate.Minute, triggerDate.Second);
        }

        /// <summary>
        /// Get the frequency day's gap
        /// True: Using the tigger month
        /// False: Using the tigger month's previous month
        /// </summary>
        /// <param name="runDateTime"></param>
        /// <returns></returns>
        private int getMonthLength(DateTime runDateTime)
        {
            if (selectThisMonth)
            {
                return DateTime.DaysInMonth(runDateTime.Year, runDateTime.Month);
            }
            else
            {
                return DateTime.DaysInMonth(runDateTime.AddMonths(-1).Year, runDateTime.AddMonths(-1).Month);
            }
        }

        /// <summary>
        /// Check if the provided time is needed to run the function
        /// </summary>
        /// <param name="runDateTime"></param>
        /// <returns>Return bool</returns>
        private bool needRun(DateTime runDateTime)
        {
            int monthLength = getMonthLength(runDateTime);

            int daysFromLastRun = (int)runDateTime.Subtract(lastRunDateTime).TotalDays;

            if (daysFromLastRun >= monthLength && runDateTime.Hour == this.triggerDateTime.Hour)
            {
                log.Info($"Need to run search as last run time: {this.lastRunDateTime} time from last run: {daysFromLastRun} days, current hour: {runDateTime.Hour} vs trigger hour: {this.triggerDateTime.Hour} ");
                return true;
            }
            else
            {
                log.Info($"No need to run search as last run time: {this.lastRunDateTime} time from last run: {daysFromLastRun} days, current hour: {runDateTime.Hour} vs trigger hour: {this.triggerDateTime.Hour}");
                return false;
            }
        }

        public Result runSearch(DateTime runDateTime)
        {
            log.Info($"Trigger month mode search: " + String.Join(", ", getInfo()));

            if (needRun(runDateTime))
            {
                DateTime startSearchDay;
                DateTime endSearchDay;

                endSearchDay = runDateTime;

                int length = getMonthLength(runDateTime);

                startSearchDay = endSearchDay.AddDays(-length);

                DateTime pStartSearchDay = new DateTime(startSearchDay.Year,startSearchDay.Month,startSearchDay.Day,00,00,00);
                DateTime pEndSearchDay = new DateTime(endSearchDay.Year, endSearchDay.Month, endSearchDay.Day, 23, 59, 59);

                Result res = new Result(runDateTime);

                res = SQLProcessFunction.processAllDBTable(pStartSearchDay, pEndSearchDay, this.selectColumn, res);

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

            string[] output = { modeName, triggerDateTime.ToString(), selectionStr, selectThisMonth.ToString() };

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
            return $"Mode: {this.modeName}\r\nFirst trigger Day (Inclusive): {this.triggerDateTime.ToString()}\r\nLast Search Day (Exclusive): {this.lastRunDateTime.ToString()}\r\nSelect day duration of current trigger month: {this.selectThisMonth.ToString()}\r\nSelected Field: {string.Join(",", this.selectColumn)}";
        }
    }
}
