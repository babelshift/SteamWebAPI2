using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class FeedData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }

        private List<FeedItem> items = new List<FeedItem>();
        public IList<FeedItem> Items
        {
            get { return items; }
        }
    }

    public class FeedItem
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public Uri Link { get; set; }
    }
}
