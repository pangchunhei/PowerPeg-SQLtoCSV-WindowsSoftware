using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.ProcessTask;

namespace PowerPeg_SQL_to_CSV.Mode
{
    public class MonthMode : IMode
    {
        private string modeName;

        private DateTime triggerDateTime;

        private DateTime lastRunDateTime;

        private List<string> selectColumn = new List<string>();

        /// <summary>
        /// Create and change mode of InstantMode
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="triggerDate"></param>
        /// <param name="selection"></param>
        public MonthMode(DateTime triggerDate, List<string> selection)
        {
            modeName = "Month Mode";
            triggerDateTime = triggerDate;
            selectColumn = selection;
        }

        public override string ToString()
        {
            return this.modeName;
        }

        public void runScheduleTask(DateTime runDateTime)
        {
            if(runDateTime.Day == triggerDateTime.Day)
            {

            }
        }

        private bool checkOnSchedule(DateTime runDateTime)
        {
            int needed = DateTime.DaysInMonth(runDateTime.Year, runDateTime.Month);
            TimeSpan difference = runDateTime - this.lastRunDateTime;
            int lengthFromLastRun = difference.Days;

            if (lengthFromLastRun == needed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Result runSearch(DateTime runDateTime)
        {
            DateTime startSearchDay;
            DateTime endSearchDay;

            endSearchDay = this.lastRunDateTime;

            int length = DateTime.DaysInMonth(endSearchDay.Year, endSearchDay.Month);

            startSearchDay = endSearchDay.AddDays(-length);

            DataTable dt = DatabaseGateway.getInstance().getDBTable01(startSearchDay, endSearchDay, selectColumn);

            Result res = new Result(this.lastRunDateTime, dt);

            return res;
        }

        public string[] getInfo()
        {
            string selectionStr = string.Join(",", selectColumn);

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

        public Result toRun(DateTime runDateTime)
        {
            if (checkOnSchedule(runDateTime))
            {
                this.lastRunDateTime = runDateTime;
                return runSearch(runDateTime);
            }
            else
            {
                //TODO-- Now need to run
                throw new Exception();
            }
        }
    }
}
