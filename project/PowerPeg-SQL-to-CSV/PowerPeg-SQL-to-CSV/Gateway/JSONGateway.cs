using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;

namespace PowerPeg_SQL_to_CSV.Gateway
{
    public class JSONGateway
    {
        private JSONGateway()
        {
            this.jsonPath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["JSON"];
            Debug.WriteLine(jsonPath);
        }

        private static JSONGateway _instance;
        private static readonly object _lock = new object();

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

        private string jsonPath;

        public List<SearchTask> importTasklist()
        {
            using (StreamReader file = File.OpenText(jsonPath))
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

        public void updateJSON(List<SearchTask> searchTasksList)
        {
            lock (_lock)
            {
                var settings = new JsonSerializerSettings()
                {
                    ContractResolver = new contractResolverSaveAll(),
                    TypeNameHandling = TypeNameHandling.All
                };
                using (StreamWriter file = File.CreateText(this.jsonPath))
                {
                    JsonSerializer serializer = JsonSerializer.Create(settings);
                    serializer.Serialize(file, searchTasksList);
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
