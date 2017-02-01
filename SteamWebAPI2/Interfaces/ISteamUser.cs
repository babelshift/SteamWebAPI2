using Steam.Models.SteamCommunity;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamUser
    {
        Task<ISteamWebResponse<IReadOnlyCollection<FriendModel>>> GetFriendsListAsync(ulong steamId, string relationship = "");

        Task<ISteamWebResponse<IReadOnlyCollection<PlayerBansModel>>> GetPlayerBansAsync(ulong steamId);

        Task<ISteamWebResponse<IReadOnlyCollection<PlayerBansModel>>> GetPlayerBansAsync(IReadOnlyCollection<ulong> steamIds);

        Task<ISteamWebResponse<PlayerSummaryModel>> GetPlayerSummaryAsync(ulong steamId);

        Task<ISteamWebResponse<IReadOnlyCollection<PlayerSummaryModel>>> GetPlayerSummariesAsync(IReadOnlyCollection<ulong> steamIds);

        Task<ISteamWebResponse<IReadOnlyCollection<ulong>>> GetUserGroupsAsync(ulong steamId);

        Task<ISteamWebResponse<ulong>> ResolveVanityUrlAsync(string vanityUrl, int? urlType = null);

        Task<SteamCommunityProfileModel> GetCommunityProfileAsync(ulong steamId);
    }
}