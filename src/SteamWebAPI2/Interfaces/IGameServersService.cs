using Steam.Models.GameServers;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IGameServersService
    {
        Task<ISteamWebResponse<AccountListModel>> GetAccountListAsync();

        Task<ISteamWebResponse<CreateAccountModel>> CreateAccountAsync(AppId appId, string memo);

        Task SetMemoAsync(ulong steamId, string memo);

        Task<ISteamWebResponse<string>> ResetLoginTokenAsync(ulong steamId);

        Task DeleteAccountAsync(ulong steamId);

        Task<ISteamWebResponse<AccountPublicInfoModel>> GetAccountPublicInfoAsync(ulong steamId);

        Task<ISteamWebResponse<QueryLoginTokenModel>> QueryLoginTokenAsync(string loginToken);

        Task<ISteamWebResponse<dynamic>> GetServerSteamIDsByIPAsync(IReadOnlyCollection<string> serverIPs);

        Task<ISteamWebResponse<dynamic>> GetServerIPsBySteamIDAsync(IReadOnlyCollection<ulong> steamIds);
    }
}