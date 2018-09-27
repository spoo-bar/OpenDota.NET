using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

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
                Estimate = json.Value<int>("estimate", 0),
                StdDev = json.Value<int>("stdDev", 0),
                N = json.Value<int>("n", 0),
            };
        }
    }
}