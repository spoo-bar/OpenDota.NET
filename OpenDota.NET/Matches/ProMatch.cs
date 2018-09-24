using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Matches
{
    public class ProMatch
    {
        public long MatchId { get; private set; }

        public TimeSpan Duration { get; private set; }

        public DateTime StartTime { get; private set; }

        public long RadiantTeamId { get; private set; }

        public string RadiantTeamName { get; private set; }

        public long DireTeamId { get; private set; }

        public string DireTeamName { get; private set; }

        public long LeagueId { get; private set; }

        public string LeagueName { get; private set; }

        public long SeriesId { get; private set; }

        public int SeriesType { get; private set; }

        public int RadiantScore { get; private set; }

        public int DireScore { get; private set; }

        public bool RadiantWin { get; private set; }

        public bool DireWin { get { return !RadiantWin; }  }

        public Match Details { get; internal set; }


        internal static ProMatch Deserialize(JToken json)
        {
            var proMatch =  new ProMatch
            {
                MatchId = json.Value<long>("match_id"),
                Duration = TimeSpan.FromSeconds(json.Value<int>("duration")),
                StartTime = DateTimeOffset.FromUnixTimeSeconds(json.Value<int>("start_time")).DateTime,
                RadiantTeamId = json.Value<long>("radiant_team_id", 0),
                RadiantTeamName = json.Value<string>("radiant_name"),
                DireTeamId = json.Value<long>("dire_team_id", 0),
                DireTeamName = json.Value<string>("dire_name"),
                LeagueId = json.Value<long>("leagueid"),
                LeagueName = json.Value<string>("league_name"),
                SeriesId = json.Value<long>("series_id"),
                SeriesType = json.Value<int>("series_type"),
                RadiantScore = json.Value<int>("radiant_score"),
                DireScore = json.Value<int>("dire_score"),
                RadiantWin = json.Value<bool>("radiant_win"),
            };

            return proMatch;
        }
    }
}