using Steam.Models;
using Steam.Models.SteamCommunity;
using Steam.Models.SteamPlayer;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamUserStats
    {
        Task<ISteamWebResponse<IReadOnlyCollection<GlobalAchievementPercentageModel>>> GetGlobalAchievementPercentagesForAppAsync(uint appId);

        Task<ISteamWebResponse<IReadOnlyCollection<GlobalStatModel>>> GetGlobalStatsForGameAsync(uint appId, IReadOnlyList<string> statNames, DateTime? startDate = null, DateTime? endDate = null);

        Task<ISteamWebResponse<uint>> GetNumberOfCurrentPlayersForGameAsync(uint appId);

        Task<ISteamWebResponse<PlayerAchievementResultModel>> GetPlayerAchievementsAsync(uint appId, ulong steamId, string language = "");

        Task<ISteamWebResponse<SchemaForGameResultModel>> GetSchemaForGameAsync(uint appId, string language = "");

        Task<ISteamWebResponse<UserStatsForGameResultModel>> GetUserStatsForGameAsync(ulong steamId, uint appId);
    }
}