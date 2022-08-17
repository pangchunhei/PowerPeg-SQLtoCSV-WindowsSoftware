using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PowerPeg_SQL_to_CSV
{
    public class ScheduleTaskList
    {
        private List<SearchTask> registeredTask;

        public ScheduleTaskList()
        {
            registeredTask = new List<SearchTask>();    
            //registeredTask = importJSONTaskList();
            
            test();
        }

        private List<SearchTask> importJSONTaskList()
        {
            List<SearchTask> createdTaskList = new List<SearchTask>();

            return createdTaskList;
        }

        private void updateJSON()
        {
            SearchTask s = registeredTask[0];

            Debug.WriteLine("Hi");

            Debug.WriteLine(JsonConvert.SerializeObject(registeredTask));
        }

        public void addNewTask(SearchTask task)
        {
            if(task.getMode().GetType() != typeof(InstantMode))
            {
                registeredTask.Add(task);
            }
        }

        public List<SearchTask> getTaskList()
        {
            return registeredTask;
        }

        private void test()
        {
            IList<string> s = new List<string>();
            s.Add("test");
            s.Add("r");
            SearchTask t = new SearchTask("C:\\Users\\elsto\\Desktop", new MonthMode(new DateTime(2022, 08, 17, 00, 00, 00), s));
            
            addNewTask(t);

            updateJSON();
        }
    }
}
