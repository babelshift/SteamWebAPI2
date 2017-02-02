using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.GameEconomy
{
    internal class StoreBanner
    {
        [JsonProperty("basefilename")]
        public string BaseFileName { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("placement")]
        public string Placement { get; set; }

        [JsonProperty("action_param")]
        public string ActionParam { get; set; }
    }

    internal class StoreCarouselData
    {
        [JsonProperty("max_display_banners")]
        public uint MaxDisplayBanners { get; set; }

        [JsonProperty("banners")]
        public IList<StoreBanner> Banners { get; set; }
    }

    internal class StoreTabChild
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public uint Id { get; set; }
    }

    internal class StoreTab
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("parent_id")]
        public uint ParentId { get; set; }

        [JsonProperty("use_large_cells")]
        public bool UseLargeCells { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }

        [JsonProperty("children")]
        public IList<StoreTabChild> Children { get; set; }

        [JsonProperty("home")]
        public bool Home { get; set; }

        [JsonProperty("dropdown_prefab_id")]
        public ulong? DropdownPrefabId { get; set; }

        [JsonProperty("parent_name")]
        public string ParentName { get; set; }
    }

    internal class StoreFilterAllElement
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("localized_text")]
        public string LocalizedText { get; set; }
    }

    internal class StoreFilterElement
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("localized_text")]
        public string LocalizedText { get; set; }
    }

    internal class StoreFilter
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url_history_param_name")]
        public string UrlHistoryParamName { get; set; }

        [JsonProperty("all_element")]
        public StoreFilterAllElement AllElement { get; set; }

        [JsonProperty("elements")]
        public IList<StoreFilterElement> Elements { get; set; }

        [JsonProperty("count")]
        public uint Count { get; set; }
    }

    internal class StoreSorter
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("data_type")]
        public string DataType { get; set; }

        [JsonProperty("sort_field")]
        public string SortField { get; set; }

        [JsonProperty("sort_reversed")]
        public bool SortReversed { get; set; }

        [JsonProperty("localized_text")]
        public string LocalizedText { get; set; }
    }

    internal class StoreSorterId
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }
    }

    internal class StoreSortingPrefab
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url_history_param_name")]
        public string UrlHistoryParamName { get; set; }

        [JsonProperty("sorter_ids")]
        public IList<StoreSorterId> SorterIds { get; set; }
    }

    internal class StoreSorting
    {
        [JsonProperty("sorters")]
        public IList<StoreSorter> Sorters { get; set; }

        [JsonProperty("sorting_prefabs")]
        public IList<StoreSortingPrefab> SortingPrefabs { get; set; }
    }

    internal class StoreDropdown
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label_text")]
        public string LabelText { get; set; }

        [JsonProperty("url_history_param_name")]
        public string UrlHistoryParamName { get; set; }
    }

    internal class StoreConfig
    {
        [JsonProperty("dropdown_id")]
        public ulong DropdownId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("default_selection_id")]
        public uint DefaultSelectionId { get; set; }
    }

    internal class StorePrefab
    {
        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("config")]
        public IList<StoreConfig> Config { get; set; }
    }

    internal class StoreDropdownData
    {
        [JsonProperty("dropdowns")]
        public IList<StoreDropdown> Dropdowns { get; set; }

        [JsonProperty("prefabs")]
        public IList<StorePrefab> Prefabs { get; set; }
    }

    internal class StorePlayerClassData
    {
        [JsonProperty("id")]
        public uint Id { get; set; }

        [JsonProperty("base_name")]
        public string BaseName { get; set; }

        [JsonProperty("localized_text")]
        public string LocalizedText { get; set; }
    }

    internal class StorePopularItem
    {
        [JsonProperty("def_index")]
        public uint DefIndex { get; set; }

        [JsonProperty("order")]
        public uint Order { get; set; }
    }

    internal class StoreHomePageData
    {
        [JsonProperty("home_category_id")]
        public uint HomeCategoryId { get; set; }

        [JsonProperty("popular_items")]
        public IList<StorePopularItem> PopularItems { get; set; }
    }

    internal class StoreMetaDataResult
    {
        [JsonProperty("carousel_data")]
        public StoreCarouselData CarouselData { get; set; }

        [JsonProperty("tabs")]
        public IList<StoreTab> Tabs { get; set; }

        [JsonProperty("filters")]
        public IList<StoreFilter> Filters { get; set; }

        [JsonProperty("sorting")]
        public StoreSorting Sorting { get; set; }

        [JsonProperty("dropdown_data")]
        public StoreDropdownData DropdownData { get; set; }

        [JsonProperty("player_class_data")]
        public IList<StorePlayerClassData> PlayerClassData { get; set; }

        [JsonProperty("home_page_data")]
        public StoreHomePageData HomePageData { get; set; }
    }

    internal class StoreMetaDataResultContainer
    {
        [JsonProperty("result")]
        public StoreMetaDataResult Result { get; set; }
    }
}