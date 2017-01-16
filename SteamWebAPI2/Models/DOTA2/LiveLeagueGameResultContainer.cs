using Newtonsoft.Json;
using Steam.Models.DOTA2;
using SteamWebAPI2.Interfaces;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    internal class LiveLeagueGameTeamRadiantInfo
    {
        [JsonProperty(PropertyName = "team_name")]
        public string TeamName { get; set; }

        [JsonProperty(PropertyName = "team_id")]
        public uint TeamId { get; set; }

        [JsonProperty(PropertyName = "team_logo")]
        public ulong TeamLogo { get; set; }

        public bool Complete { get; set; }
    }

    internal class LiveLeagueGameTeamRadiantDetail
    {
        public uint Score { get; set; }

        [JsonProperty(PropertyName = "tower_state")]
        public uint TowerState { get; set; }

        [JsonProperty(PropertyName = "barracks_state")]
        public uint BarracksState { get; set; }

        public IList<LiveLeagueGamePick> Picks { get; set; }
        public IList<LiveLeagueGameBan> Bans { get; set; }
        public IList<LiveLeagueGamePlayerDetail> Players { get; set; }
        public IList<LiveLeagueGameAbility> Abilities { get; set; }

        public TowerStateModel TowerStates { get { return new TowerStateModel(TowerState); } }
        public TowerStateModel BarracksStates { get { return new TowerStateModel(BarracksState); } }
    }

    internal class LiveLeagueGameTeamDireInfo
    {
        [JsonProperty(PropertyName = "team_name")]
        public string TeamName { get; set; }

        [JsonProperty(PropertyName = "team_id")]
        public uint TeamId { get; set; }

        [JsonProperty(PropertyName = "team_logo")]
        public ulong TeamLogo { get; set; }

        public bool Complete { get; set; }
    }

    internal class LiveLeagueGameTeamDireDetail
    {
        public uint Score { get; set; }

        [JsonProperty(PropertyName = "tower_state")]
        public uint TowerState { get; set; }

        [JsonProperty(PropertyName = "barracks_state")]
        public uint BarracksState { get; set; }

        public IList<LiveLeagueGamePick> Picks { get; set; }
        public IList<LiveLeagueGameBan> Bans { get; set; }
        public IList<LiveLeagueGamePlayerDetail> Players { get; set; }
        public IList<LiveLeagueGameAbility> Abilities { get; set; }

        public TowerStateModel TowerStates { get { return new TowerStateModel(TowerState); } }
    }

    internal class LiveLeagueGameScoreboard
    {
        public double Duration { get; set; }

        [JsonProperty(PropertyName = "roshan_respawn_timer")]
        public uint RoshanRespawnTimer { get; set; }

        public LiveLeagueGameTeamRadiantDetail Radiant { get; set; }
        public LiveLeagueGameTeamDireDetail Dire { get; set; }
    }

    internal class LiveLeagueGame
    {
        public IList<LiveLeagueGamePlayerInfo> Players { get; set; }

        [JsonProperty(PropertyName = "radiant_team")]
        public LiveLeagueGameTeamRadiantInfo RadiantTeam { get; set; }

        [JsonProperty(PropertyName = "dire_team")]
        public LiveLeagueGameTeamDireInfo DireTeam { get; set; }

        [JsonProperty(PropertyName = "lobby_id")]
        public ulong LobbyId { get; set; }

        [JsonProperty(PropertyName = "match_id")]
        public ulong MatchId { get; set; }

        public uint Spectators { get; set; }

        [JsonProperty(PropertyName = "series_id")]
        public uint SeriesId { get; set; }

        [JsonProperty(PropertyName = "game_number")]
        public uint GameNumber { get; set; }

        [JsonProperty(PropertyName = "league_id")]
        public uint LeagueId { get; set; }

        [JsonProperty(PropertyName = "stream_delay_s")]
        public double StreamDelaySeconds { get; set; }

        [JsonProperty(PropertyName = "radiant_series_wins")]
        public uint RadiantSeriesWins { get; set; }

        [JsonProperty(PropertyName = "dire_series_wins")]
        public uint DireSeriesWins { get; set; }

        [JsonProperty(PropertyName = "series_type")]
        public uint SeriesType { get; set; }

        [JsonProperty(PropertyName = "league_series_id")]
        public uint LeagueSeriesId { get; set; }

        [JsonProperty(PropertyName = "league_game_id")]
        public uint LeagueGameId { get; set; }

        [JsonProperty(PropertyName = "stage_name")]
        public string StageName { get; set; }

        [JsonProperty(PropertyName = "league_tier")]
        public DotaLeagueTier LeagueTier { get; set; }

        public LiveLeagueGameScoreboard Scoreboard { get; set; }
    }

    internal class LiveLeagueGameAbility
    {
        [JsonProperty(PropertyName = "ability_id")]
        public uint AbilityId { get; set; }

        [JsonProperty(PropertyName = "ability_level")]
        public uint AbilityLevel { get; set; }
    }

    internal class LiveLeagueGameBan
    {
        [JsonProperty(PropertyName = "hero_id")]
        public uint HeroId { get; set; }
    }

    internal class LiveLeagueGamePick
    {
        [JsonProperty(PropertyName = "hero_id")]
        public uint HeroId { get; set; }
    }

    internal class LiveLeagueGamePlayerDetail
    {
        [JsonProperty(PropertyName = "player_slot")]
        public uint PlayerSlot { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public uint AccountId { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public uint HeroId { get; set; }

        public uint Kills { get; set; }

        [JsonProperty(PropertyName = "death")]
        public uint Deaths { get; set; }

        public uint Assists { get; set; }

        [JsonProperty(PropertyName = "last_hits")]
        public uint LastHits { get; set; }

        public uint Denies { get; set; }
        public uint Gold { get; set; }
        public uint Level { get; set; }

        [JsonProperty(PropertyName = "gold_per_min")]
        public uint GoldPerMinute { get; set; }

        [JsonProperty(PropertyName = "xp_per_min")]
        public uint ExperiencePerMinute { get; set; }

        [JsonProperty(PropertyName = "ultimate_state")]
        public uint UltimateState { get; set; }

        [JsonProperty(PropertyName = "ultimate_cooldown")]
        public uint UltimateCooldown { get; set; }

        public uint Item0 { get; set; }
        public uint Item1 { get; set; }
        public uint Item2 { get; set; }
        public uint Item3 { get; set; }
        public uint Item4 { get; set; }
        public uint Item5 { get; set; }

        [JsonProperty(PropertyName = "respawn_timer")]
        public uint RespawnTimer { get; set; }

        [JsonProperty(PropertyName = "position_x")]
        public double PositionX { get; set; }

        [JsonProperty(PropertyName = "position_y")]
        public double PositionY { get; set; }

        [JsonProperty(PropertyName = "net_worth")]
        public uint NetWorth { get; set; }
    }

    internal class LiveLeagueGamePlayerInfo
    {
        [JsonProperty(PropertyName = "account_id")]
        public uint AccountId { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public uint HeroId { get; set; }

        public uint Team { get; set; }
    }

    internal class LiveLeagueGameResult
    {
        public IList<LiveLeagueGame> Games { get; set; }
        public uint Status { get; set; }
    }

    internal class LiveLeagueGameResultContainer
    {
        public LiveLeagueGameResult Result { get; set; }
    }
}