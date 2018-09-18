using System;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota.NET.Matches
{
    public class MatchManager
    {
        public Match GetMatch(int matchId)
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = client.GetAsync(string.Format("matches/{0}", matchId)).GetAwaiter().GetResult())
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return Match.Deserialize(result);
                }
            }            
            throw new Exception("Could not successfully get match data");
        }

        public async Task<Match> GetMatchAsync(int matchId)
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
    }
}
