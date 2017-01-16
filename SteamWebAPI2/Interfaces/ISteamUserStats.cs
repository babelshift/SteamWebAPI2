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
        Task<IReadOnlyCollection<GlobalAchievementPercentageModel>> GetGlobalAchievementPercentagesForAppAsync(uint appId);

        Task<IReadOnlyCollection<GlobalStatModel>> GetGlobalStatsForGameAsync(uint appId, IReadOnlyList<string> statNames, DateTime? startDate = null, DateTime? endDate = null);

        Task<uint> GetNumberOfCurrentPlayersForGameAsync(uint appId);

        Task<PlayerAchievementResultModel> GetPlayerAchievementsAsync(uint appId, ulong steamId, string language = "");

        Task<SchemaForGameResultModel> GetSchemaForGameAsync(uint appId, string language = "");

        Task<UserStatsForGameResultModel> GetUserStatsForGameAsync(ulong steamId, uint appId);
    }
}