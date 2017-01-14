using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Interfaces
{
    public class GameServersService : SteamWebInterface, IGameServersService
    {
        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public GameServersService(string steamWebApiKey)
            : base(steamWebApiKey, "IGameServersService")
        { }

        public async Task<dynamic> GetAccountListAsync()
        {
            var accountList = await GetAsync<dynamic>("GetAccountList", 1);
            return accountList;
        }

        public async Task<dynamic> CreateAccount(uint appId, string memo)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(memo, "memo");
            var accountList = await PostAsync<dynamic>("CreateAccount", 1, parameters);
            return accountList;
        }

        public async Task<dynamic> SetMemo(ulong steamId, string memo)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(memo, "memo");
            var accountList = await PostAsync<dynamic>("SetMemo", 1, parameters);
            return accountList;
        }

        public async Task<dynamic> ResetLoginToken(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var accountList = await PostAsync<dynamic>("ResetLoginToken", 1, parameters);
            return accountList;
        }

        public async Task<dynamic> DeleteAccount(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var accountList = await PostAsync<dynamic>("DeleteAccount", 1, parameters);
            return accountList;
        }

        public async Task<dynamic> GetAccountPublicInfo(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var accountList = await GetAsync<dynamic>("GetAccountPublicInfo", 1, parameters);
            return accountList;
        }

        public async Task<dynamic> QueryLoginToken(string loginToken)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(loginToken, "login_token");
            var accountList = await GetAsync<dynamic>("QueryLoginToken", 1, parameters);
            return accountList;
        }

        public async Task<dynamic> GetServerSteamIDsByIP(IReadOnlyCollection<string> serverIPs)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(serverIPs, "server_ips");
            var accountList = await GetAsync<dynamic>("GetServerSteamIDsByIP", 1, parameters);
            return accountList;
        }

        public async Task<dynamic> GetServerIPsBySteamID(IReadOnlyCollection<long> steamIds)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamIds, "server_steamids");
            var accountList = await GetAsync<dynamic>("GetServerIPsBySteamID", 1, parameters);
            return accountList;
        }
    }
}
