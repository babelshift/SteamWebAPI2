using Steam.Models;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamApps
    {
        Task<ISteamWebResponse<IReadOnlyCollection<SteamAppModel>>> GetAppListAsync();

        Task<ISteamWebResponse<SteamAppUpToDateCheckModel>> UpToDateCheckAsync(uint appId, uint version);
    }
}