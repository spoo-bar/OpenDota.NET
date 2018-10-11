using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenDota.NET.Heroes
{
    public class HeroManager
    {
        public IEnumerable<HeroStats> GetHeroesStats()
        {
            return GetHeroesStatsAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<HeroStats>> GetHeroesStatsAsync()
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync("heroStats"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var heroes = new List<HeroStats>();
                    foreach (var hero in JArray.Parse(result))
                    {
                        heroes.Add(HeroStats.Deserialize(hero));
                    }

                    return heroes.OrderBy(h => h.LocalizedName);
                }
            }
            throw new Exception("Could not successfully get heroes data");
        }

        public IEnumerable<Hero> GetHeroes()
        {
            return GetHeroesAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Hero>> GetHeroesAsync()
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync("heroes"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var heroes = new List<Hero>();
                    foreach (var hero in JArray.Parse(result))
                    {
                        heroes.Add(Hero.Deserialize(hero));
                    }

                    return heroes;
                }
            }
            throw new Exception("Could not successfully get heroes data");
        }
    }
}
