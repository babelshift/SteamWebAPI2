using Steam.Models;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamWebAPIUtil
    {
        Task<ISteamWebResponse<SteamServerInfoModel>> GetServerInfoAsync();

        Task<ISteamWebResponse<IReadOnlyCollection<SteamInterfaceModel>>> GetSupportedAPIListAsync();
    }
}