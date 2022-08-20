using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Mode;
using PowerPeg_SQL_to_CSV.ProcessTask;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PowerPeg_SQL_to_CSV
{
    public static class MainFunction
    {
        private static ScheduleSearchTasklist scheduleSearchTasklist = new ScheduleSearchTasklist();
        
        private static BackgroundScheduler backgroundScheduler = null;
        
        private static DatabaseGateway databaseGateway = DatabaseGateway.getInstance();
        
        private static IMode CreateMode(string selectmode, DateTime triggerdate, List<string> selectedcolumn, DateTime? startdate = null, DateTime? enddate = null)
        {
            if (selectmode.Equals("InstantMode"))
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
            }
            else if (selectmode.Equals("MonthMode"))
            {
                return new MonthMode(triggerdate, selectedcolumn);
            }
            else if (selectmode.Equals("MinuteMode"))
            {
                return new MinuteMode(triggerdate, selectedcolumn);
            }
            else
            {
                //TODO-- No such mode
                throw new Exception();
            }
        }

        public static SearchTask CreateTask(string selectmodename, string outputlocation, DateTime triggerdate, List<string> selectedcolumn, DateTime? startdate = null, DateTime? enddate = null, string taskname = "default")
        {
            IMode m = CreateMode(selectmodename, triggerdate, selectedcolumn, startdate, enddate);

            string modifyName = Regex.Replace(taskname, @"(\s+|\.|\,|\:|\*|&|\?|\/|#|\\|%|\^|\$|@|!|\(|\))", "");

            return new SearchTask(modifyName, outputlocation, m);
        }

        public static void runTaskNow(SearchTask task)
        {
            task.toRunTask(DateTime.Now);
        }

        public static void updateTaskSetting(SearchTask searchtask, string selectmode, string outputlocation, DateTime triggerdate, List<string> selectedcolumn)
        {
            IMode m = CreateMode(selectmode, triggerdate, selectedcolumn);

            searchtask.updateTaskSetting(outputlocation, m);

            scheduleSearchTasklist.updateTask(searchtask);
        }

        public static SearchTask findTaskObject(string name)
        {
            return scheduleSearchTasklist.findSearchTask(name);
        }

        public static List<string> getCurrentTaskListName()
        {
            List<SearchTask> list = scheduleSearchTasklist.getCurrentTaskList();

            List<string> listName = new List<string>();

            foreach (SearchTask searchtask in list)
            {
                listName.Add(searchtask.getTaskInfo()[0]);
            }

            return listName;
        }

        public static void addScheduleTask(SearchTask searchtask)
        {
            scheduleSearchTasklist.addNewTask(searchtask);
        }

        public static void removeScheduleTask(SearchTask searchtask)
        {
            scheduleSearchTasklist.removeTask(searchtask);
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

        public static void startBackgroundJob()
        {
            backgroundScheduler = new BackgroundScheduler();
            _ = backgroundScheduler.runAsync();
        }

        public static async void reStartBackgroundJob()
        {
            stopBackgroundJob();

            startBackgroundJob();
        }

        public static async void stopBackgroundJob()
        {
            if(backgroundScheduler != null){
                await backgroundScheduler.stopAsync();
                backgroundScheduler = null;
            }else{
                //No task to stop
            }
        }

        public static List<string> getGenerationScheduledModeName()
        {
            List<string> modeNamelist = new List<string>();

            var type = typeof(IMode);
            var objectTypeList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p));

            foreach(var m in objectTypeList)
            {
                modeNamelist.Add(m.Name);
            }

            modeNamelist.Remove("InstantMode");
            modeNamelist.Remove("IMode");

            //Debug.WriteLine("==========================");
            Debug.WriteLine(string.Join("' ", modeNamelist));



            return modeNamelist;
        }
    }
}
