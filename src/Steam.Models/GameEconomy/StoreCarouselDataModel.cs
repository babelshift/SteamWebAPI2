using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class StoreCarouselDataModel
    {
        public uint MaxDisplayBanners { get; set; }

        public IReadOnlyCollection<StoreBannerModel> Banners { get; set; }
    }
}