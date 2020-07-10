using AutoMapper;
using Steam.Models.GameEconomy;
using SteamWebAPI2.Models.GameEconomy;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class EconItems : IEconItems
    {
        private readonly ISteamWebInterface steamWebInterface;
        private readonly IMapper mapper;

        private uint appId;

        // The API only exposes certain methods for certain App Ids in the EconItems interface
        // I'm hard coding the values for now until I come up with a better, more dynamic solution
        private List<uint> validSchemaAppIds = new List<uint>();
        private List<uint> validSchemaUrlAppIds = new List<uint>();
        private List<uint> validStoreMetaDataAppIds = new List<uint>();
        private List<uint> validStoreStatusAppIds = new List<uint>();

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public EconItems(IMapper mapper, ISteamWebRequest steamWebRequest, AppId appId, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            if (appId <= 0)
            {
                throw new ArgumentOutOfRangeException("appId");
            }

            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("IEconItems_" + (uint)appId, steamWebRequest)
                : steamWebInterface;

            this.appId = (uint)appId;

            validSchemaAppIds.Add((uint)AppId.TeamFortress2);
            validSchemaAppIds.Add((uint)AppId.Dota2);
            validSchemaAppIds.Add((uint)AppId.Portal2);
            validSchemaAppIds.Add((uint)AppId.Portal2_Beta);
            validSchemaAppIds.Add((uint)AppId.CounterStrikeGO);

            validSchemaUrlAppIds.Add((uint)AppId.TeamFortress2);
            validSchemaUrlAppIds.Add((uint)AppId.Dota2);
            validSchemaUrlAppIds.Add((uint)AppId.CounterStrikeGO);

            validStoreMetaDataAppIds.Add((uint)AppId.TeamFortress2);
            validStoreMetaDataAppIds.Add((uint)AppId.Dota2);
            validStoreMetaDataAppIds.Add((uint)AppId.CounterStrikeGO);

            validStoreStatusAppIds.Add((uint)AppId.TeamFortress2);
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

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<EconItemResultContainer>, ISteamWebResponse<EconItemResultModel>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns the item schema for TF2 specifically.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SchemaItemsResultContainer>> GetSchemaItemsForTF2Async(string language = "en_us", uint? start = null)
        {
            if (appId != (int)AppId.TeamFortress2)
            {
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetSchemaTF2 method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(start, "start");

            var steamWebResponse = await steamWebInterface.GetAsync<SchemaItemsResultContainer>("GetSchemaItems", 1, parameters);

            return steamWebResponse;
        }

        /// <summary>
        /// Returns the schema overview for TF2 specifically.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SchemaOverviewResultContainer>> GetSchemaOverviewForTF2Async(string language = "en_us")
        {
            if (appId != (int)AppId.TeamFortress2)
            {
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetSchemaTF2 method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<SchemaOverviewResultContainer>("GetSchemaOverview", 1, parameters);

            return steamWebResponse;
        }

        /// <summary>
        /// Returns a URL which can be used to access the economy / item schema for a specific App ID.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<string>> GetSchemaUrlAsync()
        {
            if (!validSchemaUrlAppIds.Contains(appId))
            {
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetSchemaUrl method.", appId));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<SchemaUrlResultContainer>("GetSchemaURL", 1);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<SchemaUrlResultContainer>, ISteamWebResponse<string>>(steamWebResponse);

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
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetStoreMetaData method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<StoreMetaDataResultContainer>("GetStoreMetaData", 1, parameters);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<StoreMetaDataResultContainer>, ISteamWebResponse<StoreMetaDataModel>>(steamWebResponse);

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
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetStoreStatus method.", appId));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<StoreStatusResultContainer>("GetStoreStatus", 1);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<StoreStatusResultContainer>, ISteamWebResponse<uint>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}