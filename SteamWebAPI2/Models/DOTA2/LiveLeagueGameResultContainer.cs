using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.DOTA2
{
    public class LiveLeagueGameTeamRadiantInfo
    {
        [JsonProperty(PropertyName = "team_name")]
        public string TeamName { get; set; }

        [JsonProperty(PropertyName = "team_id")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "team_logo")]
        public long TeamLogo { get; set; }

        public bool Complete { get; set; }
    }

    public class LiveLeagueGameTeamRadiantDetail
    {
        public int Score { get; set; }

        [JsonProperty(PropertyName = "tower_state")]
        public int TowerState { get; set; }

        [JsonProperty(PropertyName = "barracks_state")]
        public int BarracksState { get; set; }

        public IList<LiveLeagueGamePick> Picks { get; set; }
        public IList<LiveLeagueGameBan> Bans { get; set; }
        public IList<LiveLeagueGamePlayerDetail> Players { get; set; }
        public IList<LiveLeagueGameAbility> Abilities { get; set; }
    }

    public class LiveLeagueGameTeamDireInfo
    {
        [JsonProperty(PropertyName = "team_name")]
        public string TeamName { get; set; }

        [JsonProperty(PropertyName = "team_id")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "team_logo")]
        public long TeamLogo { get; set; }

        public bool Complete { get; set; }
    }

    public class LiveLeagueGameTeamDireDetail
    {
        public int Score { get; set; }

        [JsonProperty(PropertyName = "tower_state")]
        public int TowerState { get; set; }

        [JsonProperty(PropertyName = "barracks_state")]
        public int BarracksState { get; set; }

        public IList<LiveLeagueGamePick> Picks { get; set; }
        public IList<LiveLeagueGameBan> Bans { get; set; }
        public IList<LiveLeagueGamePlayerDetail> Players { get; set; }
        public IList<LiveLeagueGameAbility> Abilities { get; set; }
    }

    public class LiveLeagueGameScoreboard
    {
        public double Duration { get; set; }

        [JsonProperty(PropertyName = "roshan_respawn_timer")]
        public int RoshanRespawnTimer { get; set; }

        public LiveLeagueGameTeamRadiantDetail Radiant { get; set; }
        public LiveLeagueGameTeamDireDetail Dire { get; set; }
    }

    public class LiveLeagueGame
    {
        public IList<LiveLeagueGamePlayerInfo> Players { get; set; }

        [JsonProperty(PropertyName = "radiant_team")]
        public LiveLeagueGameTeamRadiantInfo RadiantTeam { get; set; }

        [JsonProperty(PropertyName = "dire_team")]
        public LiveLeagueGameTeamDireInfo DireTeam { get; set; }

        [JsonProperty(PropertyName = "lobby_id")]
        public long LobbyId { get; set; }

        [JsonProperty(PropertyName = "match_id")]
        public int MatchId { get; set; }

        public int Spectators { get; set; }

        [JsonProperty(PropertyName = "series_id")]
        public int SeriesId { get; set; }

        [JsonProperty(PropertyName = "game_number")]
        public int GameNumber { get; set; }

        [JsonProperty(PropertyName = "league_id")]
        public int LeagueId { get; set; }

        [JsonProperty(PropertyName = "stream_delay_s")]
        public double StreamDelaySeconds { get; set; }

        [JsonProperty(PropertyName = "radiant_series_wins")]
        public int RadiantSeriesWins { get; set; }

        [JsonProperty(PropertyName = "dire_series_wins")]
        public int DireSeriesWins { get; set; }

        [JsonProperty(PropertyName = "series_type")]
        public int SeriesType { get; set; }

        [JsonProperty(PropertyName = "league_series_id")]
        public int LeagueSeriesId { get; set; }

        [JsonProperty(PropertyName = "league_game_id")]
        public int LeagueGameId { get; set; }

        [JsonProperty(PropertyName = "stage_name")]
        public string StageName { get; set; }

        [JsonProperty(PropertyName = "league_tier")]
        public int LeagueTier { get; set; }

        public LiveLeagueGameScoreboard Scoreboard { get; set; }
    }

    public class LiveLeagueGameAbility
    {
        [JsonProperty(PropertyName = "ability_id")]
        public int AbilityId { get; set; }

        [JsonProperty(PropertyName = "ability_level")]
        public int AbilityLevel { get; set; }
    }

    public class LiveLeagueGameBan
    {
        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }
    }

    public class LiveLeagueGamePick
    {
        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }
    }

    public class LiveLeagueGamePlayerDetail
    {
        [JsonProperty(PropertyName = "player_slot")]
        public int PlayerSlot { get; set; }

        [JsonProperty(PropertyName = "account_id")]
        public int AccountId { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }

        public int Kills { get; set; }

        [JsonProperty(PropertyName = "death")]
        public int Deaths { get; set; }

        public int Assists { get; set; }

        [JsonProperty(PropertyName = "last_hits")]
        public int LastHits { get; set; }

        public int Denies { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }

        [JsonProperty(PropertyName = "gold_per_min")]
        public int GoldPerMinute { get; set; }

        [JsonProperty(PropertyName = "xp_per_min")]
        public int ExperiencePerMinute { get; set; }

        [JsonProperty(PropertyName = "ultimate_state")]
        public int UltimateState { get; set; }

        [JsonProperty(PropertyName = "ultimate_cooldown")]
        public int UltimateCooldown { get; set; }

        public int Item0 { get; set; }
        public int Item1 { get; set; }
        public int Item2 { get; set; }
        public int Item3 { get; set; }
        public int Item4 { get; set; }
        public int Item5 { get; set; }

        [JsonProperty(PropertyName = "respawn_timer")]
        public int RespawnTimer { get; set; }

        [JsonProperty(PropertyName = "position_x")]
        public double PositionX { get; set; }

        [JsonProperty(PropertyName = "position_y")]
        public double PositionY { get; set; }

        [JsonProperty(PropertyName = "net_worth")]
        public int NetWorth { get; set; }
    }

    public class LiveLeagueGamePlayerInfo
    {
        [JsonProperty(PropertyName = "account_id")]
        public int AccountId { get; set; }

        public string Name { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }

        public int Team { get; set; }
    }

    public class LiveLeagueGameResult
    {
        public IList<LiveLeagueGame> Games { get; set; }
        public int Status { get; set; }
    }

    internal class LiveLeagueGameResultContainer
    {
        public LiveLeagueGameResult Result { get; set; }
    }
}