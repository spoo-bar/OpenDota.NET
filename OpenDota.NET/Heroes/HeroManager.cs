using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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

                    return heroes;
                }
            }
            throw new Exception("Could not successfully get heroes data");
        }
    }
}
