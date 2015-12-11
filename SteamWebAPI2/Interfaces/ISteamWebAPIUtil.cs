using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamWebAPIUtil
    {
        Task<SteamServerInfo> GetServerInfoAsync();
        Task<IReadOnlyCollection<SteamInterface>> GetSupportedAPIListAsync();
    }
}