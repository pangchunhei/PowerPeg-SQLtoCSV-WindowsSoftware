using log4net;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Gateway.Gateway;
using PowerPeg_SQL_to_CSV.Log;
using PowerPeg_SQL_to_CSV.ProcessTask;
using System.Data;

namespace PowerPeg_SQL_to_CSV.Mode
{
    public class InstantMode : IMode
    {
        private string modeName;
        private DateTime startSearchDay;
        private DateTime endSearchDay;
        private DateTime triggerDateTime;
        private List<string> selectColumn = new List<string>();
        private static readonly ILog log = LogHelper.getLogger();

        /// <summary>
        /// Create and change mode of InstantMode
        /// </summary>
        /// <param name="startDate">Start DateTime of the search</param>
        /// <param name="endDate">End DateTime of the search</param>
        /// <param name="triggerDate">First time of Trigger DateTime of the search</param>
        /// <param name="selection">List of selected column name</param>
        public InstantMode(DateTime startDate, DateTime endDate, DateTime triggerDate, List<string> selection)
        {
            modeName = "InstantMode";
            startSearchDay = new DateTime(startDate.Year, startDate.Month, startDate.Day, 00, 00, 00);
            endSearchDay = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);
            triggerDateTime = triggerDate;
            selectColumn = selection;
        }

        public Result runSearch(DateTime runDateTime)
        {
            log.Info($"Trigger instant mode search: " + String.Join(", ", getInfo()));

            //UAT
            //DataTable dt = DatabaseGateway.getInstance().getDBTable01(startSearchDay, endSearchDay, selectColumn);

            Result res = new Result(runDateTime);

            return SQLProcessFunction.processAllDBTable(this.startSearchDay, this.endSearchDay, this.selectColumn, res);
        }

        public string[] getInfo()
        {
            string selectionStr = string.Join(", ", selectColumn);

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

        public override string ToString()
        {
            return $"Mode: {this.modeName}\r\nStart Search Day (Inclusive): {this.startSearchDay.ToString()}\r\nEnd Search Day (Exclusive): {this.endSearchDay.ToString()}\r\nSelected Field: {string.Join(",", this.selectColumn)}";
        }
    }
}
