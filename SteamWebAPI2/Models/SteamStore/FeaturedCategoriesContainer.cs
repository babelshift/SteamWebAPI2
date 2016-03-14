using Newtonsoft.Json;

namespace SteamWebAPI2.Models.SteamStore
{
    internal class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("discounted")]
        public bool Discounted { get; set; }

        [JsonProperty("discount_percent")]
        public int DiscountPercent { get; set; }

        [JsonProperty("original_price")]
        public int? OriginalPrice { get; set; }

        [JsonProperty("final_price")]
        public int FinalPrice { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("large_capsule_image")]
        public string LargeCapsuleImage { get; set; }

        [JsonProperty("small_capsule_image")]
        public string SmallCapsuleImage { get; set; }

        [JsonProperty("windows_available")]
        public bool WindowsAvailable { get; set; }

        [JsonProperty("mac_available")]
        public bool MacAvailable { get; set; }

        [JsonProperty("linux_available")]
        public bool LinuxAvailable { get; set; }

        [JsonProperty("streamingvideo_available")]
        public bool StreamingvideoAvailable { get; set; }

        [JsonProperty("discount_expiration")]
        public int DiscountExpiration { get; set; }

        [JsonProperty("header_image")]
        public string HeaderImage { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    internal class Specials
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    internal class ComingSoon
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    internal class TopSellers
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    internal class NewReleases
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    internal class Genres
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    internal class TrailerSlideshow
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    internal class FeaturedCategoriesContainer
    {
        [JsonProperty("specials")]
        public Specials Specials { get; set; }

        [JsonProperty("coming_soon")]
        public ComingSoon ComingSoon { get; set; }

        [JsonProperty("top_sellers")]
        public TopSellers TopSellers { get; set; }

        [JsonProperty("new_releases")]
        public NewReleases NewReleases { get; set; }

        [JsonProperty("genres")]
        public Genres Genres { get; set; }

        [JsonProperty("trailerslideshow")]
        public TrailerSlideshow TrailerSlideshow { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }
}