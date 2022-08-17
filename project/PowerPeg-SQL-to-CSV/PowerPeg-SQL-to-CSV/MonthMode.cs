using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    [Serializable]
    public class MonthMode : Mode
    {
        [JsonProperty]
        private String modeName;

        [JsonProperty]
        private DateTime triggerDateTime;

        [JsonProperty]
        private IList<String> selectColumn = new List<String>();

        /// <summary>
        /// Create and change mode of InstantMode
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="triggerDate"></param>
        /// <param name="selection"></param>
        public MonthMode(DateTime triggerDate, IList<String> selection)
        {
            this.modeName = "Month Mode";
            this.triggerDateTime = triggerDate;
            this.selectColumn = selection;
        }

        public Result runSearch()
        {
            DateTime genTime = DateTime.Now;

            DateTime startSearchDay;
            DateTime endSearchDay;
            
            endSearchDay = genTime;

            int length = DateTime.DaysInMonth(endSearchDay.Year, endSearchDay.Month);

            startSearchDay = endSearchDay.AddDays(-length);

            DataTable dt = Gateway.getInstance().getDBTable01(startSearchDay, endSearchDay, this.selectColumn);

            Result res = new Result(genTime, dt);

            return res;
        }

        public string[] getInfo()
        {
            string selectionStr = string.Join(",", selectColumn);

            string[] output = {this.modeName, this.triggerDateTime.ToString(), selectionStr};

            return output;
        }
    }
}
