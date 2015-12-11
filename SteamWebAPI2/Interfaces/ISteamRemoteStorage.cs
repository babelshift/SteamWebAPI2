using System.Threading.Tasks;
using SteamWebAPI2.Models;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamRemoteStorage
    {
        Task<UGCFileDetails> GetUGCFileDetailsAsync(long ugcId, int appId, long? steamId = default(long?));
    }
}