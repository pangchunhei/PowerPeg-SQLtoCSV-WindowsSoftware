using log4net;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Log;
using PowerPeg_SQL_to_CSV.ProcessTask;
using Quartz.Xml.JobSchedulingData20;
using System.Data;
using System.Diagnostics;

namespace PowerPeg_SQL_to_CSV.Mode
{
    public class MonthMode : IMode
    {
        private string modeName;
        private DayOfWeek triggerDay;
        private int triggerTime;
        private DateTime lastRunDateTime;
        private List<string> selectColumn = new List<string>();

        private static readonly ILog log = LogHelper.getLogger();

        /// <summary>
        /// Create and change mode of Month Mode
        /// </summary>
        public MonthMode(DayOfWeek triggerDay, int triggerTime, List<string> selection)
        {
            this.modeName = "MonthMode";
            this.triggerDay = triggerDay;
            this.triggerTime = triggerTime;
            this.selectColumn = selection;
            //Force it to run once in the upcoming month
            DateTime initializeLastRun = DateTime.Now;
            this.lastRunDateTime = getFirstWeekofDay(initializeLastRun);
        }

        private DateTime getFirstWeekofDay(DateTime target)
        {
            DateTime resultDate = new DateTime(target.Year, target.Month, 1);
            while (resultDate.DayOfWeek != this.triggerDay)
            {
                resultDate = resultDate.AddDays(1);
            }

            return resultDate;
        } 


        private DateTime findNextTriggerDateTime()
        {
            //TODO-- Update
            DateTime next = this.lastRunDateTime.AddMonths(1);
            DateTime result = getFirstWeekofDay(next);
            result = new DateTime(result.Year, result.Month, result.Day, this.triggerTime, 0, 0);
            return result;
        }

        /// <summary>
        /// Check if the provided time is needed to run the function
        /// </summary>
        /// <param name="runDateTime"></param>
        /// <returns>Return bool</returns>
        private bool needRun(DateTime runDateTime)
        {
            DateTime nextRunTime = findNextTriggerDateTime();

            int daysFromLastRun = (int)runDateTime.Subtract(nextRunTime).TotalDays;

            if (daysFromLastRun == 0 && runDateTime.Hour == this.triggerTime)
            {
                log.Info($"Run search - last run time: {this.lastRunDateTime}, next run time: {nextRunTime} days, trigger day of week: {this.triggerDay}, current hour: {runDateTime.Hour} vs trigger hour: {this.triggerTime} ");
                return true;
            }
            else
            {
                log.Info($"No run search - last run time: {this.lastRunDateTime}, next run time: {nextRunTime} days, trigger day of week: {this.triggerDay}, current hour: {runDateTime.Hour} vs trigger hour: {this.triggerTime} ");
                return false;
            }
        }

        public Result runSearch(DateTime runDateTime)
        {
            log.Info($"Trigger month mode search: " + String.Join(", ", getInfo()));

            if (needRun(runDateTime))
            {
                //Start day inclusive, End day exclusive
                DateTime lastMonth = runDateTime.AddMonths(-1);
                DateTime startSearchDay = new DateTime(lastMonth.Year, lastMonth.Month, 1,00,00,00);
                DateTime endSearchDay = new DateTime(runDateTime.Year, runDateTime.Month, 1, 00, 00, 00);

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

        /// <summary>
        /// Get the mode information
        /// </summary>
        /// <returns>return "Mode Name", "Trigger Week of Day", "Trigger Hour", "Selection List"</returns>
        public string[] getInfo()
        {
            string selectionStr = string.Join(", ", selectColumn);

            string[] output = { this.modeName, this.triggerDay.ToString(), this.triggerTime.ToString(), selectionStr};

            return output;
        }

        public override string ToString()
        {
            return $"Mode: {this.modeName}\r\nTrigger Week of day: {this.triggerDay.ToString()}\r\nTrigger hour: {this.triggerTime.ToString()}\r\nLast Trigger Date: {this.lastRunDateTime.ToString()}\r\nSelected Field: {string.Join(",", this.selectColumn)}";
        }
    }
}
