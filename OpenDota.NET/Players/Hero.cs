using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Players
{
    public class PlayerHeroStats
    {
        public int HeroId { get; private set; }

        public DateTime LastPlayed { get; private set; }

        public int Games { get; private set; }

        public int Win { get; private set; }

        public int WithGames { get; private set; }

        public int WithWin { get; private set; }

        public int AgainstGames { get; private set; }

        public int AgainstWin { get; private set; }

        internal static PlayerHeroStats Deserialize(JToken json)
        {
            return new PlayerHeroStats
            {
                HeroId = json.Value<int>("hero_id", 0),
                LastPlayed = DateTimeOffset.FromUnixTimeSeconds(json.Value<long>("last_played", 0)).DateTime,
                Games = json.Value<int>("games",0),
                Win = json.Value<int>("win",0),
                WithGames = json.Value<int>("with_games",0),
                WithWin = json.Value<int>("with_win",0),
                AgainstGames = json.Value<int>("against_games",0),
                AgainstWin = json.Value<int>("against_win",0),
            };
        }
    }
}