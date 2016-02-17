using Steam.Models.SteamEconomy;
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

        public async Task<AssetClassInfoResultModel> GetAssetClassInfoAsync(int appId, IReadOnlyList<long> classIds)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(appId, "appid", parameters);
            AddToParametersIfHasValue(classIds.Count, "class_count", parameters);

            for (int i = 0; i < classIds.Count; i++)
            {
                AddToParametersIfHasValue(classIds[i], String.Format("classid{0}", i), parameters);
            }

            var assetClassInfoResult = await CallMethodAsync<AssetClassInfoResultContainer>("GetAssetClassInfo", 1, parameters);

            var assetClassInfoResultModel = AutoMapperConfiguration.Mapper.Map<AssetClassInfoResult, AssetClassInfoResultModel>(assetClassInfoResult.Result);

            return assetClassInfoResultModel;
        }

        public async Task<AssetPriceResultModel> GetAssetPricesAsync(int appId, string currency = "", string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(appId, "appid", parameters);
            AddToParametersIfHasValue(currency, "currency", parameters);
            AddToParametersIfHasValue(language, "language", parameters);

            var assetPriceResult = await CallMethodAsync<AssetPriceResultContainer>("GetAssetPrices", 1, parameters);

            var assetPriceResultModel = AutoMapperConfiguration.Mapper.Map<AssetPriceResult, AssetPriceResultModel>(assetPriceResult.Result);

            return assetPriceResultModel;
        }
    }
}