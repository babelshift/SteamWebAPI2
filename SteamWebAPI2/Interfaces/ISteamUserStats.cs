using Steam.Models;
using Steam.Models.SteamCommunity;
using Steam.Models.SteamPlayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamUserStats
    {
        Task<IReadOnlyCollection<GlobalAchievementPercentageModel>> GetGlobalAchievementPercentagesForAppAsync(int appId);

        Task<IReadOnlyCollection<GlobalStatModel>> GetGlobalStatsForGameAsync(int appId, IReadOnlyList<string> statNames, DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?));

        Task<uint> GetNumberOfCurrentPlayersForGameAsync(int appId);

        Task<PlayerAchievementResultModel> GetPlayerAchievementsAsync(int appId, long steamId, string language = "");

        Task<SchemaForGameResultModel> GetSchemaForGameAsync(int appId, string language = "");

        Task<UserStatsForGameResultModel> GetUserStatsForGameAsync(long steamId, int appId);
    }
}