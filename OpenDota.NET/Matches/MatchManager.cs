using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Matches
{
    public class MatchManager
    {
        public Match GetMatch(long matchId)
        {
            return GetMatchAsync(matchId).GetAwaiter().GetResult();
        }

        public async Task<Match> GetMatchAsync(long matchId)
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync(string.Format("matches/{0}", matchId)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return Match.Deserialize(result);
                }
            }
            throw new Exception("Could not successfully get match data");
        }

        /// <summary>
        /// Get the last 100 pro matches details
        /// </summary>
        /// <returns>A list of pro matches details</returns>
        public IEnumerable<ProMatch> GetProMatchesDetails()
        {
            return GetProMatchesDetailsAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get the last 100 pro matches details asynchronously
        /// </summary>
        /// <returns>A task which returns a list of pro matches details</returns>
        public async Task<IEnumerable<ProMatch>> GetProMatchesDetailsAsync()
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync("promatches"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var proMatches = new List<ProMatch>();
                    foreach (var proMatch in JArray.Parse(result))
                    {
                        proMatches.Add(ProMatch.Deserialize(proMatch));
                    }

                    return proMatches;
                }
            }
            throw new Exception("Could not successfully get pro matches data");
        }

        /// <summary>
        /// Get 100 public matches which match the criteria
        /// </summary>
        /// <param name="mmrAscending">Order by MMR ascending</param>
        /// <param name="mmrDescending">Order by MMR descending</param>
        /// <param name="matchId">Get matches with a match ID lower than this value</param>
        /// <returns>A list of public matches</returns>
        public IEnumerable<PublicMatch> GetPublicMatches(int? mmrAscending = null, int? mmrDescending = null, long? matchId = null)
        {
            return GetPublicMatchesAsync(mmrAscending, mmrDescending, matchId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get 100 public matches which match the criteria
        /// </summary>
        /// <param name="mmrAscending">Order by MMR ascending</param>
        /// <param name="mmrDescending">Order by MMR descending</param>
        /// <param name="matchId">Get matches with a match ID lower than this value</param>
        /// <returns>A task which returns the list of public matches</returns>
        public async Task<IEnumerable<PublicMatch>> GetPublicMatchesAsync(int? mmrAscending = null, int? mmrDescending = null, long? matchId = null)
        {
            var client = OpenDotaAPIWrapper.Client;

            var queryString = GetQueryString(mmrAscending, mmrDescending, matchId);
            using (var response = await client.GetAsync(string.Format("publicmatches?{0}", queryString)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var publicMatches = new List<PublicMatch>();
                    foreach (var publicMatch in JArray.Parse(result))
                    {
                        publicMatches.Add(PublicMatch.Deserialize(publicMatch));
                    }

                    return publicMatches;
                }
            }
            throw new Exception("Could not successfully get public matches data");
        }        

        [Obsolete("OpenDota endpoint is accessed over hundred times. Do not use unless you have an api key. Alternatively you can use GetProMatchesDetails and get details for required matches individually using GetMatch.", false)]
        public IEnumerable<ProMatch> GetProMatches()
        {
            return GetProMatchesAsync().GetAwaiter().GetResult();
        }

        [Obsolete("OpenDota endpoint is accessed over hundred times. Do not use unless you have an api key. Alternatively you can use GetProMatchesDetailsAsync and get details for required matches individually using GetMatchAsync.", false)]
        public async Task<IEnumerable<ProMatch>> GetProMatchesAsync()
        {
            var proMatches = await GetProMatchesDetailsAsync();

            foreach(var proMatch in proMatches)
            {
                proMatch.Details = await GetMatchAsync(proMatch.MatchId);
            }

            return proMatches;
        }

        private string GetQueryString(int? mmrAscending, int? mmrDescending, long? matchId)
        {
            var queryStringParameters = new List<KeyValuePair<string, string>>();
            if(mmrAscending != null)
            {
                queryStringParameters.Add(new KeyValuePair<string, string>("mmr_ascending", mmrAscending.ToString()));
            }
            if(mmrDescending != null)
            {
                queryStringParameters.Add(new KeyValuePair<string, string>("mmr_descending", mmrDescending.ToString()));
            }
            if(matchId != null)
            {
                queryStringParameters.Add(new KeyValuePair<string, string>("less_than_match_id", matchId.ToString()));
            }
            var keyValuePairsJoined = queryStringParameters.Select(q => string.Format("{0}={1}", q.Key, q.Value));
            return String.Join('&', keyValuePairsJoined);
        }
    }
}
