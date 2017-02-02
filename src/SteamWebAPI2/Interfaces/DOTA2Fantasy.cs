using Steam.Models.DOTA2;
using SteamWebAPI2.Models.DOTA2;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class DOTA2Fantasy : IDOTA2Fantasy
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public DOTA2Fantasy(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "IDOTA2Fantasy_570")
                : steamWebInterface;
        }

        /// <summary>
        /// Returns some official / league information for a Dota 2 player for fantasy sports purposes.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<PlayerOfficialInfoModel>> GetPlayerOfficialInfo(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.Add(new SteamWebRequestParameter("accountid", steamId.ToString()));

            var steamWebResponse = await steamWebInterface.GetAsync<PlayerOfficialInfoResultContainer>("GetPlayerOfficialInfo", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<PlayerOfficialInfoResultContainer>, ISteamWebResponse<PlayerOfficialInfoModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a collection of all professional players registered in professional Dota 2 leagues.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<ProPlayerDetailModel>> GetProPlayerList()
        {
            var steamWebResponse = await steamWebInterface.GetAsync<ProPlayerListResult>("GetProPlayerList", 1);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<ProPlayerListResult>, ISteamWebResponse<ProPlayerDetailModel>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}