using Steam.Models;
using SteamWebAPI2.Models.GameServers;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public enum GameServersAppId
    {
        TeamFortress2 = 440,
        CounterStrikeGo = 730
    }

    public class GameServersService : IGameServersService
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public GameServersService(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("IGameServersService", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>Gets a list of game server accounts with their logon tokens.
        /// </summary>
        /// <returns>Collection of game server accounts attached to the account associated with the web API key.</returns>
        public async Task<ISteamWebResponse<AccountListModel>> GetAccountListAsync()
        {
            var steamWebResponse = await steamWebInterface.GetAsync<AccountListContainer>("GetAccountList", 1);
            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<
                ISteamWebResponse<AccountListContainer>,
                ISteamWebResponse<AccountListModel>>(steamWebResponse);
            return steamWebResponseModel;
        }

        /// <summary>Creates a persistent game server account.
        /// </summary>
        /// <param name="appId">Only supports TF2 and CSGO.</param>
        /// <param name="memo">Free text to attach to server. Does nothing but act as an identifier.</param>
        /// <returns>Steam ID and LoginToken for the new server.</returns>
        public async Task<ISteamWebResponse<CreateAccountModel>> CreateAccountAsync(GameServersAppId appId, string memo)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue((int)appId, "appid");
            parameters.AddIfHasValue(memo, "memo");

            var steamWebResponse = await steamWebInterface.PostAsync<CreateAccountContainer>("CreateAccount", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<
                ISteamWebResponse<CreateAccountContainer>,
                ISteamWebResponse<CreateAccountModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>This method changes the memo associated with the game server account. 
        /// Memos do not affect the account in any way. The memo shows up in the GetAccountList 
        /// response and serves only as a reminder of what the account is used for.
        /// </summary>
        /// <param name="steamId">Steam ID of the server to alter.</param>
        /// <param name="memo">Free text to attach to server. Does nothing but act as an identifier.</param>
        /// <returns>200 OK with no content indicates success from this endpoint.</returns>
        public async Task SetMemoAsync(ulong steamId, string memo)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(memo, "memo");
            await steamWebInterface.PostAsync<dynamic>("SetMemo", 1, parameters);
        }

        public async Task<ISteamWebResponse<string>> ResetLoginTokenAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var steamWebResponse = await steamWebInterface.PostAsync<LoginTokenContainer>("ResetLoginToken", 1, parameters);
            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<
                ISteamWebResponse<LoginTokenContainer>,
                ISteamWebResponse<string>>(steamWebResponse);
            return steamWebResponseModel;
        }

        public async Task<ISteamWebResponse<dynamic>> DeleteAccountAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var steamWebResponse = await steamWebInterface.PostAsync<dynamic>("DeleteAccount", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> GetAccountPublicInfoAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var steamWebResponse = await steamWebInterface.GetAsync<dynamic>("GetAccountPublicInfo", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> QueryLoginTokenAsync(string loginToken)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(loginToken, "login_token");
            var steamWebResponse = await steamWebInterface.GetAsync<dynamic>("QueryLoginToken", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> GetServerSteamIDsByIPAsync(IReadOnlyCollection<string> serverIPs)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(serverIPs, "server_ips");
            var steamWebResponse = await steamWebInterface.GetAsync<dynamic>("GetServerSteamIDsByIP", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> GetServerIPsBySteamIDAsync(IReadOnlyCollection<ulong> steamIds)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamIds, "server_steamids");
            var steamWebResponse = await steamWebInterface.GetAsync<dynamic>("GetServerIPsBySteamID", 1, parameters);
            return steamWebResponse;
        }
    }
}