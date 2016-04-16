using Newtonsoft.Json;
using SteamWebAPI2.Utilities.JsonConverters;
using System;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class MatchHistoryBySequenceNumberMatchPlayerAbilityUpgrade
    {
        [JsonProperty(PropertyName = "ability")]
        public int Ability { get; set; }

        [JsonProperty(PropertyName = "time")]
        public int Time { get; set; }

        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }
    }

    internal class MatchHistoryBySequenceNumberMatchPlayer
    {
        [JsonProperty(PropertyName = "ability_upgrades")]
        public IList<MatchHistoryBySequenceNumberMatchPlayerAbilityUpgrade> AbilityUpgrades { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public long AccountId { get; set; }

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

        [JsonProperty(PropertyName = "kills")]
        public int Kills { get; set; }

        [JsonProperty(PropertyName = "deaths")]
        public int Deaths { get; set; }

        [JsonProperty(PropertyName = "assists")]
        public int Assists { get; set; }

        [JsonProperty(PropertyName = "leaver_status")]
        public int LeaverStatus { get; set; }

        [JsonProperty(PropertyName = "last_hits")]
        public int LastHits { get; set; }

        [JsonProperty(PropertyName = "denies")]
        public int Denies { get; set; }

        [JsonProperty(PropertyName = "gold_per_min")]
        public int GoldPerMin { get; set; }

        [JsonProperty(PropertyName = "xp_per_min")]
        public int XpPerMin { get; set; }

        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }

        [JsonProperty(PropertyName = "gold")]
        public int Gold { get; set; }

        [JsonProperty(PropertyName = "gold_spent")]
        public int GoldSpent { get; set; }

        [JsonProperty(PropertyName = "hero_damage")]
        public int HeroDamage { get; set; }

        [JsonProperty(PropertyName = "tower_damage")]
        public int TowerDamage { get; set; }

        [JsonProperty(PropertyName = "hero_healing")]
        public int HeroHealing { get; set; }
    }

    internal class MatchHistoryBySequenceNumberMatch
    {
        [JsonProperty(PropertyName = "players")]
        public IList<MatchHistoryBySequenceNumberMatchPlayer> Players { get; set; }

        [JsonProperty(PropertyName = "radiant_win")]
        public bool RadiantWin { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTime StartTime { get; set; }

        [JsonProperty(PropertyName = "match_id")]
        public long MatchId { get; set; }

        [JsonProperty(PropertyName = "match_seq_num")]
        public int MatchSequenceNumber { get; set; }

        [JsonProperty(PropertyName = "tower_status_radiant")]
        public int RadiantTowerStatus { get; set; }

        [JsonProperty(PropertyName = "tower_status_dire")]
        public int DireTowerStatus { get; set; }

        [JsonProperty(PropertyName = "barracks_status_radiant")]
        public int RadiantBarracksStatus { get; set; }

        [JsonProperty(PropertyName = "barracks_status_dire")]
        public int DireBarracksStatus { get; set; }

        [JsonProperty(PropertyName = "cluster")]
        public int Cluster { get; set; }

        [JsonProperty(PropertyName = "first_blood_time")]
        public long FirstBloodTime { get; set; }

        [JsonProperty(PropertyName = "lobby_type")]
        public int LobbyType { get; set; }

        [JsonProperty(PropertyName = "human_players")]
        public int HumanPlayers { get; set; }

        [JsonProperty(PropertyName = "leagueid")]
        public int LeagueId { get; set; }

        [JsonProperty(PropertyName = "positive_votes")]
        public int PositiveVotes { get; set; }

        [JsonProperty(PropertyName = "negative_votes")]
        public int NegativeVotes { get; set; }

        [JsonProperty(PropertyName = "game_mode")]
        public int GameMode { get; set; }

        [JsonProperty(PropertyName = "flags")]
        public int Flags { get; set; }

        [JsonProperty(PropertyName = "engine")]
        public int Engine { get; set; }

        [JsonProperty(PropertyName = "radiant_score")]
        public int RadiantScore { get; set; }

        [JsonProperty(PropertyName = "dire_score")]
        public int DireScore { get; set; }
    }

    internal class MatchHistoryBySequenceNumberResult
    {
        public int Status { get; set; }
        public IList<MatchHistoryBySequenceNumberMatch> Matches { get; set; }
    }

    internal class MatchHistoryBySequenceNumberResultContainer
    {
        public MatchHistoryBySequenceNumberResult Result { get; set; }
    }
}