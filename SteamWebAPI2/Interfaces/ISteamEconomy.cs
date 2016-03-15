using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models.SteamEconomy;
using Steam.Models.SteamEconomy;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamEconomy
    {
        Task<AssetClassInfoResultModel> GetAssetClassInfoAsync(int appId, IReadOnlyList<long> classIds, string language);
        Task<AssetPriceResultModel> GetAssetPricesAsync(int appId, string currency, string language);
    }
}