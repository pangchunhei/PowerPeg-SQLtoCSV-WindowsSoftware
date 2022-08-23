using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PowerPeg_SQL_to_CSV.Log;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace PowerPeg_SQL_to_CSV.Gateway
{
    public class JSONGateway
    {
        private JSONGateway()
        {
            this.tasklistJsonPath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["Tasklist"];
            this.tableJsonPath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["Table"];
            log.Debug($"Setup JSON app data filepath {tasklistJsonPath}, {tableJsonPath}");
        }

        private static JSONGateway _instance;
        private static readonly object _lock = new object();
        private static readonly ILog log = LogHelper.getLogger();

        public static JSONGateway getInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new JSONGateway();
                    }
                }
            }
            return _instance;
        }

        private string tasklistJsonPath;
        private string tableJsonPath;   

        public List<SearchTask> importTasklist()
        {
            log.Info($"Import JSON tasklist data");

            using (StreamReader file = File.OpenText(tasklistJsonPath))
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

                if (list == null)
                {
                    return new List<SearchTask>();
                }
                else
                {
                    return list;
                }
            }
        }

        public List<string> importTable()
        {
            log.Info($"Import Table tasklist data");

            using (StreamReader file = File.OpenText(tasklistJsonPath))
            {
                var settings = new JsonSerializerSettings()
                {
                    //Handle private var
                    ContractResolver = new contractResolverSaveAll(),
                    //Handle inharance
                    TypeNameHandling = TypeNameHandling.All
                };
                JsonSerializer serializer = JsonSerializer.Create(settings);

                List<string> list = (List<string>)serializer.Deserialize(file, typeof(List<string>));

                if (list == null)
                {
                    return new List<string>();
                }
                else
                {
                    return list;
                }
            }
        }

        public void updateTasklistJSON(List<SearchTask> searchTasksList)
        {
            log.Info($"Update JSON tasklist data");

            lock (_lock)
            {
                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new contractResolverSaveAll(),
                    TypeNameHandling = TypeNameHandling.All
                };
                using (StreamWriter file = File.CreateText(this.tasklistJsonPath))
                {
                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    serializer.Serialize(file, searchTasksList);
                }
            }
        }

        public void updateTableJSON(List<string> tableList)
        {
            log.Info($"Update JSON table data");

            updateJSON(tableList, this.tableJsonPath);
        }

        public void updateJSON(object list, string filepath)
        {
            lock (_lock)
            {
                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new contractResolverSaveAll(),
                    TypeNameHandling = TypeNameHandling.All
                };
                using (StreamWriter file = File.CreateText(filepath))
                {
                    log.Info($"Update {filepath} JSON data");

                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    serializer.Serialize(file, list);
                }
            }
        }
    }

    public class contractResolverSaveAll : DefaultContractResolver
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
