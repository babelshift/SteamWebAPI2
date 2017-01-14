using Steam.Models.DOTA2;
using SteamWebAPI2.Models.DOTA2;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;

namespace SteamWebAPI2.Interfaces
{
    public class DOTA2Fantasy : SteamWebInterface, IDOTA2Fantasy
    {
        public DOTA2Fantasy(string steamWebApiKey)
            : base(steamWebApiKey, "IDOTA2Fantasy_570")
        { }

        /// <summary>
        /// Returns some official / league information for a Dota 2 player for fantasy sports purposes.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<PlayerOfficialInfoModel> GetPlayerOfficialInfo(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.Add(new SteamWebRequestParameter("accountid", steamId.ToString()));

            var playerOfficialInfo = await GetAsync<PlayerOfficialInfoResultContainer>("GetPlayerOfficialInfo", 1, parameters);

            var playerOfficialInfoModel = new PlayerOfficialInfoModel()
            {
                Name = playerOfficialInfo.Result.Name,
                FantasyRole = playerOfficialInfo.Result.FantasyRole,
                Sponsor = playerOfficialInfo.Result.Sponsor,
                TeamName = playerOfficialInfo.Result.TeamName,
                TeamTag = playerOfficialInfo.Result.TeamTag
            };

            return playerOfficialInfoModel;
        }

        /// <summary>
        /// Returns a collection of all professional players registered in professional Dota 2 leagues.
        /// </summary>
        /// <returns></returns>
        public async Task<ProPlayerDetailModel> GetProPlayerList()
        {
            var proPlayerList = await GetAsync<ProPlayerListResultContainer>("GetProPlayerList", 1);

            var proPlayerDetailModel = AutoMapperConfiguration.Mapper.Map<ProPlayerListResult, ProPlayerDetailModel>(proPlayerList.Result);

            return proPlayerDetailModel;
        }
    }
}