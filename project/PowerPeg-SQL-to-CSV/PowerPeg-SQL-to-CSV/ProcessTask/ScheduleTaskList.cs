using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PowerPeg_SQL_to_CSV.Mode;
using PowerPeg_SQL_to_CSV.Gateway;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PowerPeg_SQL_to_CSV.ProcessTask
{
    public class ScheduleTasklist
    {
        private List<SearchTask> searchTasksList;
        private JSONGateway jsonGateway;
        public ScheduleTasklist()
        {
            this.jsonGateway = JSONGateway.getInstance();

            searchTasksList = jsonGateway.importTasklist();

            showTaskList();
        }

        private void showTaskList()
        {
            foreach (var task in searchTasksList)
            {
                Debug.WriteLine("> " + string.Join(", ", task.getTaskInfo()));
            }
        }

        public SearchTask findSearchTask(string selectedTaskName)
        {
            foreach (var task in searchTasksList)
            {
                if (task.getTaskInfo()[0].Equals(selectedTaskName))
                {
                    return task;
                }
            }

            return null;
        }

        public void addNewTask(SearchTask task)
        {
            if (task.getMode().GetType() != typeof(InstantMode))
            {
                searchTasksList.Add(task);
            }
            else
            {
                //TODO-- Exception
                throw new Exception();
            }

            jsonGateway.updateJSON(searchTasksList);
        }

        public void removeTask(SearchTask task)
        {

            searchTasksList.Remove(task);
            jsonGateway.updateJSON(searchTasksList);
        }

        public void updateTask(SearchTask task)
        {
            removeTask(task);
            addNewTask(task);
        }

        public List<SearchTask> getCurrentTaskList()
        {
            return searchTasksList;
        }
    }
}
