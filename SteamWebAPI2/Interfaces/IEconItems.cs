using Steam.Models.DOTA2;
using Steam.Models.GameEconomy;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IEconItems
    {
        Task<EconItemResultModel> GetPlayerItemsAsync(ulong steamId);

        Task<SchemaModel> GetSchemaAsync(string language = "");

        Task<string> GetSchemaUrlAsync();

        Task<StoreMetaDataModel> GetStoreMetaDataAsync(string language = "");

        Task<uint> GetStoreStatusAsync();
    }
}