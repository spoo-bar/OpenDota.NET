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
        internal static Counts Deserialize(string response)
        {
            var json = JObject.Parse(response);
            return new Counts
            {
                LeaverStatusCounts = GetLeaverStatusCounts(json["leaver_status"]),
            };
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

        public class LeaverStatusCount
        {
            public LeaverStatus Key { get; internal set; }
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
}