using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    public class InstantMode : Mode
    {
        private String modeName;
        private DateTime startSearchDay;

        private DateTime endSearchDay;

        private DateTime triggerDateTime;

        private List<String> selectColumn = new List<String>();

        /// <summary>
        /// Create and change mode of InstantMode
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="triggerDate"></param>
        /// <param name="selection"></param>
        public InstantMode(DateTime startDate, DateTime endDate, DateTime triggerDate, List<String> selection)
        {
            this.modeName = "Instant Mode";
            //Last 30DAys
            this.startSearchDay = startDate;
            this.endSearchDay = endDate;
            this.triggerDateTime = triggerDate;
            this.selectColumn = selection;
        }

        public Result runSearch()
        {
            DateTime genTime = DateTime.Now;

            DataTable dt = Gateway.getInstance().getDBTable01(this.startSearchDay, this.endSearchDay, this.selectColumn);

            Result res = new Result(genTime, dt);

            return res;
        }

        public string[] getInfo()
        {
            string selectionStr = string.Join(",", selectColumn);

            string[] output = {this.modeName, this.triggerDateTime.ToString(), this.startSearchDay.ToString(), this.endSearchDay.ToString(), selectionStr};

            return output;
        }
    }
}
