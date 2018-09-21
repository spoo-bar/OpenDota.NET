using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Players
{
    public class ProPlayer
    {
        /// <summary>
        /// Player’s account identifier
        /// </summary>
        public long AccountId { get; private set; }

        /// <summary>
        /// Player’s steam identifier
        /// </summary>
        public string SteamId { get; private set; }

        /// <summary>
        /// Steam picture URL (small picture)
        /// </summary>
        public Uri AvatarSmall { get; private set; }

        /// <summary>
        /// Steam picture URL (medium picture)
        /// </summary>
        public Uri AvatarMedium { get; private set; }

        /// <summary>
        /// Steam picture URL (full picture)
        /// </summary>
        public Uri AvatarFull { get; private set; }

        /// <summary>
        /// Steam profile URL
        /// </summary>
        public Uri SteamProfileUrl { get; private set; }

        /// <summary>
        /// Player’s Steam name
        /// </summary>
        public string PersonaName { get; private set; }

        /// <summary>
        //  Date and time of last request to refresh player’s match history
        /// </summary>
        public DateTime FullHistoryTime { get; private set; }

        /// <summary>
        /// Whether the refresh of player’ match history failed
        /// </summary>
        public bool PlayerMatchHistoryRefreshFailed { get; private set; }

        /// <summary>
        /// Player’s country identifier, e.g. US
        /// </summary>
        public string Country { get; private set; }

        /// <summary>
        /// Verified player name, e.g. 'Miracle-'
        /// </summary>
        public string VerifiedName { get; private set; }

        /// <summary>
        /// Player’s country code
        /// </summary>
        public string CountryCode { get; private set; }

        /// <summary>
        /// Player's last match time
        /// </summary>
        public DateTime LastMatchTime { get; private set; }

        /// <summary>
        /// Player’s ingame role
        /// </summary>
        public Role Role { get; private set; }

        /// <summary>
        /// Player’s team identifier
        /// </summary>
        public long TeamId { get; private set; }

        /// <summary>
        /// Player’s team name, e.g. ‘Evil Geniuses’
        /// </summary>
        public string TeamName { get; private set; }

        /// <summary>
        /// Player’s team shorthand tag, e.g. ‘EG’
        /// </summary>
        public string TeamTag { get; private set; }

        /// <summary>
        /// Whether the roster lock is active
        /// </summary>
        public bool IsLocked { get; private set; }

        /// <summary>
        /// Whether the player is professional or not
        /// </summary>
        public bool IsPro { get; private set; }

        /// <summary>
        /// When the roster lock will end
        /// </summary>
        public int LockedUntil { get; private set; }

        internal static ProPlayer Deserialize(JToken json)
        {
            var proPlayer = new ProPlayer()
            {
                AccountId = json.Value<long>("account_id", 0),
                SteamId = json.Value<string>("steamid"),
                AvatarSmall = CreateUri(json.Value<string>("avatar")),
                AvatarMedium = CreateUri(json.Value<string>("avatarmedium")),
                AvatarFull = CreateUri(json.Value<string>("avatarfull")),
                SteamProfileUrl = CreateUri(json.Value<string>("profileurl")),
                PersonaName = json.Value<string>("personaname"),
                FullHistoryTime = json.Value<DateTime>("full_history_time", default(DateTime)),
                PlayerMatchHistoryRefreshFailed = json.Value<bool>("fh_unavailable", false),
                CountryCode = json.Value<string>("loccountrycode"),
                LastMatchTime = json.Value<DateTime>("last_match_time", default(DateTime)),
                VerifiedName = json.Value<string>("name"),
                Country = json.Value<string>("country_code"),
                Role = json.Value<Role>("fantasy_role", Role.Unspecified),
                TeamId = json.Value<long>("team_id", 0),
                TeamName = json.Value<string>("team_name"),
                TeamTag = json.Value<string>("team_tag"),
                IsLocked = json.Value<bool>("is_locked", false),
                IsPro = json.Value<bool>("is_pro", true),
                LockedUntil = json.Value<int>("locked_until", 0)
            };

            return proPlayer;
        }

        private static Uri CreateUri(string givenUri)
        {
            Uri.TryCreate(givenUri, UriKind.Absolute, out Uri uri);            
            return uri;
        }
    }
}