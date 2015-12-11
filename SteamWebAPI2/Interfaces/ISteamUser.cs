using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamUser
    {
        Task<IReadOnlyCollection<Friend>> GetFriendsListAsync(long steamId, string relationship = "");
        Task<IReadOnlyCollection<PlayerBans>> GetPlayerBansAsync(long steamId);
        Task<IReadOnlyCollection<PlayerBans>> GetPlayerBansAsync(IReadOnlyCollection<long> steamIds);
        Task<PlayerSummary> GetPlayerSummaryAsync(long steamId);
        Task<UserGroupListResult> GetUserGroupsAsync(long steamId);
        Task<ResolveVanityUrlResult> ResolveVanityUrlAsync(string vanityUrl, int? urlType = default(int?));
    }
}