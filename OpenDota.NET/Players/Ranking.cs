using System;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Players
{
    public class Ranking
    {
        public int HeroId { get; private set; }

        public double Score { get; private set; }

        public double PercentRank { get; private set; }

        public int Card { get; private set; }

        internal static Ranking Deserialize(JToken json)
        {
            return new Ranking
            {
                HeroId = json.Value<int>("hero_id"),
                Score = json.Value<double>("score"),
                PercentRank = json.Value<double>("percent_rank"),
                Card = json.Value<int>("card")
            };
        }
    }
}