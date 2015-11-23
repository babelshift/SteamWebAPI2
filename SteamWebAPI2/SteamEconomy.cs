using SteamWebAPI2.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamEconomy : SteamWebInterface
    {
        public SteamEconomy(string steamWebApiKey)
            : base(steamWebApiKey, "ISteamEconomy")
        {
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