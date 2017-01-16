using Steam.Models;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamRemoteStorage
    {
        Task<UGCFileDetailsModel> GetUGCFileDetailsAsync(long ugcId, int appId, long? steamId = default(long?));
    }
}