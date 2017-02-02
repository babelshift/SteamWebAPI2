using Steam.Models.SteamCommunity;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IPlayerService
    {
        Task<ISteamWebResponse<BadgesResultModel>> GetBadgesAsync(ulong steamId);

        Task<ISteamWebResponse<IReadOnlyCollection<BadgeQuestModel>>> GetCommunityBadgeProgressAsync(ulong steamId, uint? badgeId = null);

        Task<ISteamWebResponse<OwnedGamesResultModel>> GetOwnedGamesAsync(ulong steamId, bool? includeAppInfo = null, bool? includeFreeGames = null, IReadOnlyCollection<uint> appIdsToFilter = null);

        Task<ISteamWebResponse<RecentlyPlayedGamesResultModel>> GetRecentlyPlayedGamesAsync(ulong steamId);

        Task<ISteamWebResponse<uint?>> GetSteamLevelAsync(ulong steamId);

        Task<ISteamWebResponse<ulong?>> IsPlayingSharedGameAsync(ulong steamId, uint appId);
    }
}