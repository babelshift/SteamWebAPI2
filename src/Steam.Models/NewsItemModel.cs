namespace Steam.Models
{
    public class NewsItemModel
    {
        public string Gid { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public bool IsExternalUrl { get; set; }

        public string Author { get; set; }

        public string Contents { get; set; }

        public string FeedLabel { get; set; }

        public ulong Date { get; set; }

        public string Feedname { get; set; }
    }
}