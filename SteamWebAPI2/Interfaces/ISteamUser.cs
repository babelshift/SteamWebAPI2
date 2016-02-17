using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models.SteamCommunity;
using SteamWebAPI2.Models.SteamPlayer;
using Steam.Models.SteamCommunity;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamUser
    {
        Task<IReadOnlyCollection<FriendModel>> GetFriendsListAsync(long steamId, string relationship = "");
        Task<IReadOnlyCollection<PlayerBansModel>> GetPlayerBansAsync(long steamId);
        Task<IReadOnlyCollection<PlayerBansModel>> GetPlayerBansAsync(IReadOnlyCollection<long> steamIds);
        Task<PlayerSummaryModel> GetPlayerSummaryAsync(long steamId);
        Task<IReadOnlyCollection<long>> GetUserGroupsAsync(long steamId);
        Task<ulong> ResolveVanityUrlAsync(string vanityUrl, int? urlType = default(int?));
    }
}