using SteamWebAPI2.Models.GameEconomy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public enum SteamAppId
    {
        TeamFortress2 = 440,
        Dota2 = 570
    }

    public class EconItems : SteamWebInterface
    {
        private int appId;

        // The API only exposes certain methods for certain App Ids in the EconItems interface
        // I'm hard coding the values for now until I come up with a better, more dynamic solution
        private List<int> validSchemaAppIds = new List<int>();

        private List<int> validSchemaUrlAppIds = new List<int>();
        private List<int> validStoreMetaDataAppIds = new List<int>();
        private List<int> validStoreStatusAppIds = new List<int>();

        public EconItems(string steamWebApiKey, SteamAppId appId)
            : base(steamWebApiKey, "IEconItems_" + (int)appId)
        {
            if (appId <= 0)
            {
                throw new ArgumentOutOfRangeException("appId");
            }

            this.appId = (int)appId;

            validSchemaAppIds.Add(440);
            validSchemaAppIds.Add(570);
            validSchemaAppIds.Add(620);
            validSchemaAppIds.Add(841);
            validSchemaAppIds.Add(730);

            validSchemaUrlAppIds.Add(440);
            validSchemaUrlAppIds.Add(570);
            validSchemaUrlAppIds.Add(730);

            validStoreMetaDataAppIds.Add(440);
            validStoreMetaDataAppIds.Add(570);
            validSchemaUrlAppIds.Add(730);

            validStoreStatusAppIds.Add(440);
        }

        public async Task<EconItemResult> GetPlayerItemsAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(steamId, "steamid", parameters);

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

            AddToParametersIfHasValue(language, "language", parameters);

            var schemaResult = await CallMethodAsync<SchemaResultContainer>("GetSchema", 1, parameters);
            return schemaResult.Result;
        }

        public async Task<SchemaUrlResult> GetSchemaUrlAsync()
        {
            if (!validSchemaUrlAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetSchemaUrl method.", appId));
            }

            var schemaUrlResult = await CallMethodAsync<SchemaUrlResultContainer>("GetSchemaURL", 1);
            return schemaUrlResult.Result;
        }

        public async Task<StoreMetaDataResult> GetStoreMetaDataAsync(string language = "")
        {
            if (!validStoreMetaDataAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetStoreMetaData method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(language, "language", parameters);

            var storeMetaDataResult = await CallMethodAsync<StoreMetaDataResultContainer>("GetStoreMetaData", 1);
            return storeMetaDataResult.Result;
        }

        public async Task<StoreStatusResult> GetStoreStatusAsync()
        {
            if (!validStoreStatusAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetStoreStatus method.", appId));
            }

            var storeStatusResult = await CallMethodAsync<StoreStatusResultContainer>("GetStoreStatus", 1);
            return storeStatusResult.Result;
        }
    }
}