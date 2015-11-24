using SteamWebAPI2.Models.DOTA2;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class DOTA2Fantasy : SteamWebInterface
    {
        public DOTA2Fantasy(string steamWebApiKey)
            : base(steamWebApiKey, "IDOTA2Fantasy_570")
        { }

        public async Task<PlayerOfficialInfoResult> GetPlayerOfficialInfo(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.Add(new SteamWebRequestParameter("accountid", steamId.ToString()));

            var gameServerStatus = await CallMethodAsync<PlayerOfficialInfoResultContainer>("GetPlayerOfficialInfo", 1, parameters);
            return gameServerStatus.Result;
        }

        public async Task<ProPlayerListResult> GetProPlayerList()
        {
            var proPlayerList = await CallMethodAsync<ProPlayerListResultContainer>("GetProPlayerList", 1);
            return proPlayerList.Result;
        }
    }
}