using System.Collections.Generic;

namespace PowerPeg_SQL_to_CSV
{
    public static class MainFunction
    {
        public static ScheduleTaskList scheduleTaskList = new ScheduleTaskList();

        public static void createTask(SearchTask task)
        {
            //Trigger the task
            if (task.getMode().GetType() == typeof(InstantMode))
            {
                //Instant run
                task.toRun();
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

        public static void updateSearchTaskSetting(SearchTask task, string outputLocation, DateTime triggerDate, List<String> selection)
        {
            Mode mode = new MonthMode(triggerDate, selection);
            task.updateSearchTask(outputLocation, mode);

            scheduleTaskList.updateTask(task);
        }

        public static SearchTask findSearchTask(string name)
        {
            return scheduleTaskList.findSearchTask(name);
        }

        public static void removeSearchTask(SearchTask task)
        {
            scheduleTaskList.removeTask(task);
        }
    }
}
