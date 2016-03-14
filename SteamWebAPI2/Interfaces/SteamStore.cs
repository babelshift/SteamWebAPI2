using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamStore : SteamWebInterface, ISteamStore
    {
        public SteamStore(string steamWebApiKey)
            : base(steamWebApiKey, string.Empty)
        { }

        //public Task<StoreAppDetailsModel> GetStoreAppDetailsAsync()
        //{

        //}

        //public Task<StoreFeaturedCategoriesModel> GetStoreFeaturedCategoriesAsync()
        //{

        //}

        //public Task<StoreFeaturedProductsModel> GetStoreFeaturedProductsAsync()
        //{

        //}
    }
}
