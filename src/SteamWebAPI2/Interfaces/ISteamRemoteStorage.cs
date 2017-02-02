using Steam.Models;
using SteamWebAPI2.Utilities;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamRemoteStorage
    {
        Task<ISteamWebResponse<UGCFileDetailsModel>> GetUGCFileDetailsAsync(ulong ugcId, uint appId, ulong? steamId = null);
    }
}