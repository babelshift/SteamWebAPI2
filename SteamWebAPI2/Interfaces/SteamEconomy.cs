using Steam.Models.SteamEconomy;
using SteamWebAPI2.Models.SteamEconomy;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamEconomy : ISteamEconomy
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public SteamEconomy(string steamWebApiKey, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface(steamWebApiKey, "ISteamEconomy")
                : steamWebInterface;
        }

        /// <summary>
        /// Returns some economic meta data regarding item qualities, levels, rarities, and more.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="classIds"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<AssetClassInfoResultModel> GetAssetClassInfoAsync(uint appId, IReadOnlyList<ulong> classIds, string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(classIds.Count, "class_count");

            for (int i = 0; i < classIds.Count; i++)
            {
                parameters.AddIfHasValue(classIds[i], String.Format("classid{0}", i));
            }

            var assetClassInfoResult = await steamWebInterface.GetAsync<AssetClassInfoResultContainer>("GetAssetClassInfo", 1, parameters);

            var assetClassInfoResultModel = AutoMapperConfiguration.Mapper.Map<AssetClassInfoResult, AssetClassInfoResultModel>(assetClassInfoResult.Result);

            return assetClassInfoResultModel;
        }

        /// <summary>
        /// Returns economic asset prices.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="currency"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<AssetPriceResultModel> GetAssetPricesAsync(uint appId, string currency = "", string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(currency, "currency");
            parameters.AddIfHasValue(language, "language");

            var assetPriceResult = await steamWebInterface.GetAsync<AssetPriceResultContainer>("GetAssetPrices", 1, parameters);

            var assetPriceResultModel = AutoMapperConfiguration.Mapper.Map<AssetPriceResult, AssetPriceResultModel>(assetPriceResult.Result);

            return assetPriceResultModel;
        }
    }
}