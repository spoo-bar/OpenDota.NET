using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;
using OpenDota.NET.Matches;

namespace OpenDota.NET.Players
{
    public class Counts
    {
        public IEnumerable<LeaverStatusCount> LeaverStatusCounts { get; private set; }

        public IEnumerable<GameModeCount> GameModeCounts { get; private set; }

        public IEnumerable<LobbyTypeCount> LobbyTypeCounts { get; private set; }

        public IEnumerable<LaneRoleCount> LaneRoleCounts { get; private set; }

        public IEnumerable<RegionCount> RegionCounts { get; private set; }

        public IEnumerable<PatchCount> PatchCounts { get; private set; }

        public IEnumerable<SlotCount> SlotCounts { get; private set; }

        internal static Counts Deserialize(string response)
        {
            var json = JObject.Parse(response);
            return new Counts
            {
                LeaverStatusCounts = GetLeaverStatusCounts(json["leaver_status"]),
                GameModeCounts = GetGameModeCounts(json["game_mode"]),
                LobbyTypeCounts = GetLobbyTypeCounts(json["lobby_type"]),
                LaneRoleCounts = GetLaneRoleCounts(json["lane_role"]),
                RegionCounts = GetRegionCounts(json["region"]),
                PatchCounts = GetPatchCounts(json["patch"]),
                SlotCounts = GetSlotCounts(json["is_radiant"]),
            };
        }

        private static IEnumerable<SlotCount> GetSlotCounts(JToken json)
        {
            var counts = new List<SlotCount>();

            counts.Add(new SlotCount { Key = Slot.Dire, Values = Values.Deserialize(json["0"]) });
            counts.Add(new SlotCount { Key = Slot.Radiant, Values = Values.Deserialize(json["1"]) });

            return counts;
        }

        private static IEnumerable<PatchCount> GetPatchCounts(JToken json)
        {
            var counts = new List<PatchCount>();

            foreach (var obj in json)
            {
                counts.Add(new PatchCount { Key = Convert.ToInt32(((JProperty)obj).Name), Values = Values.Deserialize(((JProperty)obj).Value) });
            }

            return counts;
        }

        private static IEnumerable<RegionCount> GetRegionCounts(JToken json)
        {
            var counts = new List<RegionCount>();

            foreach(var obj in json)
            {
                counts.Add(new RegionCount { Key = Convert.ToInt32(((JProperty)obj).Name), Values = Values.Deserialize(((JProperty)obj).Value) });
            }

            return counts;
        }

        private static IEnumerable<LaneRoleCount> GetLaneRoleCounts(JToken json)
        {
            var counts = new List<LaneRoleCount>();

            for (var i = 0; i < 5; i++)
            {
                if (json[i.ToString()] != null && json[i.ToString()].Type != JTokenType.Null)
                {
                    var values = Values.Deserialize(json[i.ToString()]);
                    counts.Add(new LaneRoleCount { Key = (i+1), Values = values });
                }
            }

            return counts;
        }

        private static IEnumerable<LobbyTypeCount> GetLobbyTypeCounts(JToken json)
        {
            var counts = new List<LobbyTypeCount>();

            for (var i = 0; i < 10; i++)
            {
                if (json[i.ToString()] != null && json[i.ToString()].Type != JTokenType.Null)
                {
                    var values = Values.Deserialize(json[i.ToString()]);
                    counts.Add(new LobbyTypeCount { Key = (LobbyType)i, Values = values });
                }
            }

            return counts;
        }

        private static IEnumerable<GameModeCount> GetGameModeCounts(JToken json)
        {
            var counts = new List<GameModeCount>();

            for (var i = 0; i < 25; i++)
            {
                if (json[i.ToString()] != null && json[i.ToString()].Type != JTokenType.Null)
                {
                    var values = Values.Deserialize(json[i.ToString()]);
                    counts.Add(new GameModeCount { Key = (GameMode)i, Values = values });
                }                
            }            

            return counts;
        }

        private static IEnumerable<LeaverStatusCount> GetLeaverStatusCounts(JToken json)
        {
            var counts = new List<LeaverStatusCount>();

            counts.Add(new LeaverStatusCount { Key = LeaverStatus.DidNotLeave, Values = Values.Deserialize(json["0"]) });
            counts.Add(new LeaverStatusCount { Key = LeaverStatus.LeftSafely, Values = Values.Deserialize(json["1"]) });

            var games = 0;
            var wins = 0;
            for (var i = 2; i < 5; i++)
            {
                if(json[i.ToString()] != null && json[i.ToString()].Type != JTokenType.Null)
                {
                    var values = Values.Deserialize(json[i.ToString()]);
                    games += values.Games;
                    wins += values.Wins;
                }
            }
            counts.Add(new LeaverStatusCount { Key = LeaverStatus.Abandoned, Values = new Values { Games = games, Wins = wins } });

            return counts;
        }       

    }

    public class LeaverStatusCount
    {
        public LeaverStatus Key { get; internal set; }
        public Values Values { get; internal set; }
    }

    public class GameModeCount
    {
        public GameMode Key { get; internal set; }
        public Values Values { get; internal set; }
    }

    public class LobbyTypeCount
    {
        public LobbyType Key { get; internal set; }
        public Values Values { get; internal set; }
    }

    public class LaneRoleCount
    {
        public int Key { get; internal set; }
        public Values Values { get; internal set; }
    }

    public class RegionCount
    {
        public int Key { get; internal set; }
        public Values Values { get; internal set; }
    }

    public class PatchCount
    {
        public int Key { get; internal set; }
        public Values Values { get; internal set; }
    }

    public class SlotCount
    {
        public Slot Key { get; internal set; }
        public Values Values { get; internal set; }
    }

    public class Values
    {
        public int Games { get; internal set; }
        public int Wins { get; internal set; }

        internal static Values Deserialize(JToken json)
        {
            return new Values
            {
                Games = json.Value<int>("games", 0),
                Wins = json.Value<int>("win", 0)
            };
        }
    }
}