using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Matches
{
    public class PickBan
    {
        public bool IsPick { get; private set; }
        public bool IsBan { get { return !IsPick; } }
        public int HeroId { get; private set; }
        public int Team { get; private set; }
        public int Order { get; private set; }
        public int MatchId { get; private set; }

        public static PickBan Deserialize(JToken json)
        {
            return new PickBan
            {
                IsPick = (bool)json["is_pick"],
                HeroId = (int)json["hero_id"],
                Team = (int)json["team"], // TODO : Figure out which team is which value
                Order = (int)json["order"],
                MatchId = (int)json["match_id"]
            };
        }
    }
}