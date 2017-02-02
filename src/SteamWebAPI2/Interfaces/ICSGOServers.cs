using Steam.Models.CSGO;
using SteamWebAPI2.Utilities;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ICSGOServers
    {
        Task<ISteamWebResponse<ServerStatusModel>> GetGameServerStatusAsync();
    }
}