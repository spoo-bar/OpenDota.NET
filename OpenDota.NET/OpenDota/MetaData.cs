using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET
{
    public class MetaData
    {
        public Scenarios Scenarios { get; private set; }

        public dynamic Banner { get; private set; }

        public int Cheese { get; private set; }

        public int Goal { get; private set; }

        internal static MetaData Deserialize(string result)
        {
            var json = JObject.Parse(result);
            return new MetaData
            {
                Scenarios = Scenarios.Deserialize(json["scenarios"]),
                Banner = json.Value<dynamic>("banner"),
                Cheese = json["cheese"].Value<int>("cheese", 0),
                Goal = json["cheese"].Value<int>("goal", 0)
            };
        }
    }
}