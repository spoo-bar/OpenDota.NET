using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET
{
    public class Scenarios
    {
        public int ItemCost { get; private set; }

        public IEnumerable<int> Timings { get; private set; }

        public IEnumerable<int> GameDurationBucket { get; private set; }

        public IEnumerable<string> TeamScenariosQueryParams { get; private set; }

        internal static Scenarios Deserialize(JToken json)
        {
            return new Scenarios
            {
                ItemCost = json.Value<int>("itemCost"),
                Timings = GetIEnumerables<int>(json["timings"]),
                GameDurationBucket = GetIEnumerables<int>(json["gameDurationBucket"]),
                TeamScenariosQueryParams = GetIEnumerables<string>(json["teamScenariosQueryParams"])
            };
        }

        private static IEnumerable<T> GetIEnumerables<T>(JToken json)
        {
            var list = new List<T>();
            foreach(var obj in json)
            {
                list.Add(obj.Value<T>());
            }
            return list;
        }
    }
}