using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Matches
{
    public class Player
    {
        private int _playerSlotNumber { get; set; }
        public Slot Team
        {
            get
            {
                if (_playerSlotNumber >= 128)
                {
                    return Slot.Dire;
                }
                return Slot.Radiant;
            }
        }

        public IEnumerable<int> AbilityUpgrades { get; set; }
        public dynamic AbilityUses { get; set; }
        public dynamic AbilityTargets { get; set; }
        public int AccountId { get; set; }
        public dynamic Actions { get; set; }
        public dynamic AdditionalUnits { get; set; }
        public int Assists { get; set; }
        public BackPack BackPackItems { get; set; }
        public IEnumerable<BuybackLog> BuybackLogs { get; set; }
        public IEnumerable<int> CampsStacked { get; set; }
        public IEnumerable<int> CreepesStacked { get; set; }
        public dynamic Damage { get; set; }
        public dynamic DamageInflictor { get; set; }
        public dynamic DamageInflictorReceived { get; set; }
        public dynamic DamageTaken { get; set; }
        public dynamic DamageTargets { get; set; }
        public int Deaths { get; set; }
        public int Denies { get; set; }
        public IEnumerable<int> DeniesAtDifferentTImes { get; set; }
        public int FirstBloodClaimed { get; set; }
        public int Gold { get; set; }
        public int GoldPerMinute { get; set; }
        public dynamic GoldReasons { get; set; }
        public int GoldSpent { get; set; }
        public IEnumerable<int> GoldAtDifferentTImes { get; set; }
        public int HeroDamage { get; set; }
        public int HeroHealing { get; set; }
        public IEnumerable<int> HeroHits { get; set; }
        public int HeroId { get; set; }
        public PlayerItems PlayerItems { get; set; }
        public dynamic ItemUses { get; set; }
        public dynamic KillStreaks { get; set; }
        public dynamic Killed { get; set; }
        public dynamic KilledBy { get; set; }
        public int Kills { get; set; }
        public IEnumerable<KillLog> KillLogs { get; set; }
        public dynamic LanePosition { get; set; }
        public int LastHits { get; set; }
        public LeaverStatus QuitGame { get; set; }
        public int Level { get; set; }
        public IEnumerable<int> LastHitsAtDifferentTimes { get; set; }
        public dynamic LifeState { get; set; }
        public dynamic MaxHeroHit { get; set; }
        public dynamic MultiKills { get; set; }
        public dynamic ObserverWards { get; set; }
        public IEnumerable<dynamic> ObserverLeftLogs { get; set; }
        public IEnumerable<dynamic> ObserverLogs { get; set; }
        public int ObserverWardsPlaced { get; set; }
        public int PartyId { get; set; }
        public int PartySize { get; set; }
        public dynamic PerformanceOthers { get; set; }
        public IEnumerable<PermanentBuffs> PermanentBuffs { get; set; }
        public int Pings { get; set; }
        public dynamic Purchase { get; set; }
        public bool PredVict { get; set; }
        public IEnumerable<PurchaseLog> PurchaseLogs { get; set; }
        public bool Randomed { get; set; }
        public bool Repicked { get; set; }
        public int RunePickUps { get; set; }
        public dynamic Runes { get; set; }
        public IEnumerable<RunesLog> RunesLogs { get; set; }
        public dynamic Sentries { get; set; }
        public IEnumerable<dynamic> SentriesLeftLog { get; set; }
        public IEnumerable<dynamic> SentriesLog { get; set; }
        public int SentriesPlaced { get; set; }
        public int Stuns { get; set; }
        public int TeamFightParticipations { get; set; }
        public dynamic Times { get; set; }
        public int TowerDamage { get; set; }
        public int XpPerMinute { get; set; }
        public dynamic XpReasons { get; set; }
        public IEnumerable<int> XpAtDIfferentTimes { get; set; }
        public string PersonaName { get; set; }
        public string Name { get; set; }
        public string LastLogin { get; set; }
        public bool RadianWin { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public int Cluster { get; set; }
        public LobbyType LobbyType { get; set; }
        public GameMode GameMode { get; set; }
        public int Patch { get; set; }
        public int Region { get; set; }
        public bool IsRadiant { get; set; }
        public bool Won { get; set; }
        public bool Lost { get { return !Won; } }
        public int TotalGold { get; set; }
        public int TotalXp { get; set; }
        public double KillsPerMinute { get; set; }
        public int KDA { get; set; }
        public int Abandons { get; set; }
        public int NeutralCreepsKilled { get; set; }
        public int TowerKills { get; set; }
        public int CourierKills { get; set; }
        public int LaneKills { get; set; }
        public int HeroKills { get; set; }
        public int ObserverKills { get; set; }
        public int SentryKills { get; set; }
        public int RoshanKills { get; set; }
        public int NecronomiconKills{ get; set; }
        public int AncientKills { get; set; }
        public int BuybackCount { get; set; }
        public int ObserverUses { get; set; }
        public int SentryUses { get; set; }
        public int LaneEfficiency { get; set; }
        public int LaneEfficiencyPct { get; set; }
        public int Lane { get; set; }
        public int LaneROle { get; set; }
        public bool IsRoaming { get; set; }
        public dynamic PurchaseTime { get; set; }
        public dynamic FirstPurchaseTime { get; set; }
        public dynamic ItemWin { get; set; }
        public dynamic ItemUsage { get; set; }
        public dynamic NumberOfTpScrollPurchased { get; set; }
        public int ActionsPerMinute { get; set; }
        public int LifeStateDead { get; set; }
        public int RankTier { get; set; }
        public IEnumerable<int> Cosmetics { get; set; }
        public dynamic Benchmarks { get; set; }

        internal static Player Deserialize(JToken json)
        {
            var player = new Player();

            player._playerSlotNumber = (int)json["player_slot"];
            player.AbilityTargets = json["ability_targets"]; // TODO : Deserialize and replace dynamic type with a class 
            player.AbilityUpgrades = GetAbilityUpgrades(json);
            player.AbilityUses = json["ability_uses"]; // TODO : Deserialize and replace dynamic type with a class 
            player.AccountId = (int)json["account_id"];
            player.Actions = json["actions"]; // TODO : Deserialize and replace dynamic type with a class 
            player.AdditionalUnits = json["additional_units"]; // TODO : Deserialize and replace dynamic type with a class 
            player.Assists = (int)json["assists"];
            player.BackPackItems = GetBackPackItems(json);
            player.BuybackLogs = GetBuybackLogs(json);
            player.CampsStacked = GetCampsStacked(json);
            player.CreepesStacked = GetCreepesStacked(json);
            player.Damage = json["damage"]; // TODO : Deserialize and replace dynamic type with a class 
            player.DamageInflictor = json["damage_inflictor"]; // TODO : Deserialize and replace dynamic type with a class 
            player.DamageInflictorReceived = json["damage_inflictor_received"]; // TODO : Deserialize and replace dynamic type with a class 
            player.DamageTaken = json["damage_taken"];
            player.DamageTargets = json["damage_targets"];
            player.Deaths = (int)json["deaths"];
            player.Denies = (int)json["denies"];
            player.DeniesAtDifferentTImes = GetDeniesAtDifferentTimes(json);
            player.FirstBloodClaimed = (int?)json["firstblood_claimed"] == null ? 0 : (int)json["firstblood_claimed"]; // TODO : Replace with bool
            player.Gold = (int)json["gold"];
            player.GoldPerMinute = (int)json["gold_per_min"];
            player.GoldReasons = json["gold_reasons"]; // TODO : Deserialize and replace dynamic type with a class 
            player.GoldSpent = (int)json["gold_spent"];
            player.GoldAtDifferentTImes = GetGoldAtDifferentTimes(json);
            player.HeroDamage = (int)json["hero_damage"];
            player.HeroHealing = (int)json["hero_healing"];
            player.HeroHits = GetHeroHits(json);
            player.HeroId = (int)json["hero_id"];
            player.PlayerItems = GetPlayerItems(json);
            player.ItemUses = json["item_uses"]; // TODO : Deserialize and replace dynamic type with a class 
            player.KillStreaks = json["kill_streaks"]; // TODO : Deserialize and replace dynamic type with a class 
            player.Killed = json["killed"]; // TODO : Deserialize and replace dynamic type with a class 
            player.KilledBy = json["killed_by"]; // TODO : Deserialize and replace dynamic type with a class 
            player.Kills = (int)json["kills"];
            player.KillLogs = GetKillLogs(json);
            player.LanePosition = json["lane_pos"]; // TODO : Deserialize and replace dynamic type with a class 
            player.LastHits = (int)json["last_hits"];
            player.QuitGame = (LeaverStatus)(int)json["leaver_status"];
            player.Level = (int)json["level"];
            player.LastHitsAtDifferentTimes = GetLastHitsAtDifferentTimes(json);
            player.LifeState = json["life_state"]; // TODO : Deserialize and replace dynamic type with a class 
            player.MaxHeroHit = json["max_hero_hit"]; // TODO : Deserialize and replace dynamic type with a class 
            player.MultiKills = json["multi_kills"]; // TODO : Deserialize and replace dynamic type with a class 
            player.ObserverWards = json["obs"]; // TODO : Deserialize and replace dynamic type with a class 
            player.ObserverLeftLogs = GetObserverLeftLogs(json);
            player.ObserverLogs = GetObserverLogs(json);
            player.ObserverWardsPlaced = (int?)json["obs_placed"] == null ? 0 : (int)json["obs_placed"];
            player.PartyId = (int?)json["party_id"] == null  ? 0 : (int)json["party_id"];
            player.PartySize = (int?)json["party_size"] == null ? 0 : (int)json["party_size"];
            player.PerformanceOthers = json["performance_others"]; // TODO : Deserialize and replace dynamic type with a class 
            player.PermanentBuffs = GetPermanentBuffs(json);
            player.Pings = (int)json["pings"];
            player.PredVict = (bool?)json["pred_vict"] == null ? false : (bool)json["pred_vict"]; // TODO : better naming for property
            player.Purchase = json["purchase"]; // TODO : Deserialize and replace dynamic type with a class 
            player.PurchaseLogs = GetPurchaseLogs(json);
            player.Randomed = (bool?)json["randomed"] == null ? false : (bool)json["randomed"];
            player.Repicked = (bool?)json["repicked"] == null ? false : (bool)json["repicked"];
            player.RoshanKills = (int?)json["roshans_killed"] == null ? 0 : (int)json["roshans_killed"];
            player.RunePickUps = (int?)json["rune_pickups"] == null ? 0 : (int)json["rune_pickups"];
            player.Runes = json["runes"]; // TODO : Deserialize and replace dynamic type with a class 
            player.RunesLogs = GetRunesLogs(json);
            player.Sentries = json["sen"]; // TODO : Deserialize and replace dynamic type with a class 
            player.SentriesLeftLog = GetSentriesLeftLog(json);
            player.SentriesLog = GetSentriesLog(json);
            player.SentriesPlaced = (int?)json["sen_placed"] == null ? 0 : (int)json["sen_placed"];
            player.Stuns = (int)json["stuns"];
            player.TeamFightParticipations = (int?)json["teamfight_participation"] == null ? 0 : (int)json["teamfight_participation"];
            player.Times = json["times"]; // TODO : Deserialize and replace dynamic type with a class 
            player.TowerDamage = (int)json["tower_damage"];
            player.TowerKills = (int?)json["towers_killed"] == null ? 0 : (int)json["towers_killed"];
            player.XpPerMinute = (int)json["xp_per_min"];
            player.XpReasons = json["xp_reasons"]; // TODO : Deserialize and replace dynamic type with a class 
            player.XpAtDIfferentTimes = GetXpAtDifferentTimes(json);  // TODO : Deserialize and replace dynamic type with a class 
            player.PersonaName = json["personaname"].ToString();
            player.Name = json["name"].ToString();
            player.LastLogin = json["last_login"].ToString(); // TODO : Change to datetime
            player.RadianWin = (bool)json["radiant_win"];
            player.StartTime = DateTimeOffset.FromUnixTimeSeconds((int)json["start_time"]).DateTime;
            player.Duration = TimeSpan.FromSeconds((int)json["duration"]);
            player.Cluster = (int)json["cluster"];
            player.LobbyType = (LobbyType)(int)json["lobby_type"];
            player.GameMode = (GameMode)(int)json["game_mode"];
            player.Patch = (int)json["patch"];
            player.Region = (int)json["region"];
            player.IsRadiant = (bool)json["isRadiant"];
            player.Won = (int)json["win"] == 0 ? false : true;
            player.TotalGold = (int)json["total_gold"];
            player.TotalXp = (int)json["total_xp"];
            player.KillsPerMinute = (double)json["kills_per_min"];
            player.KDA = (int)json["kda"];
            player.Abandons = (int)json["abandons"];
            player.NeutralCreepsKilled = (int)json["neutral_kills"];
            player.TowerKills = (int)json["tower_kills"];
            player.CourierKills = (int)json["courier_kills"];
            player.LaneKills = (int)json["lane_kills"];
            player.HeroKills = (int)json["hero_kills"];
            player.ObserverKills = (int)json["observer_kills"];
            player.SentryKills = (int)json["sentry_kills"];
            player.RoshanKills = (int)json["roshan_kills"];
            player.NecronomiconKills = (int)json["necronomicon_kills"];
            player.AncientKills = (int)json["ancient_kills"];
            player.BuybackCount = (int)json["buyback_count"];
            player.ObserverUses = (int)json["observer_uses"];
            player.SentryUses = json.Value<int>("semtry_uses");
            player.IsRoaming = (bool)json["is_roaming"];
            player.PurchaseTime = json["purchase_time"]; // TODO : Deserialize and replace dynamic type with a class 
            player.FirstPurchaseTime = json["first_purchase_time"]; // TODO : Deserialize and replace dynamic type with a class 
            player.ItemWin = json["item_win"]; // TODO : Deserialize and replace dynamic type with a class 
            player.ItemUsage = json["item_usage"]; // TODO : Deserialize and replace dynamic type with a class 
            player.ActionsPerMinute = (int)json["actions_per_min"];
            player.LifeStateDead = json.Value<int>("life_state_dead");
            player.RankTier = (int?)json["rank_tier"] == null ? 0 : (int)json["rank_tier"];
            player.Cosmetics = GetCosmetics(json);
            player.Benchmarks = json["benchmarks"]; // TODO : Deserialize and replace dynamic type with a class 

            return player;
        }

        private static IEnumerable<int> GetCosmetics(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<int> GetXpAtDifferentTimes(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<dynamic> GetSentriesLog(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<dynamic> GetSentriesLeftLog(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<RunesLog> GetRunesLogs(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<PurchaseLog> GetPurchaseLogs(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<PermanentBuffs> GetPermanentBuffs(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<dynamic> GetObserverLogs(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<dynamic> GetObserverLeftLogs(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<int> GetCreepesStacked(JToken json)
        {
            return null; // TODO : Deserialize
            //return (int)json["creeps_stacked"];
        }

        private static IEnumerable<int> GetCampsStacked(JToken json)
        {
            return null; // TODO : Deserialize
            //return (int)json["camps_stacked"];
        }

        private static IEnumerable<int> GetHeroHits(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<int> GetLastHitsAtDifferentTimes(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<KillLog> GetKillLogs(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static PlayerItems GetPlayerItems(JToken json)
        {
            return new PlayerItems()
            {
                Item0 = (int)json["item_0"],
                Item1 = (int)json["item_1"],
                Item2 = (int)json["item_2"],
                Item3 = (int)json["item_3"],
                Item4 = (int)json["item_4"],
                Item5 = (int)json["item_5"],
            };
        }

        private static IEnumerable<int> GetGoldAtDifferentTimes(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<int> GetDeniesAtDifferentTimes(JToken json)
        {
            return null; // TODO : Deserialize
        }

        private static IEnumerable<BuybackLog> GetBuybackLogs(JToken json)
        {
            return null; // TODO : Deserialize 
        }

        private static BackPack GetBackPackItems(JToken json)
        {
            return new BackPack
            {
                Slot0 = (int)json["backpack_0"],
                Slot1 = (int)json["backpack_1"],
                Slot3 = (int)json["backpack_2"]
            };
        }

        private static IEnumerable<int> GetAbilityUpgrades(JToken json)
        {
            return null; // TODO : Deserialize and replace dynamic type with a class 
        }
    }
}
