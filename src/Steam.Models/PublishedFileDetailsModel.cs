using System;
using System.Collections.Generic;

namespace Steam.Models
{
    public class PublishedFileDetailsModel
    {
        public ulong PublishedFileId { get; set; }

        public uint Result { get; set; }

        public ulong Creator { get; set; }

        public uint CreatorAppId { get; set; }

        public uint ConsumerAppId { get; set; }

        public string FileName { get; set; }

        public uint FileSize { get; set; }

        public Uri FileUrl { get; set; }

        public ulong FileContentHandle { get; set; }

        public Uri PreviewUrl { get; set; }

        public ulong PreviewContentHandle { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime TimeCreated { get; set; }

        public DateTime TimeUpdated { get; set; }

        public PublishedFileVisibility Visibility { get; set; }

        public bool Banned { get; set; }

        public string BanReason { get; set; }

        public ulong Subscriptions { get; set; }

        public ulong Favorited { get; set; }

        public ulong LifetimeSubscriptions { get; set; }

        public ulong LifetimeFavorited { get; set; }

        public ulong Views { get; set; }

        public IList<string> Tags { get; set; }
    }
}
