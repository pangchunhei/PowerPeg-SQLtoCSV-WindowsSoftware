using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPeg_SQL_to_CSV
{
    public static class MainFunction
    {
        public static void runTask(SearchTask task)
        {
            //Trigger the task
            if (task.getMode().GetType() == typeof(InstantMode))
            {
                task.toRun();
            }
            else
            {
                //TODO-- Store and Run
            }
        }

        public static void taskNotCreated()
        {
            //Not implememeted
        }

        public static void discardTask()
        {
            //Not implememeted
        }

        public static void processScheduleTask()
        {

        }
    }
}
