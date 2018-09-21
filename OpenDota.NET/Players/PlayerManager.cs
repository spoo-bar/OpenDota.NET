using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Players
{
    public class PlayerManager
    {
        public IEnumerable<ProPlayer> GetProPlayers()
        {
            return GetProPlayersAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<ProPlayer>> GetProPlayersAsync()
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync("proplayers"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var proPlayers = new List<ProPlayer>();
                    foreach(var proPlayer in JArray.Parse(result))
                    {
                        proPlayers.Add(ProPlayer.Deserialize(proPlayer));
                    }

                    return proPlayers;
                }
            }
            throw new Exception("Could not successfully get proplayers data");
        }
    }
}
