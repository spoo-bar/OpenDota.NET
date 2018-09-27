using System;
using System.Collections.Generic;
using System.Linq;
using OpenDota.NET.Matches;

namespace OpenDota.NET.Players
{
    public class PlayerWinLossQuery
    {
        /// <summary>
        /// Number of matches to limit to
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Number of matches to offset start by
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Whether the player won
        /// </summary>
        public bool? Won { get; set; }

        /// <summary>
        /// Patch ID
        /// </summary>
        public double? PatchId { get; set; }

        /// <summary>
        /// Game Mode 
        /// </summary>
        public GameMode? GameMode { get; set; }

        /// <summary>
        /// Lobby type
        /// </summary>
        public LobbyType? LobbyType { get; set; }

        /// <summary>
        /// Region ID
        /// </summary>
        public int? RegionId { get; set; }

        /// <summary>
        /// Days previous
        /// </summary>
        public int? DaysPrevious { get; set; }

        /// <summary>
        /// Lane Role ID
        /// </summary>
        public int? LaneRoleId { get; set; }

        /// <summary>
        /// Hero ID
        /// </summary>
        public long? HeroId { get; set; }

        /// <summary>
        /// Whether the player was radiant
        /// </summary>
        public bool? IsRadiant { get; set; }

        /// <summary>
        /// Account IDs in the match
        /// </summary>
        public IEnumerable<long> IncludedAccountIDs { get; set; }

        /// <summary>
        /// Account IDs not in the match
        /// </summary>
        public IEnumerable<long> ExcludedAccountIDs { get; set; }

        /// <summary>
        /// Hero IDs on the player’s team
        /// </summary>
        public IEnumerable<int> IncludedHeroIDs { get; set; }

        /// <summary>
        /// Hero IDs against the player’s team 
        /// </summary>
        public IEnumerable<int> AgainstHeroIDs { get; set; }

        /// <summary>
        /// Whether the match was significant for aggregation purposes
        /// </summary>
        public bool? Significant { get; set; }

        /// <summary>
        /// The minimum number of games played, for filtering hero stats
        /// </summary>
        public int? Having { get; set; }

        /// <summary>
        /// Return matches sorted by in descending order
        /// </summary>
        public bool? SortByDescending { get; set; }

        internal static string GetQueryString(PlayerWinLossQuery query)
        {
            if(query != null)
            {
                var queryStringParameters = new List<KeyValuePair<string, string>>();
                if(query.Limit != null && query.Limit.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("limit", query.Limit.Value.ToString()));
                }
                if(query.Offset != null && query.Offset.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("offset", query.Offset.Value.ToString()));
                }
                if(query.Won != null && query.Won.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("win", Convert.ToInt16(query.Won.Value).ToString()));
                }

                var keyValuePairsJoined = queryStringParameters.Select(q => string.Format("{0}={1}", q.Key, q.Value));
                return String.Join('&', keyValuePairsJoined);
            }
            return string.Empty; 
        }
    }
}