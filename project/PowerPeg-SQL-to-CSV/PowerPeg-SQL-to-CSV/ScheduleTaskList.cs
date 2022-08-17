using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PowerPeg_SQL_to_CSV
{
    public class ScheduleTaskList
    {
        private List<SearchTask> searchTasksList;
        private string jsonPath;

        public ScheduleTaskList()
        {
            jsonPath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["JSON"];
            Debug.WriteLine(jsonPath);

            searchTasksList = importTasklist();

            showTaskList();
        }

        private List<SearchTask> importTasklist()
        {
            using (StreamReader file = File.OpenText(this.jsonPath))
            {
                var settings = new JsonSerializerSettings()
                {
                    //Handle private var
                    ContractResolver = new contractResolverSaveAll(),
                    //Handle inharance
                    TypeNameHandling = TypeNameHandling.All
                };
                JsonSerializer serializer = JsonSerializer.Create(settings);

                List<SearchTask> list = (List<SearchTask>)serializer.Deserialize(file, typeof(List<SearchTask>));

                if(list == null)
                {
                    return new List<SearchTask>();
                }
                else
                {
                    return list;
                }
            }
        }

        private void showTaskList()
        {
            foreach (var task in searchTasksList)
            {
                Debug.WriteLine("> " + String.Join(", ", task.getTaskInfo()));
            }
        }

        public SearchTask findSearchTask(string selectedTaskName)
        {
            foreach (var task in searchTasksList)
            {
                if (task.getTaskName().Equals(selectedTaskName))
                {
                    return task;
                }
            }

            return null;
        }

        public void addNewTask(SearchTask task)
        {
            if(task.getMode().GetType() != typeof(InstantMode))
            {
                searchTasksList.Add(task); 
            }
            else
            {
                //TODO-- Exception
                throw new Exception();
            }

            updateJSON();
        }

        private void updateJSON()
        {
            var settings = new JsonSerializerSettings() { 
                ContractResolver = new contractResolverSaveAll(),
                TypeNameHandling = TypeNameHandling.All
            };
            using (StreamWriter file = File.CreateText(this.jsonPath))
            {
                JsonSerializer serializer = JsonSerializer.Create(settings);
                serializer.Serialize(file, this.searchTasksList);
            }
        }

        public void removeTask(SearchTask task)
        {

            this.searchTasksList.Remove(task);
            updateJSON();
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

    public class contractResolverSaveAll : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                            .Select(p => base.CreateProperty(p, memberSerialization))
                        .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                   .Select(f => base.CreateProperty(f, memberSerialization)))
                        .ToList();
            props.ForEach(p => { p.Writable = true; p.Readable = true; });
            return props;
        }
    }
}
