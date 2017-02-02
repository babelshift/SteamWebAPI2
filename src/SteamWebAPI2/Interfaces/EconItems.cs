using Steam.Models.GameEconomy;
using SteamWebAPI2.Models.GameEconomy;
using SteamWebAPI2.Utilities;
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

    public class EconItems : IEconItems
    {
        private uint appId;

        // The API only exposes certain methods for certain App Ids in the EconItems interface
        // I'm hard coding the values for now until I come up with a better, more dynamic solution
        private List<uint> validSchemaAppIds = new List<uint>();

        private List<uint> validSchemaUrlAppIds = new List<uint>();
        private List<uint> validStoreMetaDataAppIds = new List<uint>();
        private List<uint> validStoreStatusAppIds = new List<uint>();

        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public EconItems(string steamWebApiKey, EconItemsAppId appId, ISteamWebInterface steamWebInterface = null)
        {
            if (appId <= 0)
            {
                throw new ArgumentOutOfRangeException("appId");
            }

            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "IEconItems_" + (uint)appId)
                : steamWebInterface;

            this.appId = (uint)appId;

            validSchemaAppIds.Add((uint)EconItemsAppId.TeamFortress2);
            validSchemaAppIds.Add((uint)EconItemsAppId.Dota2);
            validSchemaAppIds.Add((uint)EconItemsAppId.Portal2);
            validSchemaAppIds.Add((uint)EconItemsAppId.Portal2_Beta);
            validSchemaAppIds.Add((uint)EconItemsAppId.CounterStrikeGO);

            validSchemaUrlAppIds.Add((uint)EconItemsAppId.TeamFortress2);
            validSchemaUrlAppIds.Add((uint)EconItemsAppId.Dota2);
            validSchemaUrlAppIds.Add((uint)EconItemsAppId.CounterStrikeGO);

            validStoreMetaDataAppIds.Add((uint)EconItemsAppId.TeamFortress2);
            validStoreMetaDataAppIds.Add((uint)EconItemsAppId.Dota2);
            validStoreMetaDataAppIds.Add((uint)EconItemsAppId.CounterStrikeGO);

            validStoreStatusAppIds.Add((uint)EconItemsAppId.TeamFortress2);
        }

        /// <summary>
        /// Returns all player earned Steam items for a specific Steam user.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<EconItemResultModel>> GetPlayerItemsAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(steamId, "steamid");

            var steamWebResponse = await steamWebInterface.GetAsync<EconItemResultContainer>("GetPlayerItems", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<EconItemResultContainer>, ISteamWebResponse<EconItemResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns the economy / item schema for a specific App ID.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<Steam.Models.DOTA2.SchemaModel>> GetSchemaAsync(string language = "en_us")
        {
            if (!validSchemaAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetSchema method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<SchemaResultContainer>("GetSchema", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<SchemaResultContainer>, ISteamWebResponse<Steam.Models.DOTA2.SchemaModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns the economy / item schema for TF2 specifically.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<Steam.Models.TF2.SchemaModel>> GetSchemaForTF2Async(string language = "en_us")
        {
            if (this.appId != (int)EconItemsAppId.TeamFortress2)
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetSchemaTF2 method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<SchemaResultContainer>("GetSchema", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<SchemaResultContainer>, ISteamWebResponse<Steam.Models.TF2.SchemaModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a URL which can be used to access the economy / item schema for a specific App ID.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<string>> GetSchemaUrlAsync()
        {
            if (!validSchemaUrlAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetSchemaUrl method.", appId));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<SchemaUrlResultContainer>("GetSchemaURL", 1);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<SchemaUrlResultContainer>, ISteamWebResponse<string>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns some store meta data for a specific App ID such as banner placement, image placement, drop down behaviors, and more. This seems to drive the game's store pages.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<StoreMetaDataModel>> GetStoreMetaDataAsync(string language = "")
        {
            if (!validStoreMetaDataAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetStoreMetaData method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<StoreMetaDataResultContainer>("GetStoreMetaData", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<StoreMetaDataResultContainer>, ISteamWebResponse<StoreMetaDataModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a status indicator of the current status of a specific App ID.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<uint>> GetStoreStatusAsync()
        {
            if (!validStoreStatusAppIds.Contains(appId))
            {
                throw new InvalidOperationException(String.Format("AppId {0} is not valid for the GetStoreStatus method.", appId));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<StoreStatusResultContainer>("GetStoreStatus", 1);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<StoreStatusResultContainer>, ISteamWebResponse<uint>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}