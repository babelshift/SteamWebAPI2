using System.Threading.Tasks;
using SteamWebAPI2.Models.GameEconomy;
using Steam.Models.GameEconomy;
using Steam.Models.DOTA2;

namespace SteamWebAPI2.Interfaces
{
    public interface IEconItems
    {
        Task<EconItemResultModel> GetPlayerItemsAsync(long steamId);
        Task<SchemaModel> GetSchemaAsync(string language = "");
        Task<string> GetSchemaUrlAsync();
        Task<StoreMetaDataModel> GetStoreMetaDataAsync(string language = "");
        Task<int> GetStoreStatusAsync();
    }
}