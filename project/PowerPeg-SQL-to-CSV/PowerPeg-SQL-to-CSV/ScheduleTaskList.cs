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

            searchTasksList = new List<SearchTask>();

            
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
                searchTasksList = (List<SearchTask>)serializer.Deserialize(file, typeof(List<SearchTask>));
            }
            

            test();

            foreach(var task in searchTasksList)
            {
                Debug.WriteLine("> " + String.Join(", ", task.getTaskInfo()));
            }
        }

        public void addNewTask(SearchTask task)
        {
            /*
            if(task.getMode().GetType() != typeof(InstantMode))
            {
                searchTasksList.Add(task); 
            }
            else
            {
                //TODO-- Exception
                throw new Exception();
            }*/

            searchTasksList.Add(task);

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

        }

        public List<SearchTask> getCurrentTaskList()
        {
            return searchTasksList;
        }

        private void test()
        {
            List<string> s = new List<string>();
            s.Add("*");
            SearchTask t = new SearchTask("C:\\Users\\elsto\\Desktop", new MonthMode(new DateTime(2022, 08, 17, 00, 00, 00), s));

            addNewTask(t);

            s.Clear();
            s.Add("new");
            s.Add("try");
            SearchTask t2 = new SearchTask("C:\\Users\\elsto", new InstantMode(new DateTime(2022, 08, 17, 00, 00, 00), new DateTime(2022, 08, 17, 00, 00, 00), new DateTime(2022, 08, 17, 00, 00, 00), s));
            addNewTask(t2);
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
