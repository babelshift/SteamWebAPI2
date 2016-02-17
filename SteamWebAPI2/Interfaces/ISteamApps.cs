using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models;
using Steam.Models;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamApps
    {
        Task<IReadOnlyCollection<SteamAppModel>> GetAppListAsync();
        Task<SteamAppUpToDateCheckModel> UpToDateCheckAsync(int appId, int version);
    }
}