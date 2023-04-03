using log4net;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Log;
using PowerPeg_SQL_to_CSV.ProcessTask;
using Quartz.Xml.JobSchedulingData20;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Unit-Testing")]
namespace PowerPeg_SQL_to_CSV.Mode
{
    public class MonthMode : IMode
    {
        private static ITimeProvider _timeProvider = new DefaultTimeProvider();
        internal static ITimeProvider TimeProvider
        {
            get { return _timeProvider; }
            set { _timeProvider = value; }
        }

        private string modeName;
        private DayOfWeek triggerDay;
        private int triggerTime;
        /*private DateTime lastRunDateTime;*/
        internal DateTime nextRunDateTime;
        private List<string> selectColumn = new List<string>();

        private static readonly ILog log = LogHelper.getLogger();

        /// <summary>
        /// Create and change mode of Month Mode
        /// </summary>
        /// <param name="triggerDay">The week of day to trigger the search</param>
        /// <param name="triggerTime">The hour of the day to trigger the search</param>
        /// <param name="selection">The selection list</param>
        public MonthMode(DayOfWeek triggerDay, int triggerTime, List<string> selection)
        {

            this.modeName = "MonthMode";
            this.triggerDay = triggerDay;
            this.triggerTime = triggerTime;
            this.selectColumn = selection;
            
            /*this.lastRunDateTime = DateTime.Now;*/
            this.nextRunDateTime = _timeProvider.GetCurrentTime().AddMinutes(-10);

        }

        internal DateTime CalculateNextTriggerDate(DateTime givenDateTime)
        {
            DateTime nextDate = new DateTime(givenDateTime.Year, givenDateTime.Month, 1);

            while (nextDate.DayOfWeek != this.triggerDay)
            {
                nextDate = nextDate.AddDays(1);
            }

            if (nextDate <= givenDateTime)
            {
                nextDate = nextDate.AddMonths(1);
                nextDate = new DateTime(nextDate.Year, nextDate.Month, 1);

                while (nextDate.DayOfWeek != this.triggerDay)
                {
                    nextDate = nextDate.AddDays(1);
                }
            }
            
            DateTime result = new DateTime(nextDate.Year, nextDate.Month, nextDate.Day, this.triggerTime, 0, 0);
            return result;
        }

        /// <summary>
        /// Check if the provided time is needed to run the function
        /// </summary>
        /// <param name="currentDateTime">Provide the current DateTime</param>
        /// <returns>Return bool</returns>
        internal bool needRun(DateTime currentDateTime)
        {

            if (currentDateTime >= this.nextRunDateTime)
            {
                log.Info($"Run search - next run time: {this.nextRunDateTime} days, trigger day of week: {this.triggerDay}, current hour: {currentDateTime.Hour} vs trigger hour: {this.triggerTime} ");
                return true;
            }
            else
            {
                log.Info($"No run search - next run time: {this.nextRunDateTime} days, trigger day of week: {this.triggerDay}, current hour: {currentDateTime.Hour} vs trigger hour: {this.triggerTime} ");
                return false;
            }
        }

        /// <summary>
        /// Run the search of the search task according to Mode (Interface)
        /// </summary>
        /// <returns>Return an Result object</returns>
        public virtual Result runSearch()
        {
            log.Info($"Trigger month mode search: " + String.Join(", ", getInfo()));

            DateTime runDateTime = _timeProvider.GetCurrentTime();

            if (needRun(runDateTime))
            {
                //Setup search range
                //Start day inclusive, End day exclusive
                DateTime lastMonth = runDateTime.AddMonths(-1);
                DateTime startSearchDay = new DateTime(lastMonth.Year, lastMonth.Month, 1,00,00,00);
                DateTime endSearchDay = new DateTime(runDateTime.Year, runDateTime.Month, 1, 00, 00, 00);

                Result res = new Result(runDateTime);

                res = SQLProcessFunction.processAllDBTable(startSearchDay, endSearchDay, this.selectColumn, res);

                /*this.lastRunDateTime = runDateTime;*/
                this.nextRunDateTime = CalculateNextTriggerDate(runDateTime);
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
            return $"Mode: {this.modeName}\r\nTrigger Week of day: {this.triggerDay.ToString()}\r\nTrigger hour: {this.triggerTime.ToString()}\r\nNext Trigger Date: {this.nextRunDateTime.ToString()}\r\nSelected Field: {string.Join(",", this.selectColumn)}";
        }
    }
}
