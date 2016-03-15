using Steam.Models;
using Steam.Models.SteamCommunity;
using Steam.Models.SteamPlayer;
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
    public class SteamUserStats : SteamWebInterface, ISteamUserStats
    {
        public SteamUserStats(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamUserStats")
        { }

        public async Task<IReadOnlyCollection<GlobalAchievementPercentageModel>> GetGlobalAchievementPercentagesForAppAsync(int appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "gameid");
            var achievementPercentagesResult = await CallMethodAsync<GlobalAchievementPercentagesResultContainer>("GetGlobalAchievementPercentagesForApp", 2);

            var achievementPercentagesResultModel = AutoMapperConfiguration.Mapper.Map<IList<GlobalAchievementPercentage>, IList<GlobalAchievementPercentageModel>>(achievementPercentagesResult.Result.AchievementPercentages);

            return new ReadOnlyCollection<GlobalAchievementPercentageModel>(achievementPercentagesResultModel);
        }

        public async Task<IReadOnlyCollection<GlobalStatModel>> GetGlobalStatsForGameAsync(int appId, IReadOnlyList<string> statNames, DateTime? startDate = null, DateTime? endDate = null)
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
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(statNames.Count, "count");
            parameters.AddIfHasValue(startDateUnixTimeStamp, "startdate");
            parameters.AddIfHasValue(endDateUnixTimeStamp, "enddate");

            for (int i = 0; i < statNames.Count; i++)
            {
                parameters.AddIfHasValue(statNames[i], String.Format("name[{0}]", i));
            }

            var globalStatsResult = await CallMethodAsync<GlobalStatsForGameResultContainer>("GetGlobalStatsForGame", 1);
            
            var globalStatsModel = AutoMapperConfiguration.Mapper.Map<IList<GlobalStat>, IList<GlobalStatModel>>(globalStatsResult.Result.GlobalStats);

            return new ReadOnlyCollection<GlobalStatModel>(globalStatsModel);
        }

        public async Task<int> GetNumberOfCurrentPlayersForGameAsync(int appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            var globalStatsResult = await CallMethodAsync<CurrentPlayersResultContainer>("GetNumberOfCurrentPlayers", 1, parameters);
            parameters.AddIfHasValue(appId, "appid");
            return globalStatsResult.Result.PlayerCount;
        }

        public async Task<PlayerAchievementResultModel> GetPlayerAchievementsAsync(int appId, long steamId, string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(language, "l");

            var playerStatsResult = await CallMethodAsync<PlayerAchievementResultContainer>("GetPlayerAchievements", 1, parameters);

            var playerStatsResultModel = AutoMapperConfiguration.Mapper.Map<PlayerAchievementResult, PlayerAchievementResultModel>(playerStatsResult.Result);

            return playerStatsResultModel;
        }

        public async Task<SchemaForGameResultModel> GetSchemaForGameAsync(int appId, string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(language, "l");

            var schemaForGameResult = await CallMethodAsync<SchemaForGameResultContainer>("GetSchemaForGame", 2, parameters);

            var schemaForGameResultModel = AutoMapperConfiguration.Mapper.Map<SchemaForGameResult, SchemaForGameResultModel>(schemaForGameResult.Result);

            return schemaForGameResultModel;
        }

        public async Task<UserStatsForGameResultModel> GetUserStatsForGameAsync(long steamId, int appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(appId, "appid");

            var userStatsForGameResult = await CallMethodAsync<UserStatsForGameResultContainer>("GetUserStatsForGame", 2, parameters);

            var userStatsForGameResultModel = AutoMapperConfiguration.Mapper.Map<UserStatsForGameResult, UserStatsForGameResultModel>(userStatsForGameResult.Result);

            return userStatsForGameResultModel;
        }
    }
}