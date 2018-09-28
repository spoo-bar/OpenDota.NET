using System;
using System.Collections.Generic;
using System.Linq;
using OpenDota.NET.Matches;

namespace OpenDota.NET.Players
{
    public class MatchSearchQuery
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
        private string PatchId { get; set; }

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
        public TimeSpan? DaysPrevious { get; set; }

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

        /// <summary>
        /// Fields to project 
        /// </summary>
        public IEnumerable<string> Projects { get; set; }

        internal static string GetQueryString(MatchSearchQuery query)
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

                if(query.GameMode != null  && query.GameMode.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("game_mode", ((int)query.GameMode.Value).ToString()));
                }

                if (query.LobbyType != null && query.LobbyType.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("lobby_type", ((int)query.LobbyType.Value).ToString()));
                }

                if (query.RegionId != null && query.RegionId.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("region", query.RegionId.Value.ToString()));
                }

                if (query.DaysPrevious != null && query.DaysPrevious.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("date", query.DaysPrevious.Value.Days.ToString()));
                }

                if(query.LaneRoleId != null && query.LaneRoleId.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("lane_role", query.LaneRoleId.Value.ToString()));
                }

                if(query.HeroId != null && query.HeroId.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("hero_id", query.HeroId.Value.ToString()));
                }

                if(query.IsRadiant != null && query.IsRadiant.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("is_radiant", Convert.ToInt16(query.IsRadiant.Value).ToString()));
                }

                if(query.IncludedAccountIDs != null && query.IncludedAccountIDs.Count() > 0)
                {
                    var values = GetIEnumerableValuesAsString(query.IncludedAccountIDs);
                    queryStringParameters.Add(new KeyValuePair<string, string>("included_account_id", values));
                }

                if(query.ExcludedAccountIDs != null && query.ExcludedAccountIDs.Count() > 0)
                {
                    var values = GetIEnumerableValuesAsString(query.ExcludedAccountIDs);
                    queryStringParameters.Add(new KeyValuePair<string, string>("excluded_account_id", values));
                }

                if(query.IncludedHeroIDs != null && query.IncludedHeroIDs.Count() > 0)
                {
                    var values = GetIEnumerableValuesAsString(query.IncludedHeroIDs);
                    queryStringParameters.Add(new KeyValuePair<string, string>("with_hero_id", values));
                }

                if(query.AgainstHeroIDs != null && query.AgainstHeroIDs.Count() > 0)
                {
                    var values = GetIEnumerableValuesAsString(query.AgainstHeroIDs);
                    queryStringParameters.Add(new KeyValuePair<string, string>("against_hero_id", values));
                }

                if(query.Significant != null && query.Significant.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("significant", Convert.ToInt16(query.Significant.Value).ToString()));
                }

                if(query.Having != null && query.Having.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("having", query.Having.Value.ToString()));
                }

                if (query.SortByDescending != null && query.SortByDescending.HasValue)
                {
                    queryStringParameters.Add(new KeyValuePair<string, string>("sort", Convert.ToInt16(query.SortByDescending.Value).ToString()));
                }

                if(query.Projects != null && query.Projects.Count() > 0)
                {
                    var values = GetIEnumerableValuesAsString(query.Projects);
                    queryStringParameters.Add(new KeyValuePair<string, string>("project", values));
                }

                var keyValuePairsJoined = queryStringParameters.Select(q => string.Format("{0}={1}", q.Key, q.Value));
                return String.Join('&', keyValuePairsJoined);
            }
            return string.Empty; 
        }

        private static string GetIEnumerableValuesAsString<T>(IEnumerable<T> includedAccountIDs)
        {
            return String.Join(',', includedAccountIDs.Select(i => i.ToString()));
        }
    }
}