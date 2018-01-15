using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace SteamWebAPI2.Models
{
    using SteamWebAPI2.Utilities.JsonConverters;

    internal class PublishedFileDetailsResultContainer
    {
        [JsonProperty("response")]
        public PublishedFileDetailsResult Result { get; set; }
    }

    internal class PublishedFileDetailsResult
    {
        [JsonProperty("result")]
        public uint Result { get; set; }

        [JsonProperty("resultcount")]
        public uint Count { get; set; }

        [JsonProperty("publishedfiledetails")]
        public IList<PublishedFileDetails> Details { get; set; }
    }

    internal class PublishedFileDetails
    {
        [JsonProperty("publishedfileid")]
        public ulong PublishedFileId { get; set; }

        [JsonProperty("result")]
        public uint Result { get; set; }

        [JsonProperty("creator")]
        public ulong Creator { get; set; }

        [JsonProperty("creator_app_id")]
        public uint CreatorAppId { get; set; }

        [JsonProperty("consumer_app_id")]
        public uint ConsumerAppId { get; set; }

        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("file_size")]
        public uint FileSize { get; set; }

        [JsonProperty("file_url")]
        public string FileUrl { get; set; }

        [JsonProperty("hcontent_file")]
        public ulong FileContentHandle { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("hcontent_preview")]
        public ulong PreviewContentHandle { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("time_created")]
        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTime TimeCreated { get; set; }

        [JsonProperty("time_updated")]
        [JsonConverter(typeof(UnixTimeJsonConverter))]
        public DateTime TimeUpdated { get; set; }

        [JsonProperty("visibility")]
        public uint Visibility { get; set; }

        [JsonProperty("banned")]
        public bool Banned { get; set; }

        [JsonProperty("ban_reason")]
        public string BanReason { get; set; }

        [JsonProperty("subscriptions")]
        public ulong Subscriptions { get; set; }

        [JsonProperty("favorited")]
        public ulong Favorited { get; set; }

        [JsonProperty("lifetime_subscriptions")]
        public ulong LifetimeSubscriptions { get; set; }

        [JsonProperty("lifetime_favorited")]
        public ulong LifetimeFavorited { get; set; }

        [JsonProperty("views")]
        public ulong Views { get; set; }

        [JsonProperty("tags")]
        [JsonConverter(typeof(TagsJsonConverter))]
        public IList<string> Tags { get; set; }
    }
}
