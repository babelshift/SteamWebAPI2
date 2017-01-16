using Steam.Models.SteamEconomy;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamEconomy
    {
        Task<AssetClassInfoResultModel> GetAssetClassInfoAsync(uint appId, IReadOnlyList<ulong> classIds, string language);

        Task<AssetPriceResultModel> GetAssetPricesAsync(uint appId, string currency, string language);
    }
}