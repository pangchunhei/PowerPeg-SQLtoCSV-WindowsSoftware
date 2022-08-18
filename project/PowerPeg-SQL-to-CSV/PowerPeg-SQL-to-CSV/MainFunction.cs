using System.Collections.Generic;
using PowerPeg_SQL_to_CSV.Gateway;
using System.Data;
using PowerPeg_SQL_to_CSV.ProcessTask;
using PowerPeg_SQL_to_CSV.Mode;
using System.Linq.Expressions;
using System.Diagnostics;

namespace PowerPeg_SQL_to_CSV
{
    public static class MainFunction
    {
        public static ScheduleTaskList scheduleTaskList = new ScheduleTaskList();
        public static DatabaseGateway databaseGateway = DatabaseGateway.getInstance();

        public static SearchTask CreateTask(int selectmode, string outputlocation, DateTime triggerdate, List<string> selectedcolumn, DateTime? startdate = null, DateTime? enddate = null, string taskname = "default") {
            IMode m = null;

            switch (selectmode)
            {
                case 1:
                    if(startdate != null && enddate != null)
                    {
                        m = new InstantMode((DateTime)startdate, (DateTime)enddate, triggerdate, selectedcolumn);
                    }
                    else
                    {
                        //TODO-- incorrect data type;
                        throw new Exception();
                    }
                    
                    break;
                case 2:
                    // code block
                    break;
                default:
                    // code block
                    break;
            }

            return new SearchTask(taskname, outputlocation, m);
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

        public static void updateTaskSetting(SearchTask task, string outputLocation, IMode mode)
        {
            task.updateTaskSetting(outputLocation, mode);

            scheduleTaskList.updateTask(task);
        }

        public static SearchTask findTaskObject(string name)
        {
            return scheduleTaskList.findSearchTask(name);
        }

        public static void removeTask(SearchTask task)
        {
            scheduleTaskList.removeTask(task);
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
