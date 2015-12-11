using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models.SteamEconomy;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamEconomy
    {
        Task<AssetClassInfoResult> GetAssetClassInfoAsync(int appId, IReadOnlyList<long> classIds);
        Task<AssetPriceResult> GetAssetPricesAsync(int appId, string currency = "", string language = "");
    }
}