using System.Threading.Tasks;
using SteamWebAPI2.Models;
using Steam.Models;

namespace SteamWebAPI2.Interfaces
{
    public interface IGCVersion
    {
        Task<GameClientResultModel> GetClientVersionAsync();
        Task<GameClientResultModel> GetServerVersionAsync();
    }
}