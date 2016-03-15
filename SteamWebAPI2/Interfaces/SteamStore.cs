using Steam.Models.SteamStore;
using SteamWebAPI2.Models.SteamStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Interfaces
{
    public class SteamStore : SteamStoreInterface, ISteamStore
    {
        public async Task<StoreAppDetailsDataModel> GetStoreAppDetailsAsync(int appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appId");

            var appDetails = await CallMethodAsync<AppDetailsContainer>("appdetails", parameters);

            var appDetailsModel = AutoMapperConfiguration.Mapper.Map<Data, StoreAppDetailsDataModel>(appDetails.Data);

            return appDetailsModel;
        }

        public async Task<StoreFeaturedCategoriesModel> GetStoreFeaturedCategoriesAsync()
        {
            var featuredCategories = await CallMethodAsync<FeaturedCategoriesContainer>("featuredcategories");

            var featuredCategoriesModel = AutoMapperConfiguration.Mapper.Map<FeaturedCategoriesContainer, StoreFeaturedCategoriesModel>(featuredCategories);

            return featuredCategoriesModel;
        }

        public async Task<StoreFeaturedProductsModel> GetStoreFeaturedProductsAsync()
        {
            var featuredProducts = await CallMethodAsync<FeaturedProductsContainer>("featuredcategories");

            var featuredProductsModel = AutoMapperConfiguration.Mapper.Map<FeaturedProductsContainer, StoreFeaturedProductsModel>(featuredProducts);

            return featuredProductsModel;
        }
    }
}
