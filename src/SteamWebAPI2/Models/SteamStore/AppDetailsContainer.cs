using Newtonsoft.Json;
using SteamWebAPI2.Utilities.JsonConverters;

namespace SteamWebAPI2.Models.SteamStore
{
    internal class Sub
    {
        [JsonProperty("packageid")]
        public string Packageid { get; set; }

        [JsonProperty("percent_savings_text")]
        public string PercentSavingsText { get; set; }

        [JsonProperty("percent_savings")]
        public uint PercentSavings { get; set; }

        [JsonProperty("option_text")]
        public string OptionText { get; set; }

        [JsonProperty("option_description")]
        public string OptionDescription { get; set; }

        [JsonProperty("can_get_free_license")]
        public string CanGetFreeLicense { get; set; }

        [JsonProperty("is_free_license")]
        public bool IsFreeLicense { get; set; }

        [JsonProperty("price_in_cents_with_discount")]
        public uint PriceInCentsWithDiscount { get; set; }
    }

    internal class PackageGroup
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("selection_text")]
        public string SelectionText { get; set; }

        [JsonProperty("save_text")]
        public string SaveText { get; set; }

        [JsonProperty("display_type")]
        public uint DisplayType { get; set; }

        [JsonProperty("is_recurring_subscription")]
        public string IsRecurringSubscription { get; set; }

        [JsonProperty("subs")]
        public Sub[] Subs { get; set; }
    }

    internal class Platforms
    {
        [JsonProperty("windows")]
        public bool Windows { get; set; }

        [JsonProperty("mac")]
        public bool Mac { get; set; }

        [JsonProperty("linux")]
        public bool Linux { get; set; }
    }

    internal class Metacritic
    {
        [JsonProperty("score")]
        public uint Score { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    internal class Category
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    internal class Genre
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    internal class Screenshot
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("path_thumbnail")]
        public string PathThumbnail { get; set; }

        [JsonProperty("path_full")]
        public string PathFull { get; set; }
    }

    internal class Webm
    {
        [JsonProperty("480")]
        public string Resolution480 { get; set; }

        [JsonProperty("max")]
        public string Max { get; set; }
    }

    internal class Movie
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("webm")]
        public Webm Webm { get; set; }

        [JsonProperty("highlight")]
        public bool Highlight { get; set; }
    }

    internal class Recommendations
    {
        [JsonProperty("total")]
        public uint Total { get; set; }
    }

    internal class ReleaseDate
    {
        [JsonProperty("coming_soon")]
        public bool ComingSoon { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }

    internal class SupportInfo
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }

    internal class Data
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("steam_appid")]
        public uint SteamAppid { get; set; }

        [JsonProperty("required_age")]
        public uint RequiredAge { get; set; }

        [JsonProperty("is_free")]
        public bool IsFree { get; set; }

        [JsonProperty("dlc")]
        public uint[] Dlc { get; set; }

        [JsonProperty("detailed_description")]
        public string DetailedDescription { get; set; }

        [JsonProperty("about_the_game")]
        public string AboutTheGame { get; set; }

        [JsonProperty("supported_languages")]
        public string SupportedLanguages { get; set; }

        [JsonProperty("header_image")]
        public string HeaderImage { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("pc_requirements")]
        public dynamic PcRequirements { get; set; }

        [JsonProperty("mac_requirements")]
        public dynamic MacRequirements { get; set; }

        [JsonProperty("linux_requirements")]
        public dynamic LinuxRequirements { get; set; }

        [JsonProperty("developers")]
        public string[] Developers { get; set; }

        [JsonProperty("publishers")]
        public string[] Publishers { get; set; }

        [JsonProperty("packages")]
        public string[] Packages { get; set; }

        [JsonProperty("package_groups")]
        public PackageGroup[] PackageGroups { get; set; }

        [JsonProperty("platforms")]
        public Platforms Platforms { get; set; }

        [JsonProperty("metacritic")]
        public Metacritic Metacritic { get; set; }

        [JsonProperty("categories")]
        public Category[] Categories { get; set; }

        [JsonProperty("genres")]
        public Genre[] Genres { get; set; }

        [JsonProperty("screenshots")]
        public Screenshot[] Screenshots { get; set; }

        [JsonProperty("movies")]
        public Movie[] Movies { get; set; }

        [JsonProperty("recommendations")]
        public Recommendations Recommendations { get; set; }

        [JsonProperty("release_date")]
        public ReleaseDate ReleaseDate { get; set; }

        [JsonProperty("support_info")]
        public SupportInfo SupportInfo { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }
    }

    [JsonConverter(typeof(StoreAppDetailsContainerJsonConverter))]
    internal class AppDetailsContainer
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}