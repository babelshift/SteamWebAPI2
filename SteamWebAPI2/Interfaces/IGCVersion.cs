using System.Threading.Tasks;
using SteamWebAPI2.Models;

namespace SteamWebAPI2.Interfaces
{
    public interface IGCVersion
    {
        Task<GameClientResult> GetClientVersionAsync();
        Task<GameClientResult> GetServerVersionAsync();
    }
}