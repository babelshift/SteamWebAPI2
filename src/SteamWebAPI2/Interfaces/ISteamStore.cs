﻿using Steam.Models.SteamStore;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    internal interface ISteamStore
    {
        Task<StoreAppDetailsDataModel> GetStoreAppDetailsAsync(uint appId, string cc = "", string language = "");

        Task<StoreFeaturedCategoriesModel> GetStoreFeaturedCategoriesAsync();

        Task<StoreFeaturedProductsModel> GetStoreFeaturedProductsAsync();
    }
}