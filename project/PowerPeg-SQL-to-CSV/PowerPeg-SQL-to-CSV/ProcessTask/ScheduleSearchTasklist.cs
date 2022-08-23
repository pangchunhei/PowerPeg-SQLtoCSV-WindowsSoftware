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

        private void showSearchTasklist()
        {
            foreach (var task in searchTaskslist)
            {
                log.Debug(string.Join(", ", task.getTaskInfo()));
            }
        }

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

        public void addNewTask(SearchTask searchtask)
        {
            if (searchtask.getMode().GetType() != typeof(InstantMode))
            {
                searchTaskslist.Add(searchtask);
            }
            else
            {
                //TODO-- Exception
                throw new Exception();
            }

            jsonGateway.updateTasklistJSON(searchTaskslist);
        }

        public void removeTask(SearchTask searchtask)
        {

            searchTaskslist.Remove(searchtask);
            jsonGateway.updateTasklistJSON(searchTaskslist);
        }

        public void updateTask(SearchTask searchtasktask)
        {
            removeTask(searchtasktask);
            addNewTask(searchtasktask);
        }

        public List<SearchTask> getCurrentTaskList()
        {
            return searchTaskslist;
        }
    }
}
