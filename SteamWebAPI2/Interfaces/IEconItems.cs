using System.Threading.Tasks;
using SteamWebAPI2.Models.GameEconomy;

namespace SteamWebAPI2.Interfaces
{
    public interface IEconItems
    {
        Task<EconItemResult> GetPlayerItemsAsync(long steamId);
        Task<SchemaResult> GetSchemaAsync(string language = "");
        Task<SchemaUrlResult> GetSchemaUrlAsync();
        Task<StoreMetaDataResult> GetStoreMetaDataAsync(string language = "");
        Task<StoreStatusResult> GetStoreStatusAsync();
    }
}