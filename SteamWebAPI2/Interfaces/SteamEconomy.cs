using Steam.Models.SteamEconomy;
using SteamWebAPI2.Models.SteamEconomy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Interfaces
{
    public class SteamEconomy : SteamWebInterface, ISteamEconomy
    {
        public SteamEconomy(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamEconomy")
        {
        }
        
        /// <summary>
        /// Returns some economic meta data regarding item qualities, levels, rarities, and more.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="classIds"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<AssetClassInfoResultModel> GetAssetClassInfoAsync(int appId, IReadOnlyList<long> classIds, string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(classIds.Count, "class_count");

            for (int i = 0; i < classIds.Count; i++)
            {
                parameters.AddIfHasValue(classIds[i], String.Format("classid{0}", i));
            }

            var assetClassInfoResult = await CallMethodAsync<AssetClassInfoResultContainer>("GetAssetClassInfo", 1, parameters);

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
        public async Task<AssetPriceResultModel> GetAssetPricesAsync(int appId, string currency = "", string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(currency, "currency");
            parameters.AddIfHasValue(language, "language");

            var assetPriceResult = await CallMethodAsync<AssetPriceResultContainer>("GetAssetPrices", 1, parameters);

            var assetPriceResultModel = AutoMapperConfiguration.Mapper.Map<AssetPriceResult, AssetPriceResultModel>(assetPriceResult.Result);

            return assetPriceResultModel;
        }
    }
}