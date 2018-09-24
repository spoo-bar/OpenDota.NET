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

        public IEnumerable<ProMatch> GetProMatches()
        {
            return GetProMatchesAsync().GetAwaiter().GetResult();
        }

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
