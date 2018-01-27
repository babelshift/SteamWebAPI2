using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class MatchPlayerAbilityUpgrade
    {
        public uint Ability { get; set; }
        public uint Time { get; set; }
        public uint Level { get; set; }
    }

    internal class MatchPlayer
    {
        [JsonProperty(PropertyName = "account_id")]
        public uint AccountId { get; set; }

        [JsonProperty(PropertyName = "player_slot")]
        public uint PlayerSlot { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public uint HeroId { get; set; }

        [JsonProperty(PropertyName = "item_0")]
        public uint Item0 { get; set; }

        [JsonProperty(PropertyName = "item_1")]
        public uint Item1 { get; set; }

        [JsonProperty(PropertyName = "item_2")]
        public uint Item2 { get; set; }

        [JsonProperty(PropertyName = "item_3")]
        public uint Item3 { get; set; }

        [JsonProperty(PropertyName = "item_4")]
        public uint Item4 { get; set; }

        [JsonProperty(PropertyName = "item_5")]
        public uint Item5 { get; set; }

        public uint Kills { get; set; }
        public uint Deaths { get; set; }
        public uint Assists { get; set; }

        [JsonProperty(PropertyName = "leaver_status")]
        public uint LeaverStatus { get; set; }

        public uint Gold { get; set; }

        [JsonProperty(PropertyName = "last_hits")]
        public uint LastHits { get; set; }

        public uint Denies { get; set; }

        [JsonProperty(PropertyName = "gold_per_min")]
        public uint GoldPerMinute { get; set; }

        [JsonProperty(PropertyName = "xp_per_min")]
        public uint ExperiencePerMinute { get; set; }

        [JsonProperty(PropertyName = "gold_spent")]
        public uint GoldSpent { get; set; }

        [JsonProperty(PropertyName = "hero_damage")]
        public uint HeroDamage { get; set; }

        [JsonProperty(PropertyName = "tower_damage")]
        public uint TowerDamage { get; set; }

        [JsonProperty(PropertyName = "hero_healing")]
        public uint HeroHealing { get; set; }

        public uint Level { get; set; }

        [JsonProperty(PropertyName = "ability_upgrades")]
        public IList<MatchPlayerAbilityUpgrade> AbilityUpgrades { get; set; }
    }

    internal class MatchPickBan
    {
        [JsonProperty(PropertyName = "is_pick")]
        public bool IsPick { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public uint HeroId { get; set; }

        public uint Team { get; set; }
        public uint Order { get; set; }
    }

    internal class MatchDetailResult
    {
        public IList<MatchPlayer> Players { get; set; }

        [JsonProperty(PropertyName = "radiant_win")]
        public bool RadiantWin { get; set; }

        public uint Duration { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public ulong StartTime { get; set; }

        [JsonProperty(PropertyName = "match_id")]
        public ulong MatchId { get; set; }

        [JsonProperty(PropertyName = "match_seq_num")]
        public uint MatchSequenceNumber { get; set; }

        [JsonProperty(PropertyName = "tower_status_radiant")]
        public uint TowerStatusRadiant { get; set; }

        [JsonProperty(PropertyName = "tower_status_dire")]
        public uint TowerStatusDire { get; set; }

        [JsonProperty(PropertyName = "barracks_status_radiant")]
        public uint BarracksStatusRadiant { get; set; }

        [JsonProperty(PropertyName = "barracks_status_dire")]
        public uint BarracksStatusDire { get; set; }

        public uint Cluster { get; set; }

        [JsonProperty(PropertyName = "first_blood_time")]
        public uint FirstBloodTime { get; set; }

        [JsonProperty(PropertyName = "lobby_type")]
        public uint LobbyType { get; set; }

        [JsonProperty(PropertyName = "human_players")]
        public uint HumanPlayers { get; set; }

        [JsonProperty(PropertyName = "league_id")]
        public uint LeagueId { get; set; }

        [JsonProperty(PropertyName = "positive_votes")]
        public uint PositiveVotes { get; set; }

        [JsonProperty(PropertyName = "negative_votes")]
        public uint NegativeVotes { get; set; }

        [JsonProperty(PropertyName = "game_mode")]
        public uint GameMode { get; set; }

        public uint Engine { get; set; }

        [JsonProperty(PropertyName = "radiant_team_id")]
        public uint RadiantTeamId { get; set; }

        [JsonProperty(PropertyName = "radiant_name")]
        public string RadiantName { get; set; }

        [JsonProperty(PropertyName = "radiant_logo")]
        public ulong RadiantLogo { get; set; }

        [JsonProperty(PropertyName = "radiant_team_complete")]
        public uint RadiantTeamComplete { get; set; }

        [JsonProperty(PropertyName = "dire_team_id")]
        public uint DireTeamId { get; set; }

        [JsonProperty(PropertyName = "dire_name")]
        public string DireName { get; set; }

        [JsonProperty(PropertyName = "dire_logo")]
        public ulong DireLogo { get; set; }

        [JsonProperty(PropertyName = "dire_team_complete")]
        public uint DireTeamComplete { get; set; }

        [JsonProperty(PropertyName = "radiant_captain")]
        public uint RadiantCaptain { get; set; }

        [JsonProperty(PropertyName = "dire_captain")]
        public uint DireCaptain { get; set; }

        [JsonProperty(PropertyName = "picks_bans")]
        public IList<MatchPickBan> PicksAndBans { get; set; }
    }

    internal class MatchDetailResultContainer
    {
        public MatchDetailResult Result { get; set; }
    }
}