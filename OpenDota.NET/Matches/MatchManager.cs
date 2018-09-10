using System.Text;

namespace OpenDota.NET.Matches
{
    public class MatchManager
    {
        public Match GetMatch(int matchId)
        {
            var client = OpenDotaAPIWrapper.Client;
            var response = client.GetAsync("matches/271145478").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
            }
            return new Match();
        }
    }
}
