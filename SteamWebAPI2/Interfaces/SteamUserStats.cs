using SteamWebAPI2.Models;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamUserStats : SteamWebInterface
    {
        public SteamUserStats(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamUserStats")
        { }

        public async Task<IReadOnlyCollection<GlobalAchievementPercentage>> GetGlobalAchievementPercentagesForAppAsync(int appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("gameid", appId, parameters);
            var achievementPercentagesResult = await CallMethodAsync<GlobalAchievementPercentagesResultContainer>("GetGlobalAchievementPercentagesForApp", 2, parameters);
            return new ReadOnlyCollection<GlobalAchievementPercentage>(achievementPercentagesResult.Result.AchievementPercentages);
        }

        public async Task<GlobalStatsForGameResult> GetGlobalStatsForGameAsync(int appId, IReadOnlyList<string> statNames, DateTime? startDate = null, DateTime? endDate = null)
        {
            long? startDateUnixTimeStamp = null;
            long? endDateUnixTimeStamp = null;

            if (startDate.HasValue)
            {
                startDateUnixTimeStamp = startDate.Value.ToUnixTimeStamp();
            }

            if (endDate.HasValue)
            {
                endDateUnixTimeStamp = endDate.Value.ToUnixTimeStamp();
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("appid", appId, parameters);
            AddToParametersIfHasValue("count", statNames.Count, parameters);
            AddToParametersIfHasValue("startdate", startDateUnixTimeStamp, parameters);
            AddToParametersIfHasValue("enddate", endDateUnixTimeStamp, parameters);

            for (int i = 0; i < statNames.Count; i++)
            {
                AddToParametersIfHasValue(String.Format("name[{0}]", i), statNames[i], parameters);
            }

            var globalStatsResult = await CallMethodAsync<GlobalStatsForGameResultContainer>("GetGlobalStatsForGame", 1, parameters);
            return globalStatsResult.Result;
        }

        public async Task<int> GetNumberOfCurrentPlayersForGameAsync(int appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("appid", appId, parameters);
            var globalStatsResult = await CallMethodAsync<CurrentPlayersResultContainer>("GetNumberOfCurrentPlayers", 1, parameters);
            return globalStatsResult.Result.PlayerCount;
        }

        public async Task<PlayerAchievementResult> GetPlayerAchievementsAsync(int appId, long steamId, string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("appid", appId, parameters);
            AddToParametersIfHasValue("steamid", steamId, parameters);
            AddToParametersIfHasValue("l", language, parameters);
            var playerStatsResult = await CallMethodAsync<PlayerAchievementResultContainer>("GetPlayerAchievements", 1, parameters);
            return playerStatsResult.Result;
        }

        public async Task<SchemaForGameResult> GetSchemaForGameAsync(int appId, string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("appid", appId, parameters);
            AddToParametersIfHasValue("l", language, parameters);
            var schemaForGameResult = await CallMethodAsync<SchemaForGameResultContainer>("GetSchemaForGame", 2, parameters);
            return schemaForGameResult.Result;
        }

        public async Task<UserStatsForGameResult> GetUserStatsForGameAsync(long steamId, int appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            AddToParametersIfHasValue("steamid", steamId, parameters);
            AddToParametersIfHasValue("appid", appId, parameters);
            var userStatsForGameResult = await CallMethodAsync<UserStatsForGameResultContainer>("GetUserStatsForGame", 2, parameters);
            return userStatsForGameResult.Result;
        }
    }
}