using System;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Players
{
    public class MMREstimate
    {
        public int Estimate { get; private set; }

        public int StdDev { get; private set; }

        public int N { get; private set; }

        internal static MMREstimate Deserialize(JToken json)
        {
            return new MMREstimate
            {
                Estimate = json.Value<int>("estimate"),
                StdDev = json.Value<int>("stdDev"),
                N = json.Value<int>("n"),
            };
        }
    }
}