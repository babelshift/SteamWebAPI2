using Steam.Models.DOTA2;
using Steam.Models.GameEconomy;
using SteamWebAPI2.Utilities;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface IEconItems
    {
        Task<ISteamWebResponse<EconItemResultModel>> GetPlayerItemsAsync(ulong steamId);

        Task<ISteamWebResponse<Steam.Models.DOTA2.SchemaModel>> GetSchemaAsync(string language = "en_us");

        Task<ISteamWebResponse<string>> GetSchemaUrlAsync();

        Task<ISteamWebResponse<StoreMetaDataModel>> GetStoreMetaDataAsync(string language = "");

        Task<ISteamWebResponse<uint>> GetStoreStatusAsync();
    }
}