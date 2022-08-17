using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Task;

namespace PowerPeg_SQL_to_CSV.Mode
{
    public class InstantMode : IMode
    {
        private string modeName;

        private DateTime startSearchDay;

        private DateTime endSearchDay;

        private DateTime triggerDateTime;

        private List<string> selectColumn = new List<string>();

        /// <summary>
        /// Create and change mode of InstantMode
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="triggerDate"></param>
        /// <param name="selection"></param>
        public InstantMode(DateTime startDate, DateTime endDate, DateTime triggerDate, List<string> selection)
        {
            modeName = "Instant Mode";
            //Last 30DAys
            startSearchDay = startDate;
            endSearchDay = endDate;
            triggerDateTime = triggerDate;
            selectColumn = selection;
        }

        public Result runSearch()
        {
            DateTime genTime = DateTime.Now;

            DataTable dt = DatabaseGateway.getInstance().getDBTable01(startSearchDay, endSearchDay, selectColumn);

            Result res = new Result(genTime, dt);

            return res;
        }

        public string[] getInfo()
        {
            string selectionStr = string.Join(",", selectColumn);

            string[] output = { modeName, triggerDateTime.ToString(), startSearchDay.ToString(), endSearchDay.ToString(), selectionStr };

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
