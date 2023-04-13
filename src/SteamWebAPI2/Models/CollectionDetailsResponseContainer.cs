using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models
{
    public class CollectionDetailsResponseContainer
    {
        [JsonProperty("response")]
        public CollectionDetailsResponse Response { get; set; }
    }

    public class CollectionDetailsResponse
    {
        [JsonProperty("result")]
        public uint Result { get; set; }

        [JsonProperty("resultcount")]
        public uint ResultCount { get; set; }

        [JsonProperty("collectiondetails")]
        public IList<CollectionDetail> CollectionDetails { get; set; }
    }

    public class CollectionDetail
    {
        [JsonProperty("publishedfileid")]
        public string PublishedFileId { get; set; }

        [JsonProperty("result")]
        public uint Result { get; set; }

        [JsonProperty("children")]
        public IList<CollectionDetailItem> Children { get; set; }
    }

    public class CollectionDetailItem
    {
        [JsonProperty("publishedfileid")]
        public string PublishedFileId { get; set; }

        [JsonProperty("sortorder")]
        public uint SortOrder { get; set; }

        [JsonProperty("filetype")]
        public uint FileType { get; set; }
    }
}
