using System.Collections.Generic;
using PowerPeg_SQL_to_CSV.Mode;
using PowerPeg_SQL_to_CSV.Gateway;
using System.Data;
using PowerPeg_SQL_to_CSV.Task;

namespace PowerPeg_SQL_to_CSV
{
    public static class MainFunction
    {
        public static ScheduleTaskList scheduleTaskList = new ScheduleTaskList();
        public static DatabaseGateway databaseGateway = DatabaseGateway.getInstance();

        public static void createTask(SearchTask task)
        {
            //Trigger the task
            if (task.getMode().GetType() == typeof(InstantMode))
            {
                //Instant run
                task.toRunTask();
            }
            else
            {
                //Schedule run
                scheduleTaskList.addNewTask(task);
            }
        }

        public static List<string> getCurrentTaskListName()
        {
            List<SearchTask> list = scheduleTaskList.getCurrentTaskList();

            List<string> listName = new List<string>();

            foreach(SearchTask task in list)
            {
                listName.Add(task.getTaskName());
            }

            return listName;
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

        private static SearchTask findTaskObject(string name)
        {
            return scheduleTaskList.findSearchTask(name);
        }

        public static void removeTask(SearchTask task)
        {
            scheduleTaskList.removeTask(task);
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
