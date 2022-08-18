using System;
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

        public Result runSearch()
        {
            DateTime genTime = DateTime.Now;

            DateTime startSearchDay;
            DateTime endSearchDay;

            endSearchDay = genTime;

            int length = DateTime.DaysInMonth(endSearchDay.Year, endSearchDay.Month);

            startSearchDay = endSearchDay.AddDays(-length);

            DataTable dt = DatabaseGateway.getInstance().getDBTable01(startSearchDay, endSearchDay, selectColumn);

            Result res = new Result(genTime, dt);

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
    }
}
