using System;
using System.Text;

namespace OpenDota.NET.Matches
{
    public class MatchManager
    {
        public Match GetMatch(int matchId)
        {
            var client = OpenDotaAPIWrapper.Client;
            var response = client.GetAsync(string.Format("matches/{0}", matchId)).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return Match.Deserialize(result);
            }
            throw new Exception("Could not successfully get match data");
        }
    }
}
