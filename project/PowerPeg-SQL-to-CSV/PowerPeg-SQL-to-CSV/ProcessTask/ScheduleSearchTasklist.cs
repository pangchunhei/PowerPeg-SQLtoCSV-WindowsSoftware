using log4net;
using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Log;
using PowerPeg_SQL_to_CSV.Mode;
using System.Diagnostics;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    public class ScheduleSearchTasklist
    {
        private List<SearchTask> searchTaskslist;
        private JSONGateway jsonGateway;
        private static readonly ILog log = LogHelper.getLogger();

        public ScheduleSearchTasklist()
        {
            this.jsonGateway = JSONGateway.getInstance();

            searchTaskslist = jsonGateway.importTasklist();
        }

        /// <summary>
        /// Show all the tasklist's seatch task name
        /// </summary>
        private void showSearchTasklist()
        {
            foreach (var task in searchTaskslist)
            {
                log.Debug(string.Join(", ", task.getTaskInfo()));
            }
        }

        /// <summary>
        /// Find the search task object from name
        /// </summary>
        /// <param name="selectedSearchTaskName">Name of the search task</param>
        /// <returns>Return SearchTask object from the tasklist</returns>
        public SearchTask findSearchTask(string selectedSearchTaskName)
        {
            foreach (var searchtask in searchTaskslist)
            {
                if (searchtask.getTaskInfo()[0].Equals(selectedSearchTaskName))
                {
                    return searchtask;
                }
            }

            return null;
        }

        /// <summary>
        /// Add new search task into tasklist, limit the schedule task to 3
        /// </summary>
        /// <param name="searchtask">New search task</param>
        /// <exception cref="Exception"></exception>
        public void addNewTask(SearchTask searchtask)
        {
            if (searchtask.getMode().GetType() != typeof(InstantMode))
            {
                //limit the schedule task to 3
                if (searchTaskslist.Count < 1)
                {
                    searchTaskslist.Add(searchtask);
                }
                else
                {
                    throw new Exception("Exceed max scheduled task allowed");
                }
            }
            else
            {
                throw new Exception("It is instant mode, cannot add to schedule task");
            }

            jsonGateway.updateTasklistJSON(searchTaskslist);
        }

        /// <summary>
        /// Remove search task from tasklist
        /// </summary>
        /// <param name="searchtask">Search task that want to be removed</param>
        public void removeTask(SearchTask searchtask)
        {

            searchTaskslist.Remove(searchtask);
            jsonGateway.updateTasklistJSON(searchTaskslist);
        }

        /// <summary>
        /// Update the search task setting
        /// </summary>
        /// <param name="searchtasktask">Search task that just updated</param>
        public void updateTask(SearchTask searchtasktask)
        {
            removeTask(searchtasktask);
            addNewTask(searchtasktask);
        }

        /// <summary>
        /// Get the list of search tasks
        /// </summary>
        /// <returns>Return the list of Search Task</returns>
        public List<SearchTask> getCurrentTaskList()
        {
            return searchTaskslist;
        }
    }
}
