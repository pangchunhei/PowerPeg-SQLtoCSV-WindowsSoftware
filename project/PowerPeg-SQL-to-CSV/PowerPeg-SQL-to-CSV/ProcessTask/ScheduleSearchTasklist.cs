using PowerPeg_SQL_to_CSV.Gateway;
using PowerPeg_SQL_to_CSV.Mode;
using System.Diagnostics;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    public class ScheduleSearchTasklist
    {
        private List<SearchTask> searchTaskslist;
        private JSONGateway jsonGateway;
        public ScheduleSearchTasklist()
        {
            this.jsonGateway = JSONGateway.getInstance();

            searchTaskslist = jsonGateway.importTasklist();

            showSearchTasklist();
        }

        private void showSearchTasklist()
        {
            foreach (var task in searchTaskslist)
            {
                Debug.WriteLine("> " + string.Join(", ", task.getTaskInfo()));
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

            jsonGateway.updateJSON(searchTaskslist);
        }

        public void removeTask(SearchTask searchtask)
        {

            searchTaskslist.Remove(searchtask);
            jsonGateway.updateJSON(searchTaskslist);
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
