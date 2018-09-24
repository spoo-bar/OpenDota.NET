using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Matches
{
    public class PublicMatch
    {
        public long MatchId { get; private set; }

        public long MatchSequenceNumber { get; private set; }

        public bool RadianWin { get; private set; }

        public bool DireWin { get { return !RadianWin; } }

        public DateTime StartTime { get; private set; }

        public TimeSpan Duration { get; private set; }

        public string RadiantTeam { get; private set; }

        public string DireTeam { get; private set; }

        public int AverageMMR { get; private set; }

        public int NumMMR { get; private set; }

        public LobbyType LobbyType { get; private set; }

        public GameMode GameMode { get; private set; }

        public int AverageRankTier { get; private set; }

        public int NumRankTier { get; private set; }

        public int Cluster { get; private set; }

        internal static PublicMatch Deserialize(JToken json)
        {
            return new PublicMatch
            {
                MatchId = json.Value<long>("match_id"),
                MatchSequenceNumber = json.Value<long>("match_seq_num"),
                RadianWin = json.Value<bool>("radiant_win"),
                StartTime = DateTimeOffset.FromUnixTimeSeconds(json.Value<int>("start_win")).DateTime,
                Duration = TimeSpan.FromSeconds(json.Value<int>("duration")),
                AverageMMR = json.Value<int>("avg_mmr", 0),
                NumMMR = json.Value<int>("num_mmr", 0),
                LobbyType = (LobbyType)json.Value<int>("lobby_type"),
                GameMode = (GameMode)json.Value<int>("game_mode"),
                AverageRankTier = json.Value<int>("avg_rank_tier"),
                NumRankTier = json.Value<int>("num_rank_tier"),
                Cluster = json.Value<int>("cluster"),
                RadiantTeam = json.Value<string>("radiant_team"),
                DireTeam = json.Value<string>("dire_team")
            };
        }
    }
}