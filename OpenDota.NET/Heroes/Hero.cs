using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Heroes
{
    public class Hero
    {
        public long Id { get; private set; }

        public long HeroId { get; private set; }

        public string Name { get; private set; }

        public string LocalizedName { get; private set; }

        public Uri Image { get; private set; }

        public Uri Icon { get; private set; }

        public string PrimaryAttribute { get; private set; }

        public Roles Roles { get; set; }

        public BaseStats BaseStats { get; set; }

        public int ProWins { get; private set; }

        public int ProPicks { get; private set; }

        public int ProBans { get; private set; }

        public MedalStats Herald { get; private set; }

        public MedalStats Guardian { get; private set; }

        public MedalStats Crusader { get; private set; }

        public MedalStats Archon { get; private set; }

        public MedalStats Legend { get; private set; }

        public MedalStats Ancient { get; private set; }

        public MedalStats Divine { get; private set; }

        public MedalStats Immortal { get; private set; }

        internal static Hero Deserialize(JToken json)
        {
            var hero = new Hero
            {
                Id = json.Value<long>("id"),
                HeroId = json.Value<long>("hero_id"),
                Name = json.Value<string>("name"),
                LocalizedName = json.Value<string>("localized_name"),
                Image = GetMediaUri(json.Value<string>("img")),
                Icon = GetMediaUri(json.Value<string>("icon")),
                PrimaryAttribute = json.Value<string>("primary_attr"),
                Roles = GetRoles(json["roles"]),
                BaseStats = BaseStats.Deserialize(json),
                ProWins = json.Value<int>("pro_win"),
                ProPicks = json.Value<int>("pro_pick"),
                ProBans = json.Value<int>("pro_ban"),
                Herald = new MedalStats
                {
                    HeroId = json.Value<long>("hero_id"),
                    Picks = json.Value<int>("1_pick"),
                    Wins = json.Value<int>("1_win")
                },
                Guardian = new MedalStats
                {
                    HeroId = json.Value<long>("hero_id"),
                    Picks = json.Value<int>("2_pick"),
                    Wins = json.Value<int>("2_win")
                },
                Crusader = new MedalStats
                {
                    HeroId = json.Value<long>("hero_id"),
                    Picks = json.Value<int>("3_pick"),
                    Wins = json.Value<int>("3_win")
                },
                Archon = new MedalStats
                {
                    HeroId = json.Value<long>("hero_id"),
                    Picks = json.Value<int>("4_pick"),
                    Wins = json.Value<int>("4_win")
                },
                Legend = new MedalStats
                {
                    HeroId = json.Value<long>("hero_id"),
                    Picks = json.Value<int>("5_pick"),
                    Wins = json.Value<int>("5_win")
                },
                Ancient = new MedalStats
                {
                    HeroId = json.Value<long>("hero_id"),
                    Picks = json.Value<int>("6_pick"),
                    Wins = json.Value<int>("6_win")
                },
                Divine = new MedalStats
                {
                    HeroId = json.Value<long>("hero_id"),
                    Picks = json.Value<int>("7_pick"),
                    Wins = json.Value<int>("7_win")
                },
                Immortal = new MedalStats
                {
                    HeroId = json.Value<long>("hero_id"),
                    Picks = json.Value<int>("8_pick"),
                    Wins = json.Value<int>("8_win")
                }
            };
            return hero;
        }

        private static Roles GetRoles(JToken jToken)
        {
            var roles = new Roles();

            foreach(var jObj in jToken)
            {
                switch (jObj.Value<string>().ToLower())
                {
                    case "carry":
                        roles.Carry = true;
                        break;
                    case "nuker":
                        roles.Nuker = true;
                        break;
                    case "escape":
                        roles.Escape = true;
                        break;
                    case "support":
                        roles.Support = true;
                        break;
                    case "disabler":
                        roles.Disabler = true;
                        break;
                    case "jungler":
                        roles.Jungler = true;
                        break;
                    case "durable":
                        roles.Durable = true;
                        break;
                    case "pusher":
                        roles.Pusher = true;
                        break;
                    case "initiator":
                        roles.Initiator = true;
                        break;
                }
            }

            return roles;
        }

        private static Uri GetMediaUri(string value)
        {
            var apiUri = new Uri("https://api.opendota.com");
            return new Uri(apiUri, value);
        }
    }
}