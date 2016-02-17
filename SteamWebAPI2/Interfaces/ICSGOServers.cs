using Steam.Models.CSGO;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ICSGOServers
    {
        Task<ServerStatusModel> GetGameServerStatusAsync();
    }
}