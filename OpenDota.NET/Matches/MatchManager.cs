using System;
using System.Collections.Generic;
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

        public IEnumerable<ProMatch> GetProMatchesSummary()
        {
            return GetProMatchesSummaryAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<ProMatch>> GetProMatchesSummaryAsync()
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

        [Obsolete("OpenDota endpoint is accessed over hundred times. Do not use unless you have an api key. Alternatively you can use GetProMatchesSummary and get details for required matches individually using GetMatch.", false)]
        public IEnumerable<ProMatch> GetProMatches()
        {
            return GetProMatchesAsync().GetAwaiter().GetResult();
        }

        [Obsolete("OpenDota endpoint is accessed over hundred times. Do not use unless you have an api key. Alternatively you can use GetProMatchesSummaryAsync and get details for required matches individually using GetMatchAsync.", false)]
        public async Task<IEnumerable<ProMatch>> GetProMatchesAsync()
        {
            var proMatches = await GetProMatchesSummaryAsync();

            foreach(var proMatch in proMatches)
            {
                proMatch.Details = await GetMatchAsync(proMatch.MatchId);
            }

            return proMatches;
        }
    }
}
