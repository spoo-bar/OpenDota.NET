using System;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Players
{
    public class Player
    {
        public string TrackedUntil { get; private set; }

        public string SoloCompetitiveRank { get; private set; }

        public int RankTier { get; private set; }

        public int LeaderboardRank { get; private set; }

        public MMREstimate MMREstimate { get; private set; }

        public Profile Profile { get; private set; }

        internal static Player Deserialize(string result)
        {
            var json = JObject.Parse(result);
            return new Player
            {
                TrackedUntil = json.Value<string>("tracked_until"),
                SoloCompetitiveRank = json.Value<string>("solo_competitive_rank"),
                RankTier = json.Value<int>("rank_tier"),
                LeaderboardRank = json.Value<int>("leaderboard_rank"),
                MMREstimate = MMREstimate.Deserialize(json["mmr_estimate"]),
                Profile = Profile.Deserialize(json["profile"])
            };
        }
    }
}