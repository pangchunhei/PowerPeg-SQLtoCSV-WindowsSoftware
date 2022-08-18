using System.Collections.Generic;
using PowerPeg_SQL_to_CSV.Gateway;
using System.Data;
using PowerPeg_SQL_to_CSV.ProcessTask;
using PowerPeg_SQL_to_CSV.Mode;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PowerPeg_SQL_to_CSV
{
    public static class MainFunction
    {
        public static ScheduleTaskList scheduleTaskList = new ScheduleTaskList();
        public static DatabaseGateway databaseGateway = DatabaseGateway.getInstance();
        
        private static IMode CreateMode(string selectmode, DateTime triggerdate, List<string> selectedcolumn, DateTime? startdate = null, DateTime? enddate = null)
        {
            if (selectmode.Equals("Instant"))
            {
                if (startdate != null && enddate != null)
                {
                    return new InstantMode((DateTime)startdate, (DateTime)enddate, triggerdate, selectedcolumn);
                }
                else
                {
                    //TODO-- incorrect data type for instant mode;
                    throw new Exception();
                }
            }else if (selectmode.Equals("Month"))
            {
                return new MonthMode(triggerdate, selectedcolumn);
            }
            else
            {
                //TODO-- No mode
                throw new Exception();
            }
        }

        public static SearchTask CreateTask(string selectmodename, string outputlocation, DateTime triggerdate, List<string> selectedcolumn, DateTime? startdate = null, DateTime? enddate = null, string taskname = "default") {
            IMode m = CreateMode(selectmodename, triggerdate, selectedcolumn, startdate, enddate);

            string modifyName = Regex.Replace(taskname, @"(\s+|\.|\,|\:|\*|&|\?|\/|#|\\|%|\^|\$|@|!|\(|\))", "");

            return new SearchTask(modifyName, outputlocation, m);
        }

        public static void runTaskNow(SearchTask task)
        {
            task.toRunTask();
        }

        public static void taskNotCreated()
        {
            //Not implememeted
        }

        public static void discardTask()
        {
            //Not implememeted
        }

        public static void updateTaskSetting(SearchTask task, string selectmode, string outputlocation, DateTime triggerdate, List<string> selectedcolumn)
        {
            IMode m = CreateMode(selectmode, triggerdate, selectedcolumn);

            task.updateTaskSetting(outputlocation, m);

            scheduleTaskList.updateTask(task);
        }

        public static SearchTask findTaskObject(string name)
        {
            return scheduleTaskList.findSearchTask(name);
        }

        
        public static List<string> getCurrentTaskListName()
        {
            List<SearchTask> list = scheduleTaskList.getCurrentTaskList();

            List<string> listName = new List<string>();

            foreach (SearchTask task in list)
            {
                listName.Add(task.getTaskInfo()[0]);
            }

            return listName;
        }

        public static void addScheduleTask(SearchTask task)
        {
            scheduleTaskList.addNewTask(task);
        }


        public static void removeTask(SearchTask task)
        {
            scheduleTaskList.removeTask(task);
        }


        public static bool updateDatabaseGateway(string address, string catalog, string username, string password)
        {
            return databaseGateway.updateGateway(address, catalog, username, password);
        }

        public static string[] getDatabaseInformation()
        {
            return databaseGateway.getGatewayInfo();
        }

        public static List<string> getDatabaseColumnName()
        {
            return databaseGateway.getDBTableColName();
        }
            
    }
}
