using Steam.Models.GameEconomy;
using SteamWebAPI2.Models.GameEconomy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public enum EconItemsAppId
    {
        TeamFortress2 = 440,
        Dota2 = 570,
        Payday2 = 218620,
        DefenseGrid2 = 221540,
        BattleBlockTheater = 238460,
        Portal2 = 620,
        CounterStrikeGO = 730,
        Portal2_Beta = 841
    }

    public class EconItems : SteamWebInterface, IEconItems
    {
        private int appId;

        // The API only exposes certain methods for certain App Ids in the EconItems interface
        // I'm hard coding the values for now until I come up with a better, more dynamic solution
        private List<int> validSchemaAppIds = new List<int>();
        private List<int> validSchemaUrlAppIds = new List<int>();
        private List<int> validStoreMetaDataAppIds = new List<int>();
        private List<int> validStoreStatusAppIds = new List<int>();

        public EconItems(string steamWebApiKey, EconItemsAppId appId)
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

        public async Task<EconItemResultModel> GetPlayerItemsAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(steamId, "steamid", parameters);

            var econItemsResult = await CallMethodAsync<EconItemResultContainer>("GetPlayerItems", 1, parameters);

            var econItemResultModel = AutoMapperConfiguration.Mapper.Map<EconItemResult, EconItemResultModel>(econItemsResult.Result);

            return econItemResultModel;
        }

        public async Task<SchemaModel> GetSchemaAsync(string language = "")
        {
            if (!validSchemaAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetSchema method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(language, "language", parameters);

            var schemaResult = await CallMethodAsync<SchemaResultContainer>("GetSchema", 1, parameters);

            var schemaModel = AutoMapperConfiguration.Mapper.Map<SchemaResult, SchemaModel>(schemaResult.Result);

            return schemaModel;
        }

        public async Task<string> GetSchemaUrlAsync()
        {
            if (!validSchemaUrlAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetSchemaUrl method.", appId));
            }

            var schemaUrlResult = await CallMethodAsync<SchemaUrlResultContainer>("GetSchemaURL", 1);

            return schemaUrlResult.Result.ItemsGameUrl;
        }

        public async Task<StoreMetaDataModel> GetStoreMetaDataAsync(string language = "")
        {
            if (!validStoreMetaDataAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetStoreMetaData method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(language, "language", parameters);

            var storeMetaDataResult = await CallMethodAsync<StoreMetaDataResultContainer>("GetStoreMetaData", 1, parameters);

            var storeMetaDataModel = AutoMapperConfiguration.Mapper.Map<StoreMetaDataResult, StoreMetaDataModel>(storeMetaDataResult.Result);

            return storeMetaDataModel;
        }

        public async Task<int> GetStoreStatusAsync()
        {
            if (!validStoreStatusAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetStoreStatus method.", appId));
            }

            var storeStatusResult = await CallMethodAsync<StoreStatusResultContainer>("GetStoreStatus", 1);

            return storeStatusResult.Result.StoreStatus;
        }
    }
}