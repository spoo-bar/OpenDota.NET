using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Search
{
    public class PlayerResult
    {
        public long AccountId { get; set; }

        public string PersonaName { get; set; }

        public Uri AvatarFull { get; set; }

        public DateTime LastMatchTime { get; set; }

        public double Similarity { get; set; }

        internal static PlayerResult Deserialize(JToken json)
        {
            return new PlayerResult
            {
                AccountId = json.Value<long>("account_id"),
                PersonaName = json.Value<string>("personaname"),
                AvatarFull = new Uri(json.Value<string>("avatarfull")),
                LastMatchTime = json.Value<DateTime>("last_match_time", default(DateTime)),
                Similarity = json.Value<double>("similarity"),
            };
        }
    }
}
