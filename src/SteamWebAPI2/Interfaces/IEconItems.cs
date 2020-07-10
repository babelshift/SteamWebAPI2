using Steam.Models.GameEconomy;
using SteamWebAPI2.Utilities;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IEconItems
    {
        Task<ISteamWebResponse<EconItemResultModel>> GetPlayerItemsAsync(ulong steamId);

        Task<ISteamWebResponse<SteamWebAPI2.Models.GameEconomy.SchemaItemsResultContainer>> GetSchemaItemsForTF2Async(string language = "en_us", uint? start = null);

        Task<ISteamWebResponse<SteamWebAPI2.Models.GameEconomy.SchemaOverviewResultContainer>> GetSchemaOverviewForTF2Async(string language = "en_us");

        Task<ISteamWebResponse<string>> GetSchemaUrlAsync();

        Task<ISteamWebResponse<StoreMetaDataModel>> GetStoreMetaDataAsync(string language = "");

        Task<ISteamWebResponse<uint>> GetStoreStatusAsync();
    }
}