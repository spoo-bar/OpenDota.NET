using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Heroes
{
    public class BaseStats
    {
        public int Health { get; private set; }

        public double HealthRegen { get; private set; }

        public int Mana { get; private set; }

        public double ManaRegen { get; private set; }

        public int Armor { get; private set; }

        public int MaginResistance { get; private set; }

        public int AttackMin { get; private set; }

        public int AttackMax { get; private set; }

        public int Strength { get; private set; }

        public int Agility { get; private set; }

        public int Intelligence { get; private set; }

        public double StrengthGain { get; private set; }

        public double AgilityGain { get; private set; }

        public double IntelligenceGain { get; private set; }

        public int AttackRange { get; private set; }

        public int ProjectileSpeed { get; private set; }

        public double AttackRate { get; private set; }

        public int MoveSpeed { get; private set; }

        public double TurnRate { get; private set; }

        public bool CMEnabled { get; private set; }

        public int Legs { get; private set; }

        internal static BaseStats Deserialize(JToken json)
        {
            return new BaseStats
            {
                Health = json.Value<int>("base_health"),
                HealthRegen = json.Value<double>("base_health_regen"),
                Mana = json.Value<int>("base_mana"),
                ManaRegen = json.Value<double>("base_mana_regen"),
                Armor = json.Value<int>("base_armor"),
                MaginResistance = json.Value<int>("base_mr"),
                AttackMin = json.Value<int>("base_attack_min"),
                AttackMax = json.Value<int>("base_attack_max"),
                Strength = json.Value<int>("base_str"),
                Agility = json.Value<int>("base_agi"),
                Intelligence = json.Value<int>("base_int"),
                StrengthGain = json.Value<double>("str_gain"),
                AgilityGain = json.Value<double>("agi_gain"),
                IntelligenceGain = json.Value<double>("int_gain"),
                AttackRange = json.Value<int>("attack_range"),
                ProjectileSpeed = json.Value<int>("projectile_speed"),
                AttackRate = json.Value<int>("attack_rate"),
                MoveSpeed = json.Value<int>("move_speed"),
                TurnRate = json.Value<double>("turn_rate"),
                CMEnabled = json.Value<bool>("cm_enabled"),
                Legs = json.Value<int>("legs"),
            };
        }
    }
}