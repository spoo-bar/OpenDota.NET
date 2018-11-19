using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Search
{
    public class SearchManager
    {
        public IEnumerable<PlayerResult> SearchPlayers(string personaName)
        {
            return SearchPlayersAsync(personaName).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<PlayerResult>> SearchPlayersAsync(string personaName)
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync("search?q=" + personaName))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var searchResults = new List<PlayerResult>();
                    foreach (var json in JArray.Parse(result))
                    {
                        searchResults.Add(PlayerResult.Deserialize(json));
                    }

                    return searchResults.OrderBy(h => h.Similarity);
                }
            }
            throw new Exception("Could not successfully search players");
        }
    }
}
