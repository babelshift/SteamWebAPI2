using System.Threading.Tasks;
using SteamWebAPI2.Models;
using Steam.Models;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamRemoteStorage
    {
        Task<UGCFileDetailsModel> GetUGCFileDetailsAsync(long ugcId, int appId, long? steamId = default(long?));
    }
}