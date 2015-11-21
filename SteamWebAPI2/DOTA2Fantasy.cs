using SteamWebAPI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    internal class DOTA2Fantasy : SteamWebRequest
    {
        
        public DOTA2Fantasy(SteamWebRequestParameter developerKey)
            : base(developerKey, "IDOTA2Fantasy_570") { }

        public async Task<DOTA2PlayerOfficialInfoResult> GetPlayerOfficialInfo(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();
            parameters.Add(new SteamWebRequestParameter("accountid", steamId.ToString()));

            var gameServerStatus = await GetJsonAsync<DOTA2PlayerOfficialInfoResultContainer>(interfaceName, "GetPlayerOfficialInfo", 1, parameters);
            return gameServerStatus.Result;
        }
    }
}
