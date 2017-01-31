using Steam.Models;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IGCVersion
    {
        Task<GameClientResultModel> GetClientVersionAsync();

        Task<GameClientResultModel> GetServerVersionAsync();
    }
}