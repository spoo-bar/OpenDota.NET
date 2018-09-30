using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Players
{
    public class Peer
    {
        public long AccountId { get; set; }

        public DateTime LastPlayed { get; set; }

        public int Win { get; set; }

        public int Games { get; set; }

        public int WithWin { get; set; }

        public int WithGames { get; set; }

        public int AgainstWin { get; set; }

        public int AgainstGames { get; set; }

        public int WithGPMSum { get; set; }

        public int WithXPMSum { get; set; }

        public string PersonaName { get; set; }

        public string LastLogin { get; set; }

        public Uri Avatar { get; set; }

        public Uri AvatarFull { get; set; }

        internal static Peer Deserialize(JToken json)
        {
            return new Peer
            {
                AccountId = json.Value<long>("account_id", 0),
                LastPlayed = DateTimeOffset.FromUnixTimeSeconds(json.Value<long>("last_played", 0)).DateTime,
                Win = json.Value<int>("win", 0),
                Games = json.Value<int>("games", 0),
                WithWin = json.Value<int>("with_win", 0),
                WithGames = json.Value<int>("with_games", 0),
                AgainstWin = json.Value<int>("against_win", 0),
                AgainstGames = json.Value<int>("against_games", 0),
                WithGPMSum = json.Value<int>("with_gpm_sum", 0),
                WithXPMSum = json.Value<int>("with_xpm_sum", 0),
                PersonaName = json.Value<string>("personaname"),
                LastLogin = json.Value<string>("last_login"),
                Avatar = new Uri(json.Value<string>("avatar")),
                AvatarFull = new Uri(json.Value<string>("avatarfull"))
            };
        }
    }
}