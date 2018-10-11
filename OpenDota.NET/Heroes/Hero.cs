using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Heroes
{
    public class Hero
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string LocalizedName { get; private set; }

        public PrimaryAttribute PrimaryAttribute { get; private set; }

        public AttackType AttackType { get; private set; }

        public Roles Roles { get; private set; }

        public int Legs { get; private set; }

        internal static Hero Deserialize(JToken json)
        {
            return new Hero
            {
                Id = json.Value<int>("id"),
                Name = json.Value<string>("name"),
                LocalizedName = json.Value<string>("localized_name"),
                PrimaryAttribute = GetPrimaryAttribute(json),
                AttackType = GetAttackType(json),
                Roles = HeroStats.GetRoles(json["roles"]),
                Legs = json.Value<int>("legs")
            };
        }

        private static AttackType GetAttackType(JToken json)
        {
            var type = json.Value<string>("attack_type").ToLower();
            switch (type)
            {
                case "melee": return AttackType.Melee;
                case "ranged": return AttackType.Ranged;
                default: return AttackType.Unknown;
            }
        }

        private static PrimaryAttribute GetPrimaryAttribute(JToken json)
        {
            var attr = json.Value<string>("primary_attr").ToLower();
            switch (attr)
            {
                case "agi": return PrimaryAttribute.Agility;
                case "str": return PrimaryAttribute.Strength;
                case "int": return PrimaryAttribute.Intelligence;
                default: return PrimaryAttribute.Unknown;
            }
        }
    }

    public enum PrimaryAttribute
    {
        Unknown,
        Agility,
        Strength,
        Intelligence
    }

    public enum AttackType
    {
        Unknown,
        Melee,
        Ranged
    }
}