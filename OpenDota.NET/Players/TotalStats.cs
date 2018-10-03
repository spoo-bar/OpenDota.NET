using System;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Players
{
    public class TotalStats
    {
        public string Key { get; private set; }

        public Value Values { get; private set; }

        internal static TotalStats Deserialize(JToken json)
        {
            return new TotalStats
            {
                Key = json.Value<string>("field"),
                Values = Value.Deserialize(json)
            };
        }

        public class Value
        {
            public int N { get; private set; }

            public int Sum { get; private set; }

            internal static Value Deserialize(JToken json)
            {
                return new Value
                {
                    N = json.Value<int>("n"),
                    Sum = json.Value<int>("sum"),
                };
            }
        }
    }
}