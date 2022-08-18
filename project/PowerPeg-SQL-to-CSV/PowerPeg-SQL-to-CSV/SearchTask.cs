using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPeg_SQL_to_CSV.Gateway.Gateway;
using PowerPeg_SQL_to_CSV.Mode;
using PowerPeg_SQL_to_CSV.ProcessTask;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace PowerPeg_SQL_to_CSV
{
    [Serializable]
    public class SearchTask
    {
        private string taskName;

        private string outputLocation;

        private IMode operationMode;

        public IMode getMode()
        {
            return operationMode;
        }

        public SearchTask(string name, string outputLocation, IMode operationMode)
        {
            this.taskName = name + DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss");
            this.outputLocation = outputLocation;
            this.operationMode = operationMode;
        }

        public void toRunTask()
        {
            Result resultOfSQL = operationMode.runSearch();

            string fileOutputFileName = taskName + "_generation_time_" + resultOfSQL.getGenerationTime().ToString("yyyy-MM-dd_HH-mm-ss");

            CSVGateway.getInstance().dataTable_to_CSV(fileOutputFileName, outputLocation, resultOfSQL.getResultTable());
        }

        /// <summary>
        /// Get the information of the search task settings
        /// </summary>
        /// <returns>
        /// Return "Task Name", "Output Location", "Mode Name", "Trigger DateTime", "Start Search Date", "End Search Date", "Selected Column List"
        /// </returns>
        public string[] getTaskInfo()
        {
            string[] task = { taskName, outputLocation };
            string[] mode = operationMode.getInfo();

            return task.Concat(mode).ToArray();
        }

        public void updateTaskSetting(string outputlocation, IMode mode)
        {
            outputLocation = outputlocation;
            operationMode = mode;
        }
    }
}
