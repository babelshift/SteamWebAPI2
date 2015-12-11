using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;

namespace SteamWebAPI2.Interfaces
{
    public interface IPlayerService
    {
        Task<BadgesResult> GetBadgesAsync(long steamId);
        Task<IReadOnlyCollection<BadgeQuest>> GetCommunityBadgeProgressAsync(long steamId, int? badgeId = default(int?));
        Task<OwnedGamesResult> GetOwnedGamesAsync(long steamId, bool? includeAppInfo = default(bool?), bool? includeFreeGames = default(bool?), IReadOnlyCollection<int> appIdsToFilter = null);
        Task<RecentlyPlayedGameResult> GetRecentlyPlayedGamesAsync(long steamId);
        Task<int> GetSteamLevelAsync(long steamId);
        Task<PlayingSharedGameResult> IsPlayingSharedGameAsync(long steamId, int appId);
    }
}