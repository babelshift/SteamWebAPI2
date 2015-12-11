using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamUserStats
    {
        Task<IReadOnlyCollection<GlobalAchievementPercentage>> GetGlobalAchievementPercentagesForAppAsync(int appId);
        Task<GlobalStatsForGameResult> GetGlobalStatsForGameAsync(int appId, IReadOnlyList<string> statNames, DateTime? startDate = default(DateTime?), DateTime? endDate = default(DateTime?));
        Task<int> GetNumberOfCurrentPlayersForGameAsync(int appId);
        Task<PlayerAchievementResult> GetPlayerAchievementsAsync(int appId, long steamId, string language = "");
        Task<SchemaForGameResult> GetSchemaForGameAsync(int appId, string language = "");
        Task<UserStatsForGameResult> GetUserStatsForGameAsync(long steamId, int appId);
    }
}