using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IGameServersService
    {
        Task<ISteamWebResponse<dynamic>> GetAccountListAsync();

        Task<ISteamWebResponse<dynamic>> CreateAccount(uint appid, string memo);

        Task<ISteamWebResponse<dynamic>> SetMemo(ulong steamId, string memo);

        Task<ISteamWebResponse<dynamic>> ResetLoginToken(ulong steamId);

        Task<ISteamWebResponse<dynamic>> DeleteAccount(ulong steamId);

        Task<ISteamWebResponse<dynamic>> GetAccountPublicInfo(ulong steamId);

        Task<ISteamWebResponse<dynamic>> QueryLoginToken(string loginToken);

        Task<ISteamWebResponse<dynamic>> GetServerSteamIDsByIP(IReadOnlyCollection<string> serverIPs);

        Task<ISteamWebResponse<dynamic>> GetServerIPsBySteamID(IReadOnlyCollection<ulong> steamIds);
    }
}