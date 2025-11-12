using Steam.Models.DOTA2;
using SteamWebAPI2.Models.DOTA2;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SteamWebAPI2.Interfaces
{
    public class DOTA2Match : IDOTA2Match
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public DOTA2Match(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("IDOTA2Match_570", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a collection of all live league games and details. Live league games are games registered in a Dota 2 league and are currently being played.
        /// </summary>
        /// <param name="leagueId"></param>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<LiveLeagueGameModel>>> GetLiveLeagueGamesAsync(uint? leagueId = null, ulong? matchId = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(leagueId, "league_id");
            parameters.AddIfHasValue(matchId, "match_id");

            var steamWebResponse = await steamWebInterface.GetAsync<LiveLeagueGameResultContainer>("GetLiveLeagueGames", 1);

            return steamWebResponse.MapTo<IReadOnlyCollection<LiveLeagueGameModel>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.Games?.Select(x => new LiveLeagueGameModel
                {
                    Players = x.Players?.Select(p => new LiveLeagueGamePlayerInfoModel
                    {
                        AccountId = p.AccountId,
                        HeroId = p.HeroId,
                        Name = p.Name,
                        Team = p.Team
                    }).ToList().AsReadOnly(),
                    RadiantTeam = x.RadiantTeam == null ? null : new LiveLeagueGameTeamRadiantInfoModel
                    {
                        TeamId = x.RadiantTeam.TeamId,
                        TeamName = x.RadiantTeam.TeamName,
                        TeamLogo = x.RadiantTeam.TeamLogo,
                        Complete = x.RadiantTeam.Complete
                    },
                    DireTeam = x.DireTeam == null ? null : new LiveLeagueGameTeamDireInfoModel
                    {
                        TeamId = x.DireTeam.TeamId,
                        TeamName = x.DireTeam.TeamName,
                        TeamLogo = x.DireTeam.TeamLogo,
                        Complete = x.DireTeam.Complete
                    },
                    LobbyId = x.LobbyId,
                    DireSeriesWins = x.DireSeriesWins,
                    RadiantSeriesWins = x.RadiantSeriesWins,
                    LeagueId = x.LeagueId,
                    MatchId = x.MatchId,
                    Spectators = x.Spectators,
                    GameNumber = x.GameNumber,
                    LeagueGameId = x.LeagueGameId,
                    LeagueSeriesId = x.LeagueSeriesId,
                    StreamDelaySeconds = x.StreamDelaySeconds,
                    LeagueTier = x.LeagueTier,
                    Scoreboard = x.Scoreboard == null ? null : new LiveLeagueGameScoreboardModel
                    {
                        Dire = x.Scoreboard.Dire == null ? null : new LiveLeagueGameTeamDireDetailModel
                        {
                            Abilities = x.Scoreboard.Dire.Abilities?.Select(a => new LiveLeagueGameAbilityModel
                            {
                                AbilityId = a.AbilityId,
                                AbilityLevel = a.AbilityLevel
                            }).ToList().AsReadOnly(),
                            Bans = x.Scoreboard.Dire.Bans?.Select(b => new LiveLeagueGameBanModel
                            {
                                HeroId = b.HeroId
                            }).ToList().AsReadOnly(),
                            BarracksState = x.Scoreboard.Dire?.BarracksState ?? 0,
                            Picks = x.Scoreboard.Dire.Picks?.Select(p => new LiveLeagueGamePickModel
                            {
                                HeroId = p.HeroId,
                            }).ToList().AsReadOnly(),
                            Players = x.Scoreboard.Dire.Players?
                                .Select(p => MapToLiveLeagueGamePlayerDetail(p))
                                .ToList()
                                .AsReadOnly(),
                            Score = x.Scoreboard.Dire.Score,
                            TowerState = x.Scoreboard.Dire.TowerState
                        },
                        Radiant = x.Scoreboard.Radiant == null ? null : new LiveLeagueGameTeamRadiantDetailModel
                        {
                            Abilities = x.Scoreboard.Radiant.Abilities?.Select(a => new LiveLeagueGameAbilityModel
                            {
                                AbilityId = a.AbilityId,
                                AbilityLevel = a.AbilityLevel
                            }).ToList().AsReadOnly(),
                            Bans = x.Scoreboard.Radiant.Bans?.Select(b => new LiveLeagueGameBanModel
                            {
                                HeroId = b.HeroId
                            }).ToList().AsReadOnly(),
                            BarracksState = x.Scoreboard.Radiant?.BarracksState ?? 0,
                            Picks = x.Scoreboard.Radiant.Picks?.Select(p => new LiveLeagueGamePickModel
                            {
                                HeroId = p.HeroId,
                            }).ToList().AsReadOnly(),
                            Players = x.Scoreboard.Radiant.Players?
                                .Select(p => MapToLiveLeagueGamePlayerDetail(p))
                                .ToList()
                                .AsReadOnly(),
                            Score = x.Scoreboard.Radiant.Score,
                            TowerState = x.Scoreboard.Radiant.TowerState
                        },
                        Duration = x.Scoreboard.Duration,
                        RoshanRespawnTimer = x.Scoreboard.RoshanRespawnTimer
                    },
                    SeriesId = x.SeriesId,
                    SeriesType = x.SeriesType,
                    StageName = x.StageName
                }).ToList().AsReadOnly();
            });
        }

        /// <summary>
        /// Returns the match details and meta data for a specific match that has already been completed.
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<MatchDetailModel>> GetMatchDetailsAsync(ulong matchId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(matchId, "match_id");

            var steamWebResponse = await steamWebInterface.GetAsync<MatchDetailResultContainer>("GetMatchDetails", 1, parameters);

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new MatchDetailModel
                {
                    Players = result.Players?.Select(p => new MatchPlayerModel
                    {
                        AccountId = p.AccountId,
                        PlayerSlot = p.PlayerSlot,
                        HeroId = p.HeroId,
                        Item0 = p.Item0,
                        Item1 = p.Item1,
                        Item2 = p.Item2,
                        Item3 = p.Item3,
                        Item4 = p.Item4,
                        Item5 = p.Item5,
                        Backpack0 = p.Backpack0,
                        Backpack1 = p.Backpack1,
                        Backpack2 = p.Backpack2,
                        ItemNeutral = p.ItemNeutral,
                        Kills = p.Kills,
                        Deaths = p.Deaths,
                        Assists = p.Assists,
                        LeaverStatus = p.LeaverStatus,
                        Gold = p.Gold,
                        LastHits = p.LastHits,
                        Denies = p.Denies,
                        GoldPerMinute = p.GoldPerMinute,
                        ExperiencePerMinute = p.ExperiencePerMinute,
                        GoldSpent = p.GoldSpent,
                        NetWorth = p.NetWorth,
                        AghanimsScepter = p.AghanimsScepter,
                        AghanimsShard = p.AghanimsShard,
                        Moonshard = p.Moonshard,
                        HeroDamage = p.HeroDamage,
                        TowerDamage = p.TowerDamage,
                        HeroHealing = p.HeroHealing,
                        ScaledHeroDamage = p.ScaledHeroDamage,
                        ScaledTowerDamage = p.ScaledTowerDamage,
                        ScaledHeroHealing = p.ScaledHeroHealing,
                        Level = p.Level,
                        AbilityUpgrades = p.AbilityUpgrades?.Select(a => new MatchPlayerAbilityUpgradeModel
                        {
                            Ability = a.Ability,
                            Time = a.Time,
                            Level = a.Level
                        }).ToList().AsReadOnly(),
                        AdditionalUnits = p.AdditionalUnits?.Select(u => new MatchPlayerAdditionalUnitModel
                        {
                            Unitname = u.Unitname,
                            Item0 = u.Item0,
                            Item1 = u.Item1,
                            Item2 = u.Item2,
                            Item3 = u.Item3,
                            Item4 = u.Item4,
                            Item5 = u.Item5,
                            Backpack0 = u.Backpack0,
                            Backpack1 = u.Backpack1,
                            Backpack2 = u.Backpack2,
                            ItemNeutral = u.ItemNeutral
                        }).ToList().AsReadOnly()
                    }).ToList().AsReadOnly(),
                    RadiantWin = result.RadiantWin,
                    PreGameDuration = result.PreGameDuration,
                    Duration = result.Duration,
                    StartTime = result.StartTime.ToDateTime(),
                    MatchId = result.MatchId,
                    MatchSequenceNumber = result.MatchSequenceNumber,
                    TowerStatusRadiant = result.TowerStatusRadiant,
                    TowerStatusDire = result.TowerStatusDire,
                    BarracksStatusRadiant = result.BarracksStatusRadiant,
                    BarracksStatusDire = result.BarracksStatusDire,
                    Cluster = result.Cluster,
                    FirstBloodTime = result.FirstBloodTime,
                    LobbyType = result.LobbyType,
                    HumanPlayers = result.HumanPlayers,
                    LeagueId = result.LeagueId,
                    PositiveVotes = result.PositiveVotes,
                    NegativeVotes = result.NegativeVotes,
                    GameMode = result.GameMode,
                    Engine = result.Engine,
                    RadiantTeamId = result.RadiantTeamId,
                    RadiantName = result.RadiantName,
                    RadiantLogo = result.RadiantLogo,
                    RadiantTeamComplete = result.RadiantTeamComplete,
                    DireTeamId = result.DireTeamId,
                    DireName = result.DireName,
                    DireLogo = result.DireLogo,
                    DireTeamComplete = result.DireTeamComplete,
                    RadiantCaptain = result.RadiantCaptain,
                    DireCaptain = result.DireCaptain,
                    RadiantScore = result.RadiantScore,
                    DireScore = result.DireScore,
                    PicksAndBans = result.PicksAndBans?.Select(pb => new MatchPickBanModel
                    {
                        IsPick = pb.IsPick,
                        HeroId = pb.HeroId,
                        Team = pb.Team,
                        Order = pb.Order
                    }).ToList().AsReadOnly()
                };
            });
        }

        /// <summary>
        /// Returns a collection of match details in history based on specific parameters.
        /// </summary>
        /// <param name="heroId"></param>
        /// <param name="gameMode"></param>
        /// <param name="skill"></param>
        /// <param name="minPlayers"></param>
        /// <param name="accountId"></param>
        /// <param name="leagueId"></param>
        /// <param name="startAtMatchId"></param>
        /// <param name="matchesRequested"></param>
        /// <param name="tournamentGamesOnly"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<MatchHistoryModel>> GetMatchHistoryAsync(uint? heroId = null, uint? gameMode = null, uint? skill = null,
            uint? minPlayers = null, ulong? accountId = null, uint? leagueId = null, ulong? startAtMatchId = null,
            string matchesRequested = "", string tournamentGamesOnly = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(heroId, "hero_id");
            parameters.AddIfHasValue(gameMode, "game_mode");
            parameters.AddIfHasValue(skill, "skill");
            parameters.AddIfHasValue(minPlayers, "min_players");
            parameters.AddIfHasValue(accountId, "account_id");
            parameters.AddIfHasValue(leagueId, "league_id");
            parameters.AddIfHasValue(startAtMatchId, "start_at_match_id");
            parameters.AddIfHasValue(matchesRequested, "matches_requested");
            parameters.AddIfHasValue(tournamentGamesOnly, "tournament_games_only");

            var steamWebResponse = await steamWebInterface.GetAsync<MatchHistoryResultContainer>("GetMatchHistory", 1, parameters);

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new MatchHistoryModel
                {
                    Matches = result.Matches?.Select(m => new MatchHistoryMatchModel
                    {
                        DireTeamId = m.DireTeamId,
                        LobbyType = m.LobbyType,
                        MatchId = m.MatchId,
                        MatchSequenceNumber = m.MatchSequenceNumber,
                        Players = m.Players?.Select(p => new MatchHistoryPlayerModel
                        {
                            AccountId = p.AccountId,
                            PlayerSlot = p.PlayerSlot,
                            HeroId = p.HeroId,
                        }).ToList().AsReadOnly(),
                        RadiantTeamId = m.RadiantTeamId,
                        StartTime = m.StartTime
                    }).ToList().AsReadOnly(),
                    NumResults = result.NumResults,
                    ResultsRemaining = result.ResultsRemaining,
                    Status = result.Status,
                    TotalResults = result.TotalResults
                };
            });
        }

        /// <summary>
        /// Returns a collection of match details based on a sequence number. This allows you to jump forward and backward through the match history dataset.
        /// </summary>
        /// <param name="startAtMatchSequenceNumber"></param>
        /// <param name="matchesRequested"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<MatchHistoryMatchModel>>> GetMatchHistoryBySequenceNumberAsync(ulong? startAtMatchSequenceNumber = null, uint? matchesRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(startAtMatchSequenceNumber, "start_at_match_seq_num");
            parameters.AddIfHasValue(matchesRequested, "matches_requested");

            var steamWebResponse = await steamWebInterface.GetAsync<MatchHistoryBySequenceNumberResultContainer>("GetMatchHistoryBySequenceNum", 1, parameters);

            return steamWebResponse.MapTo<IReadOnlyCollection<MatchHistoryMatchModel>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.Matches?.Select(m => new MatchHistoryMatchModel
                {
                    DireTeamId = m.DireTeamId,
                    LobbyType = m.LobbyType,
                    MatchId = m.MatchId,
                    MatchSequenceNumber = m.MatchSequenceNumber,
                    Players = m.Players?.Select(p => new MatchHistoryPlayerModel
                    {
                        AccountId = p.AccountId,
                        PlayerSlot = p.PlayerSlot,
                        HeroId = p.HeroId
                    }).ToList().AsReadOnly(),
                    RadiantTeamId = m.RadiantTeamId,
                    StartTime = m.StartTime
                }).ToList().AsReadOnly();
            });
        }

        /// <summary>
        /// Returns a collection of team info meta data objects based on parameters that define which teams to look up.
        /// </summary>
        /// <param name="startAtTeamId"></param>
        /// <param name="teamsRequested"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<Steam.Models.DOTA2.TeamInfo>>> GetTeamInfoByTeamIdAsync(long? startAtTeamId = null, uint? teamsRequested = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(startAtTeamId, "start_at_team_id");
            parameters.AddIfHasValue(teamsRequested, "teams_requested");

            var steamWebResponse = await steamWebInterface.GetAsync<TeamInfoResultContainer>("GetTeamInfoByTeamID", 1, parameters);

            return steamWebResponse.MapTo<IReadOnlyCollection<Steam.Models.DOTA2.TeamInfo>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.Teams?.Select(t => new Steam.Models.DOTA2.TeamInfo
                {
                    TeamId = t.TeamId,
                    Name = t.Name,
                    Tag = t.Tag,
                    TimeCreated = t.TimeCreated,
                    Rating = t.Rating,
                    CountryCode = t.CountryCode,
                    AdminAccountId = t.AdminAccountId,
                    Logo = t.Logo,
                    LogoSponsor = t.LogoSponsor,
                    Url = t.Url,
                    GamesPlayedWithCurrentRoster = t.GamesPlayedWithCurrentRoster,
                    PlayerIds = t.PlayerIds?.ToList().AsReadOnly(),
                    LeagueIds = t.LeagueIds?.ToList().AsReadOnly()
                }).ToList().AsReadOnly();
            });
        }

        private LiveLeagueGamePlayerDetailModel MapToLiveLeagueGamePlayerDetail(LiveLeagueGamePlayerDetail p)
        {
            return new LiveLeagueGamePlayerDetailModel
            {
                AccountId = p.AccountId,
                Assists = p.Assists,
                Deaths = p.Deaths,
                Denies = p.Denies,
                Gold = p.Gold,
                HeroId = p.HeroId,
                ExperiencePerMinute = p.ExperiencePerMinute,
                GoldPerMinute = p.GoldPerMinute,
                Item0 = p.Item0,
                Item1 = p.Item1,
                Item2 = p.Item2,
                Item3 = p.Item3,
                Item4 = p.Item4,
                Item5 = p.Item5,
                Kills = p.Kills,
                LastHits = p.LastHits,
                Level = p.Level,
                NetWorth = p.NetWorth,
                PlayerSlot = p.PlayerSlot,
                PositionX = p.PositionX,
                PositionY = p.PositionY,
                RespawnTimer = p.RespawnTimer,
                UltimateCooldown = p.UltimateCooldown,
                UltimateState = p.UltimateState
            };
        }
    }
}