using Steam.Models;
using SteamWebAPI2.Utilities;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IGCVersion
    {
        Task<ISteamWebResponse<GameClientResultModel>> GetClientVersionAsync();

        Task<ISteamWebResponse<GameClientResultModel>> GetServerVersionAsync();
    }
}