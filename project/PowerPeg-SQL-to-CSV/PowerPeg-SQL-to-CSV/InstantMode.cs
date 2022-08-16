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
        private DateOnly startSearchDay;

        private DateOnly endSearchDay;

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
            this.startSearchDay = new DateOnly(startDate.Year,startDate.Month,startDate.Day);
            this.endSearchDay = new DateOnly(endDate.Year, endDate.Month, endDate.Day);
            this.triggerDateTime = triggerDate;
            this.selectColumn = selection;
        }

        public Result runSearch()
        {
            DateTime genTime = DateTime.Now;
            Gateway g = Gateway.getInstance();

            DataTable dt = g.getDBTable01(this.startSearchDay, this.endSearchDay, this.selectColumn);

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
