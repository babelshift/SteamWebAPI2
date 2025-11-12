
using Steam.Models;
using Steam.Models.SteamCommunity;
using Steam.Models.SteamPlayer;
using SteamWebAPI2.Models;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SteamWebAPI2.Interfaces
{
    public class SteamUserStats : ISteamUserStats
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public SteamUserStats(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ISteamUserStats", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a collection of global achievement progress for a specific Steam App.
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<GlobalAchievementPercentageModel>>> GetGlobalAchievementPercentagesForAppAsync(uint appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "gameid");

            var steamWebResponse = await steamWebInterface.GetAsync<GlobalAchievementPercentagesResultContainer>("GetGlobalAchievementPercentagesForApp", 2, parameters);

            return steamWebResponse.MapTo<IReadOnlyCollection<GlobalAchievementPercentageModel>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.AchievementPercentages?.Select(ap => new GlobalAchievementPercentageModel
                {
                    Name = ap.Name,
                    Percent = ap.Percent
                }).ToList().AsReadOnly();
            });
        }

        /// <summary>
        /// Returns a collection of global statistics for a specific Steam App.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="statNames"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<GlobalStatModel>>> GetGlobalStatsForGameAsync(uint appId, IReadOnlyList<string> statNames, DateTime? startDate = null, DateTime? endDate = null)
        {
            ulong? startDateUnixTimeStamp = null;
            ulong? endDateUnixTimeStamp = null;

            if (startDate.HasValue)
            {
                startDateUnixTimeStamp = startDate.Value.ToUnixTimeStamp();
            }

            if (endDate.HasValue)
            {
                endDateUnixTimeStamp = endDate.Value.ToUnixTimeStamp();
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(statNames.Count, "count");
            parameters.AddIfHasValue(startDateUnixTimeStamp, "startdate");
            parameters.AddIfHasValue(endDateUnixTimeStamp, "enddate");

            for (int i = 0; i < statNames.Count; i++)
            {
                parameters.AddIfHasValue(statNames[i], string.Format("name[{0}]", i));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<GlobalStatsForGameResultContainer>("GetGlobalStatsForGame", 1, parameters);

            return steamWebResponse.MapTo<IReadOnlyCollection<GlobalStatModel>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.GlobalStats?.Select(ap => new GlobalStatModel
                {
                    Name = ap.Name,
                    Total = ap.Total
                }).ToList().AsReadOnly();
            });
        }

        /// <summary>
        /// Returns the number of current players on Steam for a specific Steam App.
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<uint>> GetNumberOfCurrentPlayersForGameAsync(uint appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");

            var steamWebResponse = await steamWebInterface.GetAsync<CurrentPlayersResultContainer>("GetNumberOfCurrentPlayers", 1, parameters);

            return steamWebResponse.MapTo((from) =>
            {
                return from?.Result.PlayerCount ?? 0;
            });
        }

        /// <summary>
        /// Returns a specific Steam User's achievements for a specific Steam App.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="steamId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<PlayerAchievementResultModel>> GetPlayerAchievementsAsync(uint appId, ulong steamId, string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(language, "l");

            var steamWebResponse = await steamWebInterface.GetAsync<PlayerAchievementResultContainer>("GetPlayerAchievements", 1, parameters);

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new PlayerAchievementResultModel
                {
                    Success = result.Success,
                    SteamId = result.SteamId,
                    GameName = result.GameName,
                    Achievements = result.Achievements?.Select(a => new PlayerAchievementModel
                    {
                        Achieved = a.Achieved,
                        UnlockTime = a.UnlockTime.ToDateTime(),
                        Name = a.Name,
                        Description = a.Description,
                        APIName = a.APIName
                    }).ToList().AsReadOnly()
                };
            });
        }

        /// <summary>
        /// Returns game version, achievements, and stats overviews for a specific Steam App.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SchemaForGameResultModel>> GetSchemaForGameAsync(uint appId, string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(language, "l");

            var steamWebResponse = await steamWebInterface.GetAsync<SchemaForGameResultContainer>("GetSchemaForGame", 2, parameters);

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new SchemaForGameResultModel
                {
                    GameName = result.GameName,
                    GameVersion = result.GameVersion,
                    AvailableGameStats = result.AvailableGameStats == null ? null : new AvailableGameStatsModel
                    {
                        Achievements = result.AvailableGameStats.Achievements?.Select(a => new SchemaGameAchievementModel
                        {
                            Name = a.Name,
                            DefaultValue = a.DefaultValue,
                            DisplayName = a.DisplayName,
                            Hidden = a.Hidden,
                            Description = a.Description,
                            Icon = a.Icon,
                            Icongray = a.Icongray
                        }).ToList().AsReadOnly(),
                        Stats = result.AvailableGameStats.Stats?.Select(s => new SchemaGameStatModel
                        {
                            Name = s.Name,
                            DefaultValue = s.DefaultValue,
                            DisplayName = s.DisplayName
                        }).ToList().AsReadOnly()
                    }
                };
            });
        }

        /// <summary>
        /// Returns a specific Steam User's achievement and stats for a specific Steam App.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<UserStatsForGameResultModel>> GetUserStatsForGameAsync(ulong steamId, uint appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(appId, "appid");

            var steamWebResponse = await steamWebInterface.GetAsync<UserStatsForGameResultContainer>("GetUserStatsForGame", 2, parameters);

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new UserStatsForGameResultModel
                {
                    GameName = result.GameName,
                    SteamId = ulong.Parse(result.SteamId),
                    Achievements = result.Achievements?.Select(a => new UserStatAchievementModel
                    {
                        Name = a.Name,
                        Achieved = a.Achieved,
                    }).ToList().AsReadOnly(),
                    Stats = result.Stats?.Select(s => new UserStatModel
                    {
                        Name = s.Name,
                        Value = s.Value
                    }).ToList().AsReadOnly()
                };
            });
        }
    }
}