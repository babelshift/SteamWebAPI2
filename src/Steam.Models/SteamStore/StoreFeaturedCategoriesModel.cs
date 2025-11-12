namespace Steam.Models.SteamStore
{
    public class StoreFeaturedCategoriesModel
    {
        public StoreSpecialsModel Specials { get; set; }

        public StoreComingSoonModel ComingSoon { get; set; }

        public StoreTopSellersModel TopSellers { get; set; }

        public StoreNewReleasesModel NewReleases { get; set; }

        public StoreFeaturedCategoryGenreModel Genres { get; set; }

        public StoreTrailerSlideshowModel Trailerslideshow { get; set; }

        public uint Status { get; set; }
    }
}
