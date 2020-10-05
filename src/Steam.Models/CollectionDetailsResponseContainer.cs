using System.Collections.Generic;

namespace Steam.Models
{
    public class CollectionDetailsResponseContainer
    {
        public CollectionDetailsResponse Response { get; set; }
    }

    public class CollectionDetailsResponse
    {
        public uint Result { get; set; }
        public uint ResultCount { get; set; }
        public IList<CollectionDetail> CollectionDetails { get; set; }
    }

    public class CollectionDetail
    {
        public string PublishedFileId { get; set; }
        public uint Result { get; set; }
        public IList<CollectionDetailItem> Children { get; set; }
    }

    public class CollectionDetailItem
    {
        public string PublishedFileId { get; set; }
        public uint SortOrder { get; set; }
        public uint FileType { get; set; }
    }
}
