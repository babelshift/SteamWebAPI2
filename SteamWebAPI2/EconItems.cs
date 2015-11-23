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

        private List<int> validSchemaAppIds = new List<int>();

        public EconItems(string steamWebApiKey, int appId)
            : base(steamWebApiKey, "IEconItems_" + appId)
        {
            if(appId <= 0)
            {
                throw new ArgumentOutOfRangeException("appId");
            }

            this.appId = appId;

            validSchemaAppIds.Add(440);
            validSchemaAppIds.Add(570);
            validSchemaAppIds.Add(620);
            validSchemaAppIds.Add(841);
        }

        public async Task<EconItemResult> GetPlayerItemsAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("steamid", steamId, parameters);

            var econItemsResult = await CallMethodAsync<EconItemResultContainer>("GetPlayerItems", 1, parameters);
            return econItemsResult.Result;
        }

        public async Task<SchemaResult> GetSchemaAsync(string language = "")
        {
            if (!validSchemaAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetSchema method.", appId));
            }
            
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("language", language, parameters);

            var schemaResult = await CallMethodAsync<SchemaResultContainer>("GetSchema", 1, parameters);
            return schemaResult.Result;
        }
    }
}
