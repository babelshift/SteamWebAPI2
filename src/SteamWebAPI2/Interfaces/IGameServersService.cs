using Steam.Models;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IGameServersService
    {
        Task<ISteamWebResponse<AccountListModel>> GetAccountListAsync();

        Task<ISteamWebResponse<CreateAccountModel>> CreateAccount(GameServersAppId appId, string memo);

        Task<ISteamWebResponse<dynamic>> SetMemo(ulong steamId, string memo);

        Task<ISteamWebResponse<dynamic>> ResetLoginToken(ulong steamId);

        Task<ISteamWebResponse<dynamic>> DeleteAccount(ulong steamId);

        Task<ISteamWebResponse<dynamic>> GetAccountPublicInfo(ulong steamId);

        Task<ISteamWebResponse<dynamic>> QueryLoginToken(string loginToken);

        Task<ISteamWebResponse<dynamic>> GetServerSteamIDsByIP(IReadOnlyCollection<string> serverIPs);

        Task<ISteamWebResponse<dynamic>> GetServerIPsBySteamID(IReadOnlyCollection<ulong> steamIds);
    }
}