using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerPeg_SQL_to_CSV.Mode;
using PowerPeg_SQL_to_CSV.Gateway.Gateway;

namespace PowerPeg_SQL_to_CSV.Task
{
    [Serializable]
    public class SearchTask
    {
        private string taskName;

        private string outputLocation;

        private IMode operationMode;

        private Result resultOfSQL;

        public string getTaskName()
        {
            return taskName;
        }

        public string getOutputFolderPath()
        {
            return outputLocation;
        }

        public Result getResult()
        {
            return resultOfSQL;
        }

        public IMode getMode()
        {
            return operationMode;
        }

        public SearchTask(string outputLocation, IMode operationMode, string name = "Default")
        {
            taskName = name + DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss");
            this.outputLocation = outputLocation;
            this.operationMode = operationMode;
        }

        public string createTaskName()
        {
            return taskName + "_" + resultOfSQL.getGenerationTime().ToString("yyyy-MM-dd_HH-mm-ss");
        }

        public void toRunTask()
        {
            resultOfSQL = operationMode.runSearch();

            CSVGateway.getInstance().dataTable_to_CSV(createTaskName(), outputLocation, resultOfSQL.getResultTable());
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
