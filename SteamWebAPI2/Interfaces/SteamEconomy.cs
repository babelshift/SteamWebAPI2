using SteamWebAPI2.Models.SteamEconomy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamEconomy : SteamWebInterface, ISteamEconomy
    {
        public SteamEconomy(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamEconomy")
        {
        }

        public async Task<AssetClassInfoResult> GetAssetClassInfoAsync(int appId, IReadOnlyList<long> classIds)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(appId, "appid", parameters);
            AddToParametersIfHasValue(classIds.Count, "class_count", parameters);

            for (int i = 0; i < classIds.Count; i++)
            {
                AddToParametersIfHasValue(classIds[i], String.Format("classid{0}", i), parameters);
            }

            var assetClassInfoResult = await CallMethodAsync<AssetClassInfoResultContainer>("GetAssetClassInfo", 1, parameters);
            return assetClassInfoResult.Result;
        }

        public async Task<AssetPriceResult> GetAssetPricesAsync(int appId, string currency = "", string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(appId, "appid", parameters);
            AddToParametersIfHasValue(currency, "currency", parameters);
            AddToParametersIfHasValue(language, "language", parameters);

            var assetPriceResult = await CallMethodAsync<AssetPriceResultContainer>("GetAssetPrices", 1, parameters);
            return assetPriceResult.Result;
        }
    }
}