using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Players
{
    public class Rating
    {
        public long AccountId { get; private set; }

        public long MatchId { get; private set; }

        public int SoloCompetitiveRank { get; private set; }

        public int CompetitiveRank { get; private set; }

        public DateTime Time { get; private set; }

        internal static Rating Deserialize(JToken json)
        {
            return new Rating
            {
                AccountId = json.Value<long>("account_id", 0),
                MatchId = json.Value<long>("match_id", 0),
                SoloCompetitiveRank = json.Value<int>("solo_competitive_rank", 0),
                CompetitiveRank = json.Value<int>("competitive_rank", 0),
                Time = json.Value<DateTime>("time")
            };
        }
    }
}