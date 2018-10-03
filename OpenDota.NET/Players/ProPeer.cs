using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Players
{
    public class ProPeer : Peer
    {
        public string Name { get; private set; }

        public string CountryCode { get; private set; }

        public int FantasyRole { get; private set; }

        public long TeamId { get; private set; }

        public string TeamName { get; private set; }

        public string TeamTag { get; private set; }

        public bool IsLocked { get; private set; }

        public bool IsPro { get; private set; }

        public DateTime LockedUntil { get; private set; }

        public long SteamId { get; private set; }

        public Uri AvatarMedium { get; private set; }

        public Uri ProfileUrl { get; private set; }

        internal new static ProPeer Deserialize(JToken json)
        {
            var peer = Peer.Deserialize(json);
            return new ProPeer
            {
                AccountId = peer.AccountId,
                Name = json.Value<string>("name"),
                CountryCode = json.Value<string>("country_code"),
                FantasyRole = json.Value<int>("fantasy_role", 0),
                TeamId = json.Value<long>("team_id", 0),
                TeamName = json.Value<string>("team_name"),
                TeamTag = json.Value<string>("team_tag"),
                IsLocked = json.Value<bool>("is_locked", false),
                IsPro = json.Value<bool>("is_pro", false),
                LockedUntil = DateTimeOffset.FromUnixTimeSeconds(json.Value<long>("locked_until", 0)).DateTime,
                SteamId = json.Value<long>("steam_id", 0),
                Avatar = peer.Avatar,
                AvatarMedium = new Uri(json.Value<string>("avatarmedium")),
                AvatarFull = peer.AvatarFull,
                ProfileUrl = new Uri(json.Value<string>("profileurl")),
                PersonaName = peer.PersonaName,
                LastPlayed = peer.LastPlayed,
                Win = peer.Win,
                Games = peer.Games,
                WithWin = peer.WithWin,
                WithGames = peer.WithGames,
                AgainstWin = peer.AgainstWin,
                AgainstGames = peer.AgainstGames,
                WithGPMSum = peer.WithGPMSum,
                WithXPMSum = peer.WithXPMSum,
                LastLogin = peer.LastLogin
            };
        }
    }
}