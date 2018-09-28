using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;
using OpenDota.NET.Matches;

namespace OpenDota.NET.Players
{
    public class Match
    {
        private int _playerSlotNumber;

        /// <summary>
        /// Match ID
        /// </summary>
        public long MatchID { get; private set; }

        /// <summary>
        /// Which team slot the player is in
        /// </summary>
        public Slot PlayerSlot
        {
            get
            {
                if (_playerSlotNumber >= 128)
                {
                    return Slot.Dire;
                }
                return Slot.Radiant;
            }
        }

        /// <summary>
        /// Boolean indicating whether Radiant won the match
        /// </summary>
        public bool RadiantWin { get; private set; }

        /// <summary>
        /// Boolean indicating whether Dire won the match
        /// </summary>
        public bool DireWin { get { return !RadiantWin; } }

        /// <summary>
        /// Duration of the game
        /// </summary>
        public TimeSpan Duration { get; private set; }

        /// <summary>
        /// Game Mode
        /// </summary>
        public GameMode GameMode { get; private set; }

        /// <summary>
        /// Lobby Type
        /// </summary>
        public LobbyType LobbyType { get; private set; }

        /// <summary>
        /// The ID value of the hero played
        /// </summary>
        public int HeroId { get; private set; }

        /// <summary>
        /// Start time of the match
        /// </summary>
        public DateTime StartTime { get; private set; }

        public string Version { get; private set; }

        /// <summary>
        /// Total kills the player had at the end of the match
        /// </summary>
        public int Kills { get; private set; }

        /// <summary>
        /// Total deaths the player had at the end of the match
        /// </summary>
        public int Deaths { get; private set; }

        /// <summary>
        /// Total assists the player had at the end of the match
        /// </summary>
        public int Assists { get; private set; }

        /// <summary>
        /// Skill bracket assigned by Valve
        /// </summary>
        public Skill Skill { get; private set; }

        /// <summary>
        /// Integer corresponding to which lane the player laned in for the match
        /// </summary>
        public int Lane { get; private set; }

        public int LaneRole { get; private set; }

        /// <summary>
        /// Boolean describing whether or not the player roamed
        /// </summary>
        public bool IsRoaming { get; private set; }

        public int Cluster { get; private set; }

        /// <summary>
        /// Whether or not the player left the game
        /// </summary>
        public LeaverStatus LeaverStatus { get; private set; }

        /// <summary>
        /// Size of the players party. If not in a party, will return 1
        /// </summary>
        public int PartySize { get; private set; }

        public double XpPerMinute { get; private set; }

        public double GoldPerMinute { get; private set; }

        public int HeroDamage { get; private set; }

        public int TowerDamage { get; private set; }

        public int HeroHealing { get; private set; }

        public int LastHits { get; private set; }

        internal static Match Deserialize(JToken json)
        {
            var match = new Match
            {
                MatchID = json.Value<long>("match_id", 0),
                _playerSlotNumber = json.Value<int>("player_slot", 0),
                RadiantWin = json.Value<bool>("radiant_win", false),
                Duration = TimeSpan.FromSeconds(json.Value<long>("duration")),
                GameMode = (GameMode)json.Value<int>("game_mode", 0),
                LobbyType = (LobbyType)json.Value<int>("lobby_type", 11),
                HeroId = json.Value<int>("hero_id", 0),
                StartTime = DateTimeOffset.FromUnixTimeSeconds(json.Value<long>("start_time")).DateTime,
                Version = json.Value<string>("version"),
                Kills = json.Value<int>("kills", 0),
                Deaths = json.Value<int>("deaths", 0),
                Assists = json.Value<int>("assists", 0),
                Skill = (Skill)json.Value<int>("skill", 3),
                XpPerMinute = json.Value<double>("xp_per_min"),
                GoldPerMinute = json.Value<double>("gold_per_min"),
                HeroDamage = json.Value<int>("hero_damage", 0),
                TowerDamage = json.Value<int>("tower_damage", 0),
                HeroHealing = json.Value<int>("hero_healing", 0),
                LastHits = json.Value<int>("last_hits", 0),
                Lane = json.Value<int>("lane", 0),
                LaneRole = json.Value<int>("lane_role", 0),
                IsRoaming = json.Value<bool>("is_roaming", false),
                Cluster = json.Value<int>("cluster", 0),
                LeaverStatus = (LeaverStatus)json.Value<int>("leaver_status"),
                PartySize = json.Value<int>("party_size", 0)
            };

            return match;
        }
    }
}