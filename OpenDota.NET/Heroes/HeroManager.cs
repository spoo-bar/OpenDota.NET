using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDota.NET.Heroes
{
    public class HeroManager
    {
        public IEnumerable<Hero> GetHeroesStats()
        {
            return GetHeroesStatsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Hero>> GetHeroesStatsAsync()
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync("heroStats"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var heroes = new List<Hero>();
                    foreach (var hero in JArray.Parse(result))
                    {
                        heroes.Add(Hero.Deserialize(hero));
                    }

                    return heroes.OrderBy(h => h.LocalizedName);
                }
            }
            throw new Exception("Could not successfully get heroes data");
        }

        public IEnumerable<Player> GetRankedPlayers(int heroId)
        {
            return GetRankedPlayersAsync(heroId).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Player>> GetRankedPlayersAsync(int heroId)
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync("rankings?hero_id=" + heroId))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var resultObj = JObject.Parse(result);
                    var players = new List<Player>();
                    foreach (var player in resultObj["rankings"])
                    {
                        players.Add(Player.Deserialize(player));
                    }

                    return players.OrderByDescending(h => h.Score);
                }
            }
            throw new Exception("Could not successfully get ranking data");
        }
    }
}
