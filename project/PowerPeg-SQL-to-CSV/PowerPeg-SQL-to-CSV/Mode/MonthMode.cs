using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.ProcessTask;
using System.Data;

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
            lastRunDateTime = new DateTime(1999, triggerDate.Month,triggerDate.Day, triggerDate.Hour, triggerDate.Minute, triggerDate.Second);
        }

        public override string ToString()
        {
            return this.modeName;
        }

        private bool needRun(DateTime runDateTime)
        {
            int monthLength = DateTime.DaysInMonth(runDateTime.Year, runDateTime.Month);

            int daysFromLastRun = (runDateTime - triggerDateTime).Days;

            if (daysFromLastRun >= monthLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Result runSearch(DateTime runDateTime)
        {
            if (needRun(runDateTime))
            {
                DateTime startSearchDay;
                DateTime endSearchDay;

                endSearchDay = runDateTime;
                this.lastRunDateTime = runDateTime;

                int length = DateTime.DaysInMonth(endSearchDay.Year, endSearchDay.Month);

                startSearchDay = endSearchDay.AddDays(-length);

                DataTable dt = DatabaseGateway.getInstance().getDBTable01(startSearchDay, endSearchDay, selectColumn);

                Result res = new Result(runDateTime, dt);

                return res;
            }
            else
            {
                return null;
            }
            
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
    }
}
