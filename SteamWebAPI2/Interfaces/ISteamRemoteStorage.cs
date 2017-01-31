using Steam.Models;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamRemoteStorage
    {
        Task<UGCFileDetailsModel> GetUGCFileDetailsAsync(ulong ugcId, uint appId, ulong? steamId = null);
    }
}