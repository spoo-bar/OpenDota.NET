using System;
using System.Collections.Generic;

namespace OpenDota.NET.Matches
{
    public class Match
    {
        public int Id { get; internal set; }

        public IEnumerable<Chat> Chats { get; internal set; }

        public int Cluster { get; set; }

        public dynamic Cosmetics { get; set; }

        public Team Dire { get; set; }

        public Team Radiant { get; set; }

        public IEnumerable<DraftTiming> DraftTimings { get; set; }

        /// <summary>
        /// In Seconds
        /// </summary>
        public TimeSpan MatchDuration { get; set; }

        public int Engine { get; set; }

        /// <summary>
        /// Time in seconds at which first blood occurred
        /// </summary>
        public int FirstBloodTime { get; set; }

        public GameMode GameMode { get; set; }

        /// <summary>
        /// Number of Human Players in game
        /// </summary>
        public int HumanPlayers { get; set; }

        public int LeagueId { get; set; }

        public LobbyType LobbyType { get; set; }

        public int MatchSequenceNumber { get; set; }

        /// <summary>
        /// Number of negative votes the replay received in the in-game client
        /// </summary>
        public int NegativeVotes { get; set; }

        public dynamic Objectives { get; set; }

        public dynamic PicksBans { get; set; }

        /// <summary>
        /// Number of positive votes the replay received in the in-game client
        /// </summary>
        public int PositiveVotes { get; set; }

        public DateTime StartTime { get; set; }

        public dynamic TeamFights { get; set; }
                
        public int ReplaySalt { get; set; }

        public int SeriesId { get; set; }

        public int SeriesType { get; set; }

        public dynamic RadiantTeam { get; set; }

        public dynamic DireTeam { get; set; }

        public dynamic League { get; set; }

        /// <summary>
        /// Skill bracket assigned by Valve
        /// </summary>
        public Skill Skill { get; set; }

        public Player Players { get; set; }

        /// <summary>
        /// Information on the patch version the game is played on
        /// </summary>
        public int Patch { get; set; }

        /// <summary>
        /// Integer corresponding to the region the game was played on
        /// </summary>
        public int Region { get; set; }

        public dynamic AllWordCounts { get; set; }

        public dynamic   MyWordCounts { get; set; }

        public int Throw { get; set; }

        public int Loss { get; set; }

        public string ReplayUrl { get; set; }
    }
}
