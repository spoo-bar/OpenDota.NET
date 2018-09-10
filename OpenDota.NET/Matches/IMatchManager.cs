using System;
using System.Collections.Generic;
using System.Text;

namespace OpenDota.NET.Matches
{
    public class MatchManager
    {

        public Match GetMatch(int matchId)
        {
            return null;
        }
    }

    public class Match
    {
        public int Id { get; internal set; }

        public BarrackStatus BarrackStatus { get; internal set; }

        public IEnumerable<Chat> Chats { get; internal set; }

        public int Cluster { get; set; }

        public int Cosmetics { get; set; }

        public int DireScore { get; set; }

        public int DraftTimings { get; set; }

        public int Duration { get; set; }

        public int Engine { get; set; }

        public int FirstBloodTime { get; set; }

        public int GameMode { get; set; }

        public int HumanPlayers { get; set; }

        public int LeagueId { get; set; }

        public int LobbyType { get; set; }

        public int MatchSequenceNumber { get; set; }

        public int NegativeVotes { get; set; }

        public int Objectives { get; set; }

        public int PicksBans { get; set; }

        public int PositiveVotes { get; set; }

        public int RadiantGoldAdvantage { get; set; }

        public int RadiantScore { get; set; }

        public int RadiantWin { get; set; }

        public int RadiantXpAdvantage { get; set; }

        public int StartTime { get; set; }

        public int TeamFights { get; set; }

        public int TowerStatusDire { get; set; }

        public int TowerStatusRadiant { get; set; }

        public int Version { get; set; }

        public int ReplaySalt { get; set; }

        public int SeriesId { get; set; }

        public int SeriesType { get; set; }

        public int RadiantTeam { get; set; }

        public int DireTeam { get; set; }

        public int League { get; set; }

        public int Skill { get; set; }

        public int Players { get; set; }

        public int Patch { get; set; }

        public int Region { get; set; }

        public int AllWordCounts { get; set; }

        public int MyWordCounts { get; set; }

        public int Throw { get; set; }

        public int Loss { get; set; }

        public int ReplayUrl { get; set; }
    }

    public class BarrackStatus
    {
        public int Dire { get; set; }

        public int Radiant { get; set; }
    }

    public class Chat
    {
        internal int _playerSlotNumber { private get; set; }
        /// <summary>
        /// Time in seconds at which message was sent
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// Name of player who sent the message
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Message sent by the player
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Slot
        /// </summary>
        public int Slot { get; set; }
        /// <summary>
        /// Which slot the player is in
        /// </summary>
        public Slot PlayerSlot
        {
            get
            {
                if(_playerSlotNumber >= 128)
                {
                    return Matches.Slot.Dire;
                }
                return Matches.Slot.Radiant;
            }
        }
    }

    public enum Slot
    {
        Dire,
        Radiant
    }
}
