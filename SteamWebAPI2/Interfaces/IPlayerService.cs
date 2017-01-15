using Steam.Models.SteamCommunity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IPlayerService
    {
        Task<BadgesResultModel> GetBadgesAsync(ulong steamId);

        Task<IReadOnlyCollection<BadgeQuestModel>> GetCommunityBadgeProgressAsync(ulong steamId, uint? badgeId = default(uint?));

        Task<OwnedGamesResultModel> GetOwnedGamesAsync(ulong steamId, bool? includeAppInfo = default(bool?), bool? includeFreeGames = default(bool?), IReadOnlyCollection<uint> appIdsToFilter = null);

        Task<RecentlyPlayedGamesResultModel> GetRecentlyPlayedGamesAsync(ulong steamId);

        Task<int> GetSteamLevelAsync(ulong steamId);

        Task<string> IsPlayingSharedGameAsync(ulong steamId, uint appId);
    }
}