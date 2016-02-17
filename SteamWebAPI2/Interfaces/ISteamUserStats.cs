using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;
using Steam.Models.SteamCommunity;
using Steam.Models.SteamPlayer;
using Steam.Models;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamUserStats
    {
        Task<IReadOnlyCollection<GlobalAchievementPercentageModel>> GetGlobalAchievementPercentagesForAppAsync(int appId);
        Task<IReadOnlyCollection<GlobalStatModel>> GetGlobalStatsForGameAsync(int appId, IReadOnlyList<string> statNames, DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?));
        Task<int> GetNumberOfCurrentPlayersForGameAsync(int appId);
        Task<PlayerAchievementResultModel> GetPlayerAchievementsAsync(int appId, long steamId, string language = "");
        Task<SchemaForGameResultModel> GetSchemaForGameAsync(int appId, string language = "");
        Task<UserStatsForGameResultModel> GetUserStatsForGameAsync(long steamId, int appId);
    }
}