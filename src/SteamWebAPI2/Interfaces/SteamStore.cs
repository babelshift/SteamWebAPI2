using Steam.Models.SteamStore;
using SteamWebAPI2.Models.SteamStore;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class SteamStore : SteamStoreInterface, ISteamStore
    {
        public SteamStore(HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        /// Maps to the steam store api endpoint: GET http://store.steampowered.com/api/appdetails/
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public async Task<StoreAppDetailsDataModel> GetStoreAppDetailsAsync(uint appId, string cc = "", string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appids");
            parameters.AddIfHasValue(cc, "cc");
            parameters.AddIfHasValue(language, "l");

            var appDetails = await CallMethodAsync<AppDetailsContainer>("appdetails", parameters);
            var appDetailsData = appDetails?.Data;
            if (appDetailsData == null)
            {
                return null;
            }

            return new StoreAppDetailsDataModel
            {
                Type = appDetailsData.Type,
                Name = appDetailsData.Name,
                SteamAppId = appDetailsData.SteamAppid,
                RequiredAge = appDetailsData.RequiredAge,
                ControllerSupport = appDetailsData.ControllerSupport,
                IsFree = appDetailsData.IsFree,
                Dlc = appDetailsData.Dlc,
                DetailedDescription = appDetailsData.DetailedDescription,
                AboutTheGame = appDetailsData.AboutTheGame,
                ShortDescription = appDetailsData.ShortDescription,
                SupportedLanguages = appDetailsData.SupportedLanguages,
                HeaderImage = appDetailsData.HeaderImage,
                Website = appDetailsData.Website,
                PcRequirements = appDetailsData.PcRequirements,
                MacRequirements = appDetailsData.MacRequirements,
                LinuxRequirements = appDetailsData.LinuxRequirements,
                Developers = appDetailsData.Developers,
                Publishers = appDetailsData.Publishers,
                PriceOverview = appDetailsData.PriceOverview == null ? null : new StorePriceOverview
                {
                    Currency = appDetailsData.PriceOverview.Currency,
                    Initial = appDetailsData.PriceOverview.Initial,
                    Final = appDetailsData.PriceOverview.Final,
                    DiscountPercent = appDetailsData.PriceOverview.DiscountPercent,
                    InitialFormatted = appDetailsData.PriceOverview.InitialFormatted,
                    FinalFormatted = appDetailsData.PriceOverview.FinalFormatted
                },
                Packages = appDetailsData.Packages,
                PackageGroups = appDetailsData.PackageGroups?.Select(pg => new StorePackageGroupModel
                {
                    Name = pg.Name,
                    Title = pg.Title,
                    Description = pg.Description,
                    SelectionText = pg.SelectionText,
                    SaveText = pg.SaveText,
                    DisplayType = pg.DisplayType,
                    IsRecurringSubscription = pg.IsRecurringSubscription,
                    Subs = pg.Subs?.Select(s => new StoreSubModel
                    {
                        PackageId = uint.Parse(s.Packageid),
                        PercentSavingsText = s.PercentSavingsText,
                        PercentSavings = s.PercentSavings,
                        OptionText = s.OptionText,
                        OptionDescription = s.OptionDescription,
                        CanGetFreeLicense = s.CanGetFreeLicense,
                        IsFreeLicense = s.IsFreeLicense,
                        PriceInCentsWithDiscount = s.PriceInCentsWithDiscount
                    }).ToArray()
                }).ToArray(),
                Platforms = appDetailsData.Platforms == null ? null : new StorePlatformsModel
                {
                    Windows = appDetailsData.Platforms.Windows,
                    Mac = appDetailsData.Platforms.Mac,
                    Linux = appDetailsData.Platforms.Linux
                },
                Metacritic = appDetailsData.Metacritic == null ? null : new StoreMetacriticModel
                {
                    Score = appDetailsData.Metacritic.Score,
                    Url = appDetailsData.Metacritic.Url
                },
                Categories = appDetailsData.Categories?.Select(c => new StoreCategoryModel
                {
                    Id = c.Id,
                    Description = c.Description
                }).ToArray(),
                Genres = appDetailsData.Genres?.Select(g => new StoreGenreModel
                {
                    Id = g.Id,
                    Description = g.Description
                }).ToArray(),
                Screenshots = appDetailsData.Screenshots?.Select(s => new StoreScreenshotModel
                {
                    Id = s.Id,
                    PathThumbnail = s.PathThumbnail,
                    PathFull = s.PathFull
                }).ToArray(),
                Movies = appDetailsData.Movies?.Select(m => new StoreMovieModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Thumbnail = m.Thumbnail,
                    Webm = m.Webm == null ? null : new StoreWebmModel
                    {
                        Resolution480 = m.Webm.Resolution480,
                        Max = m.Webm.Max
                    },
                    Highlight = m.Highlight
                }).ToArray(),
                Recommendations = appDetailsData.Recommendations == null ? null : new StoreRecommendationsModel
                {
                    Total = appDetailsData.Recommendations.Total
                },
                Achievements = appDetailsData.Achievements == null ? null : new StoreAchievement
                {
                    Total = appDetailsData.Achievements.Total,
                    Highlighted = appDetailsData.Achievements.Highlighted?.Select(h => new StoreHighlighted
                    {
                        Name = h.Name,
                        Path = h.Path
                    }).ToArray()
                },
                ReleaseDate = appDetailsData.ReleaseDate == null ? null : new StoreReleaseDateModel
                {
                    ComingSoon = appDetailsData.ReleaseDate.ComingSoon,
                    Date = appDetailsData.ReleaseDate.Date
                },
                SupportInfo = appDetailsData.SupportInfo == null ? null : new StoreSupportInfoModel
                {
                    Url = appDetailsData.SupportInfo.Url,
                    Email = appDetailsData.SupportInfo.Email
                },
                Background = appDetailsData.Background,
                ContentDescriptors = appDetailsData.ContentDescriptors == null ? null : new StoreContentDescriptor
                {
                    Ids = appDetailsData.ContentDescriptors.Ids,
                    Notes = appDetailsData.ContentDescriptors.Notes
                }
            };
        }

        /// <summary>
        /// Maps to the steam store api endpoint: GET http://store.steampowered.com/api/featuredcategories/
        /// </summary>
        /// <returns></returns>
        public async Task<StoreFeaturedCategoriesModel> GetStoreFeaturedCategoriesAsync()
        {
            var featuredCategories = await CallMethodAsync<FeaturedCategoriesContainer>("featuredcategories");
            if (featuredCategories == null)
            {
                return null;
            }

            return new StoreFeaturedCategoriesModel
            {
                Specials = featuredCategories.Specials == null ? null : new StoreSpecialsModel
                {
                    Id = uint.Parse(featuredCategories.Specials.Id),
                    Name = featuredCategories.Specials.Name,
                    Items = MapStoreItemModels(featuredCategories.Specials.Items)
                },
                ComingSoon = featuredCategories.ComingSoon == null ? null : new StoreComingSoonModel
                {
                    Id = uint.Parse(featuredCategories.ComingSoon.Id),
                    Name = featuredCategories.ComingSoon.Name,
                    Items = MapStoreItemModels(featuredCategories.ComingSoon.Items)
                },
                TopSellers = featuredCategories.TopSellers == null ? null : new StoreTopSellersModel
                {
                    Id = uint.Parse(featuredCategories.TopSellers.Id),
                    Name = featuredCategories.TopSellers.Name,
                    Items = MapStoreItemModels(featuredCategories.TopSellers.Items)
                },
                NewReleases = featuredCategories.NewReleases == null ? null : new StoreNewReleasesModel
                {
                    Id = uint.Parse(featuredCategories.NewReleases.Id),
                    Name = featuredCategories.NewReleases.Name,
                    Items = MapStoreItemModels(featuredCategories.NewReleases.Items)
                },
                Genres = featuredCategories.Genres == null ? null : new StoreFeaturedCategoryGenreModel
                {
                    Id = uint.Parse(featuredCategories.Genres.Id),
                    Name = featuredCategories.Genres.Name
                },
                Trailerslideshow = featuredCategories.TrailerSlideshow == null ? null : new StoreTrailerSlideshowModel
                {
                    Id = uint.Parse(featuredCategories.TrailerSlideshow.Id),
                    Name = featuredCategories.TrailerSlideshow.Name
                },
                Status = featuredCategories.Status
            };
        }

        /// <summary>
        /// Maps to the steam store api endpoint: GET http://store.steampowered.com/api/featured/
        /// </summary>
        /// <returns></returns>
        public async Task<StoreFeaturedProductsModel> GetStoreFeaturedProductsAsync()
        {
            var featuredProducts = await CallMethodAsync<FeaturedProductsContainer>("featured");
            if(featuredProducts == null)
            {
                return null;
            }

            return new StoreFeaturedProductsModel
            {
                FeaturedLinux = featuredProducts.FeaturedLinux.Select(x => new StoreFeaturedLinuxModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    Name = x.Name,
                    Discounted = x.Discounted,
                    DiscountPercent = x.DiscountPercent,
                    OriginalPrice = x.OriginalPrice,
                    FinalPrice = x.FinalPrice,
                    Currency = x.Currency,
                    LargeCapsuleImage = x.LargeCapsuleImage,
                    SmallCapsuleImage = x.SmallCapsuleImage,
                    WindowsAvailable = x.WindowsAvailable,
                    MacAvailable = x.MacAvailable,
                    LinuxAvailable = x.LinuxAvailable,
                    StreamingvideoAvailable = x.StreamingvideoAvailable,
                    HeaderImage = x.HeaderImage,
                    ControllerSupport = x.ControllerSupport
                }).ToArray(),
                FeaturedMac = featuredProducts.FeaturedMac.Select(x => new StoreFeaturedMacModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    Name = x.Name,
                    Discounted = x.Discounted,
                    DiscountPercent = x.DiscountPercent,
                    OriginalPrice = x.OriginalPrice,
                    FinalPrice = x.FinalPrice,
                    Currency = x.Currency,
                    LargeCapsuleImage = x.LargeCapsuleImage,
                    SmallCapsuleImage = x.SmallCapsuleImage,
                    WindowsAvailable = x.WindowsAvailable,
                    MacAvailable = x.MacAvailable,
                    LinuxAvailable = x.LinuxAvailable,
                    StreamingvideoAvailable = x.StreamingvideoAvailable,
                    HeaderImage = x.HeaderImage,
                    ControllerSupport = x.ControllerSupport
                }).ToArray(),
                FeaturedWin = featuredProducts.FeaturedWin.Select(x => new StoreFeaturedWinModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    Name = x.Name,
                    Discounted = x.Discounted,
                    DiscountPercent = x.DiscountPercent,
                    OriginalPrice = x.OriginalPrice,
                    FinalPrice = x.FinalPrice,
                    Currency = x.Currency,
                    LargeCapsuleImage = x.LargeCapsuleImage,
                    SmallCapsuleImage = x.SmallCapsuleImage,
                    WindowsAvailable = x.WindowsAvailable,
                    MacAvailable = x.MacAvailable,
                    LinuxAvailable = x.LinuxAvailable,
                    StreamingvideoAvailable = x.StreamingvideoAvailable,
                    HeaderImage = x.HeaderImage,
                    ControllerSupport = x.ControllerSupport,
                    DiscountExpiration = x.DiscountExpiration
                }).ToArray(),
                LargeCapsules = featuredProducts.LargeCapsules.Select(x => new StoreLargeCapsuleModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    Name = x.Name,
                    Discounted = x.Discounted,
                    DiscountPercent = x.DiscountPercent,
                    OriginalPrice = x.OriginalPrice,
                    FinalPrice = x.FinalPrice,
                    Currency = x.Currency,
                    LargeCapsuleImage = x.LargeCapsuleImage,
                    SmallCapsuleImage = x.SmallCapsuleImage,
                    WindowsAvailable = x.WindowsAvailable,
                    MacAvailable = x.MacAvailable,
                    LinuxAvailable = x.LinuxAvailable,
                    StreamingvideoAvailable = x.StreamingvideoAvailable,
                    HeaderImage = x.HeaderImage,
                    ControllerSupport = x.ControllerSupport,
                    Headline = x.Headline
                }).ToArray(),
                Layout = featuredProducts.Layout,
                Status = featuredProducts.Status
            };
        }

        private StoreItemModel[] MapStoreItemModels(Item[] items)
        {
            return items?.Select(i => new StoreItemModel
            {
                Id = i.Id,
                Type = i.Type,
                Name = i.Name,
                Discounted = i.Discounted,
                DiscountPercent = i.DiscountPercent,
                OriginalPrice = i.OriginalPrice,
                FinalPrice = i.FinalPrice,
                Currency = i.Currency,
                LargeCapsuleImage = i.LargeCapsuleImage,
                SmallCapsuleImage = i.SmallCapsuleImage,
                WindowsAvailable = i.WindowsAvailable,
                MacAvailable = i.MacAvailable,
                LinuxAvailable = i.LinuxAvailable,
                StreamingvideoAvailable = i.StreamingvideoAvailable,
                DiscountExpiration = i.DiscountExpiration,
                HeaderImage = i.HeaderImage,
                Body = i.Body,
                Url = i.Url
            }).ToArray();
        }
    }
}