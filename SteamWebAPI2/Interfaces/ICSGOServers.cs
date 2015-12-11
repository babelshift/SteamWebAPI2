using System.Threading.Tasks;
using SteamWebAPI2.Models.CSGO;

namespace SteamWebAPI2.Interfaces
{
    public interface ICSGOServers
    {
        Task<ServerStatusResult> GetGameServerStatusAsync();
    }
}