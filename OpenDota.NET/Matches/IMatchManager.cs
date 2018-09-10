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

        public int Players { get; set; }

        public int Patch { get; set; }

        public int Region { get; set; }

        public int AllWordCounts { get; set; }

        public int MyWordCounts { get; set; }

        public int Throw { get; set; }

        public int Loss { get; set; }

        public int ReplayUrl { get; set; }
    }

    public class Team
    {
        public int Score { get; set; }

        public dynamic GoldAdvantage { get; set; }

        public dynamic ExperienceAdvantage { get; set; }

        public int FinalScore { get; set; }

        public bool WonGame { get; set; }

        /// <summary>
        /// Bitmask. An integer that represents a binary of which Radiant towers are still standing.
        /// </summary>
        public int TowerStatus { get; set; }
    }

    public class DraftTiming
    {
        internal int _playerSlotNumber { private get; set; }
        public int Order { get; set; }
        public bool Picked { get; set; }
        public bool Banned { get { return !Picked; } }
        public int ActiveTeam { get; set; }
        public int HeroID { get; set; }
        public Slot PlayerSlot
        {
            get
            {
                if (_playerSlotNumber >= 128)
                {
                    return Matches.Slot.Dire;
                }
                return Matches.Slot.Radiant;
            }
        }
        public int ExtraTime { get; set; }
        public int TotalTimeTaken { get; set; }

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

    public enum GameMode
    {
        Unknown = 0,
        AllPick = 1,
        CaptainsMode = 2,
        RandomDraft = 3,
        SingleDraft = 4,
        AllRandom = 5,
        Intro = 6,
        DireTide = 7,
        ReverseCaptainsMode = 8,
        Greeviling = 9,
        Tutorial = 10,
        MidOnly = 11,
        LeastPlayed = 12,
        LimitedHeroes = 13,
        CompendiumMatchmaking = 14,
        Custom = 15,
        CaptainsDraft = 16,
        BalancedDraft = 17,
        AbilityDraft = 18,
        Event = 19,
        AllRandomDeathMatch = 20,
        Mid1v1 = 21,
        AllDraft = 22,
        Turbo = 23,
        Mutation = 24
    }

    public enum LobbyType
    {
        Normal = 0,
        Practice = 1,
        Tournament = 2,
        Tutorial = 3,
        CoopBots = 4,
        RankedTeam = 5,
        RandkedSolo = 6,
        Ranked = 7,
        Mid1v1 = 8,
        BattleCup = 9
    }

    public enum Skill
    {
        Normal,
        High,
        VeryHigh
    }
}
