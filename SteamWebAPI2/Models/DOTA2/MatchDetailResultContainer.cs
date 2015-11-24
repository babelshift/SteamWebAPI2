using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class MatchPlayerAbilityUpgrade
    {
        public int Ability { get; set; }
        public int Time { get; set; }
        public int Level { get; set; }
    }

    public class MatchPlayer
    {
        [JsonProperty(PropertyName = "account_id")]
        public int AccountId { get; set; }

        [JsonProperty(PropertyName = "player_slot")]
        public int PlayerSlot { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }

        [JsonProperty(PropertyName = "item_0")]
        public int Item0 { get; set; }

        [JsonProperty(PropertyName = "item_1")]
        public int Item1 { get; set; }

        [JsonProperty(PropertyName = "item_2")]
        public int Item2 { get; set; }

        [JsonProperty(PropertyName = "item_3")]
        public int Item3 { get; set; }

        [JsonProperty(PropertyName = "item_4")]
        public int Item4 { get; set; }

        [JsonProperty(PropertyName = "item_5")]
        public int Item5 { get; set; }

        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }

        [JsonProperty(PropertyName = "leaver_status")]
        public int LeaverStatus { get; set; }

        public int Gold { get; set; }

        [JsonProperty(PropertyName = "last_hits")]
        public int LastHits { get; set; }

        public int Denies { get; set; }

        [JsonProperty(PropertyName = "gold_per_min")]
        public int GoldPerMinute { get; set; }

        [JsonProperty(PropertyName = "xp_per_min")]
        public int ExperiencePerMinute { get; set; }

        [JsonProperty(PropertyName = "gold_spent")]
        public int GoldSpent { get; set; }

        [JsonProperty(PropertyName = "hero_damage")]
        public int HeroDamage { get; set; }

        [JsonProperty(PropertyName = "tower_damage")]
        public int TowerDamage { get; set; }

        [JsonProperty(PropertyName = "hero_healing")]
        public int HeroHealing { get; set; }

        public int Level { get; set; }

        [JsonProperty(PropertyName = "ability_upgrades")]
        public IList<MatchPlayerAbilityUpgrade> AbilityUpgrades { get; set; }
    }

    public class MatchPickBan
    {
        [JsonProperty(PropertyName = "is_pick")]
        public bool IsPick { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }

        public int Team { get; set; }
        public int Order { get; set; }
    }

    public class MatchDetailResult
    {
        public IList<MatchPlayer> Players { get; set; }

        [JsonProperty(PropertyName = "radiant_win")]
        public bool RadiantWin { get; set; }

        public int Duration { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public int StartTime { get; set; }

        [JsonProperty(PropertyName = "match_id")]
        public int MatchId { get; set; }

        [JsonProperty(PropertyName = "match_seq_num")]
        public int MatchSequenceNumber { get; set; }

        [JsonProperty(PropertyName = "tower_status_radiant")]
        public int TowerStatusRadiant { get; set; }

        [JsonProperty(PropertyName = "tower_status_dire")]
        public int TowerStatusDire { get; set; }

        [JsonProperty(PropertyName = "barracks_status_radiant")]
        public int BarracksStatusRadiant { get; set; }

        [JsonProperty(PropertyName = "barracks_status_dire")]
        public int BarracksStatusDire { get; set; }

        public int Cluster { get; set; }

        [JsonProperty(PropertyName = "first_blood_time")]
        public int FirstBloodTime { get; set; }

        [JsonProperty(PropertyName = "lobby_type")]
        public int LobbyType { get; set; }

        [JsonProperty(PropertyName = "human_players")]
        public int HumanPlayers { get; set; }

        [JsonProperty(PropertyName = "league_id")]
        public int LeagueId { get; set; }

        [JsonProperty(PropertyName = "positive_votes")]
        public int PositiveVotes { get; set; }

        [JsonProperty(PropertyName = "negative_votes")]
        public int NegativeVotes { get; set; }

        [JsonProperty(PropertyName = "game_mode")]
        public int GameMode { get; set; }

        public int Engine { get; set; }

        [JsonProperty(PropertyName = "radiant_team_id")]
        public int RadiantTeamId { get; set; }

        [JsonProperty(PropertyName = "radiant_name")]
        public string RadiantName { get; set; }

        [JsonProperty(PropertyName = "radiant_logo")]
        public long RadiantLogo { get; set; }

        [JsonProperty(PropertyName = "radiant_team_complete")]
        public int RadiantTeamComplete { get; set; }

        [JsonProperty(PropertyName = "dire_team_id")]
        public int DireTeamId { get; set; }

        [JsonProperty(PropertyName = "dire_name")]
        public string DireName { get; set; }

        [JsonProperty(PropertyName = "dire_logo")]
        public long DireLogo { get; set; }

        [JsonProperty(PropertyName = "dire_team_complete")]
        public int DireTeamComplete { get; set; }

        [JsonProperty(PropertyName = "radiant_captain")]
        public int RadiantCaptain { get; set; }

        [JsonProperty(PropertyName = "dire_captain")]
        public int DireCaptain { get; set; }

        [JsonProperty(PropertyName = "picks_bans")]
        public IList<MatchPickBan> PicksAndBans { get; set; }
    }

    public class MatchDetailResultContainer
    {
        public MatchDetailResult Result { get; set; }
    }
}