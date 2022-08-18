using PowerPeg_SQL_to_CSV.Gateway.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    public class ProcessScheduleTask
    {
        public ProcessScheduleTask() { }

        public void runAllScheduling(ScheduleTaskList scheduletasklist)
        {
            List<SearchTask>list = scheduletasklist.getCurrentTaskList();

            DateTime now = DateTime.Now;

            foreach(SearchTask task in list)
            {
                task.toRunTask(now);
            }
        }
    }
}
