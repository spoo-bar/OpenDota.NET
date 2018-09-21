using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Matches
{
    // TODO : Add PCT values
    public class BenchMarks
    {
        public double GoldPerMinute { get; set; }

        public double XpPerMinute { get; set; }

        public double KillsPerMinute { get; set; }

        public double LastHitsPerMinute { get; set; }

        public double HeroDamagePerMinute { get; set; }

        public double HeroHealingPerMinute { get; set; }

        public double TowerDamage { get; set; }

        public double StunsPerMinute { get; set; }

        internal static BenchMarks Deserialize(JToken json)
        {
            var benchMarks = new BenchMarks();

            benchMarks.GoldPerMinute = (double)json["gold_per_min"]["raw"];
            benchMarks.XpPerMinute = (double)json["xp_per_min"]["raw"];
            benchMarks.KillsPerMinute = (double)json["kills_per_min"]["raw"];
            benchMarks.LastHitsPerMinute = (double)json["last_hits_per_min"]["raw"];
            benchMarks.HeroDamagePerMinute = (double)json["hero_damage_per_min"]["raw"];
            benchMarks.HeroHealingPerMinute = (double)json["hero_healing_per_min"]["raw"];
            benchMarks.TowerDamage = (double)json["hero_damage_per_min"]["raw"];
            benchMarks.StunsPerMinute = (double)json["stuns_per_min"]["raw"];


            return benchMarks;
        }

    }
}