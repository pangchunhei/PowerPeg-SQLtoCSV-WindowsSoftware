using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    [Serializable]
    public class InstantMode : Mode
    {
        [JsonProperty]
        private String modeName;

        [JsonProperty]
        private DateTime startSearchDay;

        [JsonProperty]
        private DateTime endSearchDay;

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
        public InstantMode(DateTime startDate, DateTime endDate, DateTime triggerDate, IList<String> selection)
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
