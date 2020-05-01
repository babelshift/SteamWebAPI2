using AutoMapper;
using Steam.Models.GameServers;
using SteamWebAPI2.Models.GameServers;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class GameServersService : IGameServersService
    {
        private readonly ISteamWebInterface steamWebInterface;
        private readonly IMapper mapper;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public GameServersService(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

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
            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<AccountListContainer>,
                ISteamWebResponse<AccountListModel>>(steamWebResponse);
            return steamWebResponseModel;
        }

        /// <summary>Creates a persistent game server account.
        /// </summary>
        /// <param name="appId">Only supports TF2 and CSGO.</param>
        /// <param name="memo">Free text to attach to server. Does nothing but act as an identifier.</param>
        /// <returns>Steam ID and LoginToken for the new server.</returns>
        public async Task<ISteamWebResponse<CreateAccountModel>> CreateAccountAsync(AppId appId, string memo)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue((int)appId, "appid");
            parameters.AddIfHasValue(memo, "memo");

            var steamWebResponse = await steamWebInterface.PostAsync<CreateAccountContainer>("CreateAccount", 1, parameters);

            var steamWebResponseModel = mapper.Map<
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

        /// <summary>Generates a new login token for the specified game server
        /// </summary>
        /// <param name="steamId">The SteamID of the game server to reset the login token</param>
        /// <returns>New login token</returns>
        public async Task<ISteamWebResponse<string>> ResetLoginTokenAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var steamWebResponse = await steamWebInterface.PostAsync<ResetLoginTokenContainer>("ResetLoginToken", 1, parameters);
            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<ResetLoginTokenContainer>,
                ISteamWebResponse<string>>(steamWebResponse);
            return steamWebResponseModel;
        }

        /// <summary>Deletes a persistent game server account
        /// </summary>
        /// <param name="steamId">The SteamID of the game server account to delete</param>
        /// <returns>200 OK with no content indicates success from this endpoint.</returns>
        public async Task DeleteAccountAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            await steamWebInterface.PostAsync<dynamic>("DeleteAccount", 1, parameters);
        }

        /// <summary>Gets public information about a given game server account
        /// </summary>
        /// <param name="steamId">The SteamID of the game server to get info</param>
        /// <returns>Steam ID and associated App ID of the game server</returns>
        public async Task<ISteamWebResponse<AccountPublicInfoModel>> GetAccountPublicInfoAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var steamWebResponse = await steamWebInterface.GetAsync<AccountPublicInfoContainer>("GetAccountPublicInfo", 1, parameters);
            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<AccountPublicInfoContainer>,
                ISteamWebResponse<AccountPublicInfoModel>>(steamWebResponse);
            return steamWebResponseModel;
        }

        public async Task<ISteamWebResponse<QueryLoginTokenModel>> QueryLoginTokenAsync(string loginToken)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(loginToken, "login_token");
            var steamWebResponse = await steamWebInterface.GetAsync<QueryLoginTokenContainer>("QueryLoginToken", 1, parameters);
            var steamWebResponseModel = mapper.Map<
                ISteamWebResponse<QueryLoginTokenContainer>,
                ISteamWebResponse<QueryLoginTokenModel>>(steamWebResponse);
            return steamWebResponseModel;
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