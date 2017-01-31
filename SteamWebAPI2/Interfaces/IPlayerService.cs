using Steam.Models.SteamCommunity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IPlayerService
    {
        Task<BadgesResultModel> GetBadgesAsync(ulong steamId);

        Task<IReadOnlyCollection<BadgeQuestModel>> GetCommunityBadgeProgressAsync(ulong steamId, uint? badgeId = null);

        Task<OwnedGamesResultModel> GetOwnedGamesAsync(ulong steamId, bool? includeAppInfo = null, bool? includeFreeGames = null, IReadOnlyCollection<uint> appIdsToFilter = null);

        Task<RecentlyPlayedGamesResultModel> GetRecentlyPlayedGamesAsync(ulong steamId);

        Task<uint?> GetSteamLevelAsync(ulong steamId);

        Task<ulong?> IsPlayingSharedGameAsync(ulong steamId, uint appId);
    }
}