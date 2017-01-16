using Steam.Models.SteamEconomy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamEconomy
    {
        Task<AssetClassInfoResultModel> GetAssetClassInfoAsync(int appId, IReadOnlyList<long> classIds, string language);

        Task<AssetPriceResultModel> GetAssetPricesAsync(int appId, string currency, string language);
    }
}