using Steam.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamWebAPIUtil
    {
        Task<SteamServerInfoModel> GetServerInfoAsync();

        Task<IReadOnlyCollection<SteamInterfaceModel>> GetSupportedAPIListAsync();
    }
}