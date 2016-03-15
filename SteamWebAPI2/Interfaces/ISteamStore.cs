using Steam.Models.SteamStore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    internal interface ISteamStore
    {
        Task<StoreAppDetailsDataModel> GetStoreAppDetailsAsync(int appId);

        Task<StoreFeaturedCategoriesModel> GetStoreFeaturedCategoriesAsync();

        Task<StoreFeaturedProductsModel> GetStoreFeaturedProductsAsync();
    }
}