using System;
using System.Collections.Generic;
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

        public InstantMode(DateTime startDate, DateTime endDate, DateTime triggerDate, List<String> selection)
        {
            this.modeName = "Insatant Mode";
            //Last 30DAys
            this.startSearchDay = new DateOnly(startDate.Year,startDate.Month,startDate.Day);
            this.endSearchDay = new DateOnly(endDate.Year, endDate.Month, endDate.Day);
            this.triggerDateTime = triggerDate;
            this.selectColumn = selection;
        }

        public Result toRun()
        {
            throw new NotImplementedException();
        }

        public string[] getInfo()
        {
            string selectionStr = "";

            foreach (var select in this.selectColumn)
            {
                selectionStr += select + " ";
            }

            string[] output = {this.modeName, this.triggerDateTime.ToString(), this.startSearchDay.ToString(), this.endSearchDay.ToString(), selectionStr};

            return output;
        }
    }
}
