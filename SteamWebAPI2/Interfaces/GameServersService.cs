using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class GameServersService : IGameServersService
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public GameServersService(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "IGameServersService")
                : steamWebInterface;
        }

        public async Task<ISteamWebResponse<dynamic>> GetAccountListAsync()
        {
            var steamWebResponse = await steamWebInterface.GetAsync<dynamic>("GetAccountList", 1);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> CreateAccount(uint appId, string memo)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(memo, "memo");
            var steamWebResponse = await steamWebInterface.PostAsync<dynamic>("CreateAccount", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> SetMemo(ulong steamId, string memo)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            parameters.AddIfHasValue(memo, "memo");
            var steamWebResponse = await steamWebInterface.PostAsync<dynamic>("SetMemo", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> ResetLoginToken(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var steamWebResponse = await steamWebInterface.PostAsync<dynamic>("ResetLoginToken", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> DeleteAccount(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var steamWebResponse = await steamWebInterface.PostAsync<dynamic>("DeleteAccount", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> GetAccountPublicInfo(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamId, "steamid");
            var steamWebResponse = await steamWebInterface.GetAsync<dynamic>("GetAccountPublicInfo", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> QueryLoginToken(string loginToken)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(loginToken, "login_token");
            var steamWebResponse = await steamWebInterface.GetAsync<dynamic>("QueryLoginToken", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> GetServerSteamIDsByIP(IReadOnlyCollection<string> serverIPs)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(serverIPs, "server_ips");
            var steamWebResponse = await steamWebInterface.GetAsync<dynamic>("GetServerSteamIDsByIP", 1, parameters);
            return steamWebResponse;
        }

        public async Task<ISteamWebResponse<dynamic>> GetServerIPsBySteamID(IReadOnlyCollection<ulong> steamIds)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.AddIfHasValue(steamIds, "server_steamids");
            var steamWebResponse = await steamWebInterface.GetAsync<dynamic>("GetServerIPsBySteamID", 1, parameters);
            return steamWebResponse;
        }
    }
}