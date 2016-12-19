using Steam.Models.GameEconomy;
using SteamWebAPI2.Models.GameEconomy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Utilities;

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

            validSchemaAppIds.Add((int)EconItemsAppId.TeamFortress2);
            validSchemaAppIds.Add((int)EconItemsAppId.Dota2);
            validSchemaAppIds.Add((int)EconItemsAppId.Portal2);
            validSchemaAppIds.Add((int)EconItemsAppId.Portal2_Beta);
            validSchemaAppIds.Add((int)EconItemsAppId.CounterStrikeGO);

            validSchemaUrlAppIds.Add((int)EconItemsAppId.TeamFortress2);
            validSchemaUrlAppIds.Add((int)EconItemsAppId.Dota2);
            validSchemaUrlAppIds.Add((int)EconItemsAppId.CounterStrikeGO);

            validStoreMetaDataAppIds.Add((int)EconItemsAppId.TeamFortress2);
            validStoreMetaDataAppIds.Add((int)EconItemsAppId.Dota2);
            validStoreMetaDataAppIds.Add((int)EconItemsAppId.CounterStrikeGO);

            validStoreStatusAppIds.Add((int)EconItemsAppId.TeamFortress2);
        }

        /// <summary>
        /// Returns all player earned Steam items for a specific Steam user.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<EconItemResultModel> GetPlayerItemsAsync(long steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(steamId, "steamid");

            var econItemsResult = await CallMethodAsync<EconItemResultContainer>("GetPlayerItems", 1, parameters);

            var econItemResultModel = AutoMapperConfiguration.Mapper.Map<EconItemResult, EconItemResultModel>(econItemsResult.Result);

            return econItemResultModel;
        }

        /// <summary>
        /// Returns the economy / item schema for a specific App ID.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Steam.Models.DOTA2.SchemaModel> GetSchemaAsync(string language = "en_us")
        {
            if (!validSchemaAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetSchema method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var schemaResult = await CallMethodAsync<SchemaResultContainer>("GetSchema", 1, parameters);

            var schemaModel = AutoMapperConfiguration.Mapper.Map<SchemaResult, Steam.Models.DOTA2.SchemaModel>(schemaResult.Result);

            return schemaModel;
        }

        /// <summary>
        /// Returns the economy / item schema for a specific App ID.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<Steam.Models.TF2.SchemaModel> GetSchemaForTF2Async(string language = "en_us")
        {
            if(this.appId != (int)EconItemsAppId.TeamFortress2)
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetSchemaTF2 method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var schemaResult = await CallMethodAsync<SchemaResultContainer>("GetSchema", 1, parameters);

            var schemaModel = AutoMapperConfiguration.Mapper.Map<SchemaResult, Steam.Models.TF2.SchemaModel>(schemaResult.Result);

            return schemaModel;
        }

        /// <summary>
        /// Returns a URL which can be used to access the economy / item schema for a specific App ID.
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetSchemaUrlAsync()
        {
            if (!validSchemaUrlAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetSchemaUrl method.", appId));
            }

            var schemaUrlResult = await CallMethodAsync<SchemaUrlResultContainer>("GetSchemaURL", 1);

            return schemaUrlResult.Result.ItemsGameUrl;
        }

        /// <summary>
        /// Returns some store meta data for a specific App ID such as banner placement, image placement, drop down behaviors, and more. This seems to drive the game's store pages.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<StoreMetaDataModel> GetStoreMetaDataAsync(string language = "")
        {
            if (!validStoreMetaDataAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetStoreMetaData method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var storeMetaDataResult = await CallMethodAsync<StoreMetaDataResultContainer>("GetStoreMetaData", 1, parameters);

            var storeMetaDataModel = AutoMapperConfiguration.Mapper.Map<StoreMetaDataResult, StoreMetaDataModel>(storeMetaDataResult.Result);

            return storeMetaDataModel;
        }

        /// <summary>
        /// Returns a status indicator of the current status of a specific App ID.
        /// </summary>
        /// <returns></returns>
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