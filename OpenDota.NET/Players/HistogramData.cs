using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Players
{
    public class HistogramData
    {
        public int X { get; private set; }

        public int Games { get; private set; }

        public int Wins { get; private set; }

        internal static HistogramData Deserialize(JToken json)
        {
            return new HistogramData
            {
                X = json.Value<int>("x", 0),
                Games = json.Value<int>("games", 0),
                Wins = json.Value<int>("win", 0)
            };
        }
    }
}