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
using System.Diagnostics;
using log4net;
using PowerPeg_SQL_to_CSV.Log;

namespace PowerPeg_SQL_to_CSV
{
    [Serializable]
    public class SearchTask
    {
        private static readonly ILog log = LogHelper.getLogger();

        private string taskName;

        private string outputLocation;

        private IMode operationMode;

        public IMode getMode()
        {
            return operationMode;
        }

        /// <summary>
        /// Create the schedule search task
        /// </summary>
        /// <param name="name">Name of the Task</param>
        /// <param name="outputLocation">The CSV output location</param>
        /// <param name="operationMode">The mode of the task operation</param>
        public SearchTask(string name, string outputLocation, IMode operationMode)
        {
            this.taskName = name + DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss");
            this.outputLocation = outputLocation;
            this.operationMode = operationMode;

            log.Debug("Created search class" + string.Join(",", this.getTaskInfo()));
        }

        /// <summary>
        /// Trigger the running of the search task
        /// </summary>
        /// <param name="runDateTime">Trigger DateTime</param>
        public void toRunTask(DateTime runDateTime)
        {
            log.Info($"Runing search on {this.taskName}");

            Result resultOfSQL = operationMode.runSearch(runDateTime);

            if(resultOfSQL != null)
            {
                log.Info($"Search task result generated, generate CSV file: {this.taskName}");

                string fileOutputFileName = taskName + "_generation_time_" + resultOfSQL.getGenerationTime().ToString("yyyy-MM-dd_HH-mm-ss");

                CSVGateway.getInstance().dataTable_to_CSV(fileOutputFileName, outputLocation, resultOfSQL.getResultTable());
            }
            else
            {
                log.Info($"No need to store the search task to CSV file: {this.taskName}");
            }
        }

        /// <summary>
        /// Get the information of the search task settings
        /// </summary>
        /// <returns>
        /// Return "Task Name", "Output Location", "-Mode Info-"
        /// --MonthMode--: "Mode Name", "Trigger Week of Day", "Trigger Hour", "Selection List"
        /// </returns>
        public string[] getTaskInfo()
        {
            string[] task = { taskName, outputLocation };
            string[] mode = operationMode.getInfo();

            return task.Concat(mode).ToArray();
        }

        /// <summary>
        /// Update the search task setting
        /// </summary>
        /// <param name="outputlocation">CSV file outputpath</param>
        /// <param name="mode">Mode of the search task</param>
        public void updateTaskSetting(string outputlocation, IMode mode)
        {
            log.Debug("Orginal search task setting" + string.Join(",", this.getTaskInfo()));

            outputLocation = outputlocation;
            operationMode = mode;
            
            log.Debug("New search task setting updated" + string.Join(",", this.getTaskInfo()));
        }

        public override string ToString()
        {
            return $"Task Name: {this.taskName}\r\nOutput Location: {this.outputLocation}\r\n{this.operationMode.ToString()}";
        }
    }
}
