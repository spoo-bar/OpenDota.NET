using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;
using System;

namespace OpenDota.NET.Heroes
{
    public class Player
    {
        public long AccountId { get; set; }

        public double Score { get; set; }

        public string PersonaName { get; set; }

        public string Name { get; set; }

        public Uri Avatar { get; set; }

        public DateTime LastLogin { get; set; }

        public int RankTier { get; set; }

        internal static Player Deserialize(JToken json)
        {
            return new Player
            {
                AccountId = json.Value<long>("account_id"),
                Score = json.Value<double>("score"),
                PersonaName = json.Value<string>("personaname"),
                Name = json.Value<string>("name"),
                Avatar = new Uri(json.Value<string>("avatar")),
                LastLogin = json.Value<DateTime>("last_login", default(DateTime)),
                RankTier = json.Value<int>("rank_tier")
            };
        }
    }
}
