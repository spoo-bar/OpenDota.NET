using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Players
{
    public class Player
    {
        public string TrackedUntil { get; private set; }

        public int SoloMMR { get; private set; }

        public int PartyMMR { get; private set; }

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
                SoloMMR = json.Value<int>("solo_competitive_rank", 0),
                PartyMMR = json.Value<int>("competitive_rank", 0),
                RankTier = json.Value<int>("rank_tier", 0),
                LeaderboardRank = json.Value<int>("leaderboard_rank", 0),
                MMREstimate = MMREstimate.Deserialize(json["mmr_estimate"]),
                Profile = Profile.Deserialize(json["profile"])
            };
        }
    }
}