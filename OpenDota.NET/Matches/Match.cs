using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

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
        public TimeSpan FirstBloodTime { get; set; }

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

        public IEnumerable<PickBan> PicksBans { get; set; }

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

        public IEnumerable<Player> Players { get; set; }

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

        public static Match Deserialize(string json)
        {
            var match = new Match();
            var responseJson = JObject.Parse(json);
            match.Id = (int)responseJson["match_id"];
            match.Dire = GetDireDetails(responseJson);
            match.Radiant = GetRadiantDetails(responseJson);
            match.Chats = GetMatchChat(responseJson);
            match.Cluster = (int)responseJson["cluster"];
            match.Cosmetics = responseJson["cosmetics"]; // TODO : Deserialize and replace dynamic type with a class
            match.DraftTimings = GetDraftTimings(responseJson);
            match.MatchDuration = TimeSpan.FromSeconds((int)responseJson["duration"]);
            match.Engine = (int)responseJson["engine"]; // TODO : Replace with enum?
            match.FirstBloodTime = TimeSpan.FromSeconds((int)responseJson["first_blood_time"]);
            match.GameMode = (GameMode)(int)responseJson["game_mode"];
            match.HumanPlayers = (int)responseJson["human_players"];
            match.LeagueId = (int)responseJson["leagueid"];
            match.LobbyType = (LobbyType)(int)responseJson["lobby_type"];
            match.MatchSequenceNumber = (int)responseJson["match_seq_num"];
            match.NegativeVotes = (int)responseJson["negative_votes"];
            match.PositiveVotes = (int)responseJson["positive_votes"];
            match.Objectives = responseJson["objectives"]; // TODO : Deserialize and replace dynamic type with a class (if possible ?)
            match.PicksBans = GetPicksAndBans(responseJson);

            return match;
        }

        private static IEnumerable<PickBan> GetPicksAndBans(JObject responseJson)
        {
            var picksAndBans = new List<PickBan>();

            var pickBanArray = (JArray)responseJson["picks_bans"];
            foreach(var pickBanObject in pickBanArray)
            {
                picksAndBans.Add(new PickBan {
                    IsPick = (bool)pickBanObject["is_pick"],
                    HeroId = (int)pickBanObject["hero_id"],
                    Team = (int)pickBanObject["team"], // TODO : Figure out which team is which value
                    Order = (int)pickBanObject["order"],
                    MatchId = (int)pickBanObject["match_id"]
                });
            }

            return picksAndBans.OrderBy(pb => pb.Order);
        }

        private static IEnumerable<DraftTiming> GetDraftTimings(JObject responseJson)
        {
            var draftTimings = new List<DraftTiming>();

            var draftTimingArray = (JArray)responseJson["draft_timings"];
            foreach(var draftTimingObject in draftTimingArray)
            {
                draftTimings.Add(new DraftTiming()); // TODO : Deserialize
            }

            return draftTimings;
        }

        private static IEnumerable<Chat> GetMatchChat(JObject responseJson)
        {
            var chats = new List<Chat>();

            var chatArray = (JArray)responseJson["chat"];
            foreach(var chat in chatArray)
            {
                chats.Add(new Chat
                {
                    Message = (string)chat["key"],
                    Time = TimeSpan.FromSeconds((int)chat["time"]),
                    Player = (string)chat["unit"],
                });
            }

            return chats;
        }

        private static Team GetDireDetails(JObject responseJson)
        {
            var team = new Team();
            team.BarrackStatus = (int)responseJson["barracks_status_dire"];
            team.Score = (int)responseJson["dire_score"];
            team.Id = (int)responseJson["dire_team_id"];
            return team;
        }

        private static Team GetRadiantDetails(JObject responseJson)
        {
            var team = new Team();
            team.BarrackStatus = (int)responseJson["barracks_status_radiant"];
            team.GoldAdvantage = responseJson["radiant_gold_adv"]; // TODO : Deserialize and replace dynamic type with a class
            team.Score = (int)responseJson["radiant_score"];
            team.Id = (int)responseJson["radiant_team_id"];
            team.WonGame = (bool)responseJson["radiant_win"];
            team.ExperienceAdvantage = responseJson["radiant_xp_adv"]; // TODO : Deserialize and replace dynamic type with a class
            return team;
        }
    }
}
