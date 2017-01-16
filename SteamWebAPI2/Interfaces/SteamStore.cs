using Steam.Models.SteamStore;
using SteamWebAPI2.Models.SteamStore;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamStore : SteamStoreInterface, ISteamStore
    {
        /// <summary>
        /// Maps to the steam store api endpoint: GET http://store.steampowered.com/api/appdetails/
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<StoreAppDetailsDataModel> GetStoreAppDetailsAsync(uint appId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appids");

            var appDetails = await CallMethodAsync<AppDetailsContainer>("appdetails", parameters);

            var appDetailsModel = AutoMapperConfiguration.Mapper.Map<Data, StoreAppDetailsDataModel>(appDetails.Data);

            return appDetailsModel;
        }

        /// <summary>
        /// Maps to the steam store api endpoint: GET http://store.steampowered.com/api/featuredcategories/
        /// </summary>
        /// <returns></returns>
        public async Task<StoreFeaturedCategoriesModel> GetStoreFeaturedCategoriesAsync()
        {
            var featuredCategories = await CallMethodAsync<FeaturedCategoriesContainer>("featuredcategories");

            var featuredCategoriesModel = AutoMapperConfiguration.Mapper.Map<FeaturedCategoriesContainer, StoreFeaturedCategoriesModel>(featuredCategories);

            return featuredCategoriesModel;
        }

        /// <summary>
        /// Maps to the steam store api endpoint: GET http://store.steampowered.com/api/featured/
        /// </summary>
        /// <returns></returns>
        public async Task<StoreFeaturedProductsModel> GetStoreFeaturedProductsAsync()
        {
            var featuredProducts = await CallMethodAsync<FeaturedProductsContainer>("featured");

            var featuredProductsModel = AutoMapperConfiguration.Mapper.Map<FeaturedProductsContainer, StoreFeaturedProductsModel>(featuredProducts);

            return featuredProductsModel;
        }
    }
}