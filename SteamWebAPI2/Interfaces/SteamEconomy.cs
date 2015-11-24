using SteamWebAPI2.Models.SteamEconomy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamEconomy : SteamWebInterface
    {
        public SteamEconomy(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamEconomy")
        {
        }

        public async Task<AssetClassInfoResult> GetAssetClassInfoAsync(int appId, IReadOnlyList<long> classIds)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("appid", appId, parameters);
            AddToParametersIfHasValue("class_count", classIds.Count, parameters);

            for (int i = 0; i < classIds.Count; i++)
            {
                AddToParametersIfHasValue(String.Format("classid{0}", i), classIds[i], parameters);
            }

            var assetClassInfoResult = await CallMethodAsync<AssetClassInfoResultContainer>("GetAssetClassInfo", 1, parameters);
            return assetClassInfoResult.Result;
        }

        public async Task<AssetPriceResult> GetAssetPricesAsync(int appId, string currency = "", string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("appid", appId, parameters);
            AddToParametersIfHasValue("currency", currency, parameters);
            AddToParametersIfHasValue("language", language, parameters);

            var assetPriceResult = await CallMethodAsync<AssetPriceResultContainer>("GetAssetPrices", 1, parameters);
            return assetPriceResult.Result;
        }
    }
}