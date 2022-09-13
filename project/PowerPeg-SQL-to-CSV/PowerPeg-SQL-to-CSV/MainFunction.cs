using log4net;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Mode;
using PowerPeg_SQL_to_CSV.ProcessTask;
using System.Diagnostics;
using System.Text.RegularExpressions;
using PowerPeg_SQL_to_CSV.Log;
using Quartz;

namespace PowerPeg_SQL_to_CSV
{
    public static class MainFunction
    {
        private static readonly ILog log = LogHelper.getLogger();

        private static ScheduleSearchTasklist scheduleSearchTasklist = new ScheduleSearchTasklist();
        
        private static BackgroundScheduler backgroundScheduler = null;
        
        private static DatabaseGateway databaseGateway = DatabaseGateway.getInstance();


        /*
        /// <summary>
        /// Create the mode object
        /// TODO-- If have new mode, need to update here
        /// </summary>
        /// <param name="selectmode">Select the mode of "InstantMode" or "MonthMode" or "MinuteMode"(For testing)</param>
        /// <param name="triggerdate">Select the first time to trigger datetime</param>
        /// <param name="selectedcolumn">Provide the list of selected column name</param>
        /// <param name="startdate">(For instant mode) Select the specific start datetime</param>
        /// <param name="enddate">(For instant mode)Select the specific end datetime</param>
        /// <param name="selectThis">(For Month mode) Select the duration, for the true: use trigger month's day; for false, use trigger month's previous month day</param>
        /// <returns>Return the specific mode object</returns>
        /// <exception cref="Exception"></exception>
        private static IMode CreateMode(string selectmode, List<string> selectedcolumn, DateTime? startdate = null, DateTime? enddate = null, bool? selectThis = null)
        {
            log.Debug("Run CreateMode");

            if (selectmode.Equals("InstantMode"))
            {
                if (startdate != null && enddate != null)
                {
                    return new InstantMode((DateTime)startdate, (DateTime)enddate, selectedcolumn);
                }
                else
                {
                    throw new Exception("Incorrect data type for instant mode");
                }
            }
            else if (selectmode.Equals("MonthMode"))
            {
                if(selectThis != null)
                {
                    return new MonthMode(triggerdate, (bool)selectThis, selectedcolumn);
                }
                else
                {
                    throw new Exception("TODO-- Need to have selectThis boolean");
                }
            }
            else if (selectmode.Equals("TestMode"))
            {
                return new TestMode(triggerdate, selectedcolumn);
            }
            else
            {
                throw new Exception("No such mode");
            }
        }
        */

        public static IMode createInstantMode(DateTime startdate, DateTime enddate, List<string> selectedcolumn)
        {
            return new InstantMode(startdate, enddate, selectedcolumn);
        }

        public static IMode createMonthMode(DayOfWeek triggerDayOfWeek, TimeOnly triggerHour, List<string> selectedcolumn)
        {
            return new MonthMode(triggerDayOfWeek, triggerHour, selectedcolumn);
        }

        public static IMode createTestMode(DateTime, List<string> selectedcolumn)
        {
            return new TestMode(triggerDateTime, selectedcolumn);
        }

        /// <summary>
        /// Create new search task
        /// </summary>
        /// <param name="selectmodename">Select the mode of "InstantMode" or "MonthMode" or "TestMode"(For testing)</param>
        /// <param name="outputlocation">Select the wanted CSV location</param>
        /// <param name="triggerdate">Select the first time to trigger datetime</param>
        /// <param name="selectedcolumn">Provide the list of selected column name</param>
        /// <param name="startdate">(For instant mode) Select the specific start datetime</param>
        /// <param name="enddate">(For instant mode) Select the specific end datetime</param>
        /// <param name="selectThis">(For Month mode) Select the duration, for the true: use trigger month's day; for false, use trigger month's previous month day</param>
        /// <param name="taskname">(Optional) Search task name</param>
        /// <returns>Return search task object</returns>
        public static SearchTask CreateTask(string selectmodename, string outputlocation, DateTime triggerdate, List<string> selectedcolumn, DateTime? startdate = null, DateTime? enddate = null, bool? selectThis = null, string taskname = "default")
        {
            log.Debug("Run CreateTask");

            IMode m = CreateMode(selectmodename, triggerdate, selectedcolumn, startdate, enddate, selectThis);

            string modifyName = Regex.Replace(taskname, @"(\s+|\.|\,|\:|\*|&|\?|\/|#|\\|%|\^|\$|@|!|\(|\))", "");

            return new SearchTask(modifyName, outputlocation, m);
        }

        /// <summary>
        /// Trigger the running if the task in the currnt time
        /// </summary>
        /// <param name="task">Search task that wanted to run now</param>
        public static async Task runTaskNow(SearchTask task)
        {
            log.Debug("Run runTaskNow in async");

            await Task.Run(() => task.toRunTask(DateTime.Now));
        }

