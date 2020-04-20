
using AutoMapper;
using Steam.Models.SteamStore;
using SteamWebAPI2.Models.SteamStore;

namespace SteamWebAPI2.Mappings
{
    public class SteamStoreProfile : Profile
    {
        public SteamStoreProfile()
        {
            CreateMap<Data, StoreAppDetailsDataModel>();
            CreateMap<SupportInfo, StoreSupportInfoModel>();
            CreateMap<ReleaseDate, StoreReleaseDateModel>();
            CreateMap<Recommendations, StoreRecommendationsModel>();
            CreateMap<Movie, StoreMovieModel>();
            CreateMap<Webm, StoreWebmModel>();
            CreateMap<Screenshot, StoreScreenshotModel>();
            CreateMap<Genre, StoreGenreModel>();
            CreateMap<Category, StoreCategoryModel>();
            CreateMap<Metacritic, StoreMetacriticModel>();
            CreateMap<Platforms, StorePlatformsModel>();
            CreateMap<PackageGroup, StorePackageGroupModel>();
            CreateMap<Price, StorePriceOverview>();
            CreateMap<Sub, StoreSubModel>();
            CreateMap<Achievement, StoreAchievement>();
            CreateMap<Highlighted, StoreHighlighted>();
            CreateMap<ContentDescriptor, StoreContentDescriptor>();

            CreateMap<FeaturedCategoriesContainer, StoreFeaturedCategoriesModel>();
            CreateMap<TrailerSlideshow, StoreTrailerSlideshowModel>();
            CreateMap<Genres, StoreFeaturedCategoryGenreModel>();
            CreateMap<NewReleases, StoreNewReleasesModel>();
            CreateMap<TopSellers, StoreTopSellersModel>();
            CreateMap<ComingSoon, StoreComingSoonModel>();
            CreateMap<Specials, StoreSpecialsModel>();
            CreateMap<Item, StoreItemModel>();

            CreateMap<FeaturedProductsContainer, StoreFeaturedProductsModel>();
            CreateMap<FeaturedLinux, StoreFeaturedLinuxModel>();
            CreateMap<FeaturedMac, StoreFeaturedMacModel>();
            CreateMap<FeaturedWin, StoreFeaturedWinModel>();
            CreateMap<LargeCapsule, StoreLargeCapsuleModel>();
        }
    }
}