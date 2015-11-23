using SteamWebAPI2.Models.Economy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class EconItems : SteamWebInterface
    {
        private int appId;

        public EconItems(string steamWebApiKey, int appId)
            : base(steamWebApiKey, "IEconItems_" + appId)
        {
            if(appId <= 0)
            {
                throw new ArgumentOutOfRangeException("appId");
            }

            this.appId = appId;
        }

        public async Task<EconItemResult> GetPlayerItemsAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("steamid", steamId, parameters);

            var econItemsResult = await CallMethodAsync<EconItemResultContainer>("GetPlayerItems", 1, parameters);
            return econItemsResult.Result;
        }
    }
}
