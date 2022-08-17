using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    [Serializable]
    public class SearchTask
    {
        private string taskName;

        private string outputLocation;

        private Mode operationMode;

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

        public Mode getMode()
        {
            return operationMode;
        }

        public SearchTask(string outputLocation, Mode operationMode, string name = "Default")
        {
            this.taskName = name + DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss");
            this.outputLocation = outputLocation;
            this.operationMode = operationMode;
        }

        public string createTaskName()
        {
            return this.taskName + "_" + this.resultOfSQL.getGenerationTime().ToString("yyyy-MM-dd_HH-mm-ss");
        }

        public void toRun()
        {
            this.resultOfSQL = operationMode.runSearch();

            Export.getInstance().dataTable_to_CSV(createTaskName(), this.outputLocation, this.resultOfSQL.getResultTable());
        }

        /// <summary>
        /// Get the information of the search task settings
        /// </summary>
        /// <returns>
        /// Return "Task Name", "Output Location", "Mode Name", "Trigger DateTime", "Start Search Date", "End Search Date", "Selected Column List"
        /// </returns>
        public string[] getTaskInfo()
        {
            string[] task = { this.taskName, this.outputLocation };
            string[] mode = operationMode.getInfo();

            return task.Concat(mode).ToArray();
        }

        public void updateSearchTask(string outputlocation, Mode mode)
        {
            this.outputLocation = outputlocation;
            this.operationMode = mode;
        }
    }
}
