using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamApps
    {
        Task<IReadOnlyCollection<SteamApp>> GetAppListAsync();
        Task<SteamAppUpToDateCheckResult> UpToDateCheckAsync(int appId, int version);
    }
}