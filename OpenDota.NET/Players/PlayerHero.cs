using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Players
{
    public class PlayerHero
    {
        public int Slot { get; private set; }

        public long AccountId { get; private set; }

        public int HeroID { get; private set; }

        internal static PlayerHero Deserialize(JToken json)
        {
            return new PlayerHero
            {
                AccountId = json.Value<long>("account_id", 0),
                HeroID = json.Value<int>("hero_id"),
                Slot = json.Value<int>("player_slot")
            };
        }
    }
}