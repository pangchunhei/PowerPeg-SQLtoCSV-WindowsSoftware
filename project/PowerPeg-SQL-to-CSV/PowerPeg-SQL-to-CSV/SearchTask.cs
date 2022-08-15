using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    public class SearchTask
    {
        private string taskName;
        
        private string outputLocation;

        private Mode operationMode;

        public Result outputResult { get; }

        public SearchTask(string outputLocation, Mode operationMode, string name = "Default")
        {
            this.taskName = name;
            this.outputLocation = outputLocation;
            this.operationMode = operationMode;
        }

        public Result toRun()
        {
            return operationMode.toRun();
        }

        public string[] getTaskInfo()
        {
            string[] task = { this.taskName, this.outputLocation };
            string[] mode = operationMode.getInfo();

            return task.Concat(mode).ToArray();
        }
    }
}