        /// <summary>
        /// Update the search task setting
        /// </summary>
        /// <param name="searchtask">Search task object that wanted to be updated</param>
        /// <param name="selectmode">Updated mode</param>
        /// <param name="outputlocation">Updated CSV file location</param>
        /// <param name="triggerdate">Updated first time trigger date</param>
        /// <param name="selectThis">(For Month mode) Select the duration, for the true: use trigger month's day; for false, use trigger month's previous month day</param>
        /// <param name="selectedcolumn">Updated list of selected column</param>
        public static void updateTaskSetting(SearchTask searchtask, string selectmode, string outputlocation, DateTime triggerdate, List<string> selectedcolumn, bool? selectThis = null)
        {
            log.Debug("Run updateTaskSetting");

            IMode m = CreateMode(selectmode, triggerdate, selectedcolumn, selectThis: selectThis);

            searchtask.updateTaskSetting(outputlocation, m);

            scheduleSearchTasklist.updateTask(searchtask);
        }

        /// <summary>
        /// Find the seatch task object from name
        /// </summary>
        /// <param name="name">Name of the search task</param>
        /// <returns>Return SearchTask object from the tasklist</returns>
        public static SearchTask findTaskObject(string name)
        {
            return scheduleSearchTasklist.findSearchTask(name);
        }

        /// <summary>
        /// Get the lsit of current search task in tasklist
        /// </summary>
        /// <returns>List of search task's name</returns>
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

        /// <summary>
        /// Add new search task into tasklist
        /// </summary>
        /// <param name="searchtask">New search task</param>
        public static void addScheduleTask(SearchTask searchtask)
        {
            log.Debug("Run addScheduleTask");

            scheduleSearchTasklist.addNewTask(searchtask);
        }

        /// <summary>
        /// Remove search task from tasklist
        /// </summary>
        /// <param name="searchtask">Search task that want to be removed</param>
        public static void removeScheduleTask(SearchTask searchtask)
        {
            log.Debug("Run removeScheduleTask");

            scheduleSearchTasklist.removeTask(searchtask);
        }

        /// <summary>
        /// Update and test the Database communcation setting with new connection string.
        /// </summary>
        /// <param name="connectionString">The updated connection string</param>
        /// <returns></returns>
        public static bool updateDatabaseGateway(string connectionString)
        {
            log.Debug("Run updateDatabaseGateway");

            return databaseGateway.updateGateway(connectionString);
        }

        /// <summary>
        /// Get the current connection information
        /// </summary>
        /// <returns>Return the value of "Address", "Catalog", "full string"</returns>
        public static string[] getDatabaseInformation()
        {
            return databaseGateway.getGatewayInfo();
        }

        /// <summary>
        /// Run the stored procedures search and Get the list of the database column name
        /// </summary>
        /// <returns>List of database column name string</returns>
        /*
        public static List<string> getDatabaseColumnName()
        {
            return databaseGateway.getDBTableColName();
        }
        */

        /// <summary>
        /// Start the running of the background jobs
        /// </summary>
        /// <returns></returns>
        public static async Task startBackgroundJob()
        {
            log.Debug("Run startBackgroundJob");

            backgroundScheduler = new BackgroundScheduler();
            await backgroundScheduler.runAsync();
        }

        /// <summary>
        /// Restart the running of the background jobs
        /// </summary>
        /// <returns></returns>
        public static async Task reStartBackgroundJob()
        {
            log.Debug("Run reStartBackgroundJob");

            await stopBackgroundJob();

            await startBackgroundJob();
        }

        /// <summary>
        /// Stop the running of the background jobs
        /// </summary>
        /// <returns></returns>
        public static async Task stopBackgroundJob()
        {
            log.Debug("Run stopBackgroundJob");

            if (backgroundScheduler != null){
                log.Debug("Have background task, stopping background task");

                await backgroundScheduler.stopAsync();
                backgroundScheduler = null;
            }else{
                //No task to stop
                log.Debug("No background task to stop");
            }
        }

        /// <summary>
        /// Create a list of mode name that users can select
        /// </summary>
        /// <returns></returns>
        public static List<string> getGenerationScheduledModeName()
        {
            List<string> modeNamelist = new List<string>();

            var type = typeof(IMode);
            var objectTypeList = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p));

            foreach(var m in objectTypeList)
            {
                modeNamelist.Add(m.Name);
            }

            log.Debug("Mode list: " + string.Join(", ", modeNamelist));
            
            modeNamelist.Remove("InstantMode");
            modeNamelist.Remove("IMode");

            return modeNamelist;
        }

        /// <summary>
        /// Update the selected Database table list
        /// </summary>
        /// <param name="selectedTableNameList">Name of the table</param>
        public static void updateDatabaseSelectedTable(List<string> selectedTableNameList)
        {
            databaseGateway.updateSelectedTableList(selectedTableNameList);
        }

        /// <summary>
        /// Get the list of selected Database table
        /// </summary>
        /// <returns>List of selected Database table name string</returns>
        public static List<string> getDatabaseSelectedTable()
        {
            return databaseGateway.getSelectedTable();
        }
    }
}
