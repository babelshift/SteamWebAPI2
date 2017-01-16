using Steam.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamApps
    {
        Task<IReadOnlyCollection<SteamAppModel>> GetAppListAsync();

        Task<SteamAppUpToDateCheckModel> UpToDateCheckAsync(int appId, int version);
    }
}