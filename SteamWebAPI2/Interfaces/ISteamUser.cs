using Steam.Models.SteamCommunity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamUser
    {
        Task<IReadOnlyCollection<FriendModel>> GetFriendsListAsync(ulong steamId, string relationship = "");

        Task<IReadOnlyCollection<PlayerBansModel>> GetPlayerBansAsync(ulong steamId);

        Task<IReadOnlyCollection<PlayerBansModel>> GetPlayerBansAsync(IReadOnlyCollection<ulong> steamIds);

        Task<PlayerSummaryModel> GetPlayerSummaryAsync(ulong steamId);

        Task<List<PlayerSummaryModel>> GetPlayerSummariesAsync(List<ulong> steamIds);

        Task<IReadOnlyCollection<ulong>> GetUserGroupsAsync(ulong steamId);

        Task<ulong> ResolveVanityUrlAsync(string vanityUrl, int? urlType = default(int?));

        Task<SteamCommunityProfileModel> GetCommunityProfileAsync(ulong steamId);
    }
}