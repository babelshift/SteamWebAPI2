using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class AppNews
    {
        public int AppID { get; set; }
        public IList<NewsItem> NewsItems { get; set; }

        public AppNews()
        {
            NewsItems = new List<NewsItem>();
        }
    }

    public class NewsItem
    {
        public string GID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public bool IsExternalUrl { get; set; }
        public string Author { get; set; }
        public string Contents { get; set; }
        public string FeedLabel { get; set; }
        public DateTime Date { get; set; }
        public string FeedName { get; set; }
    }
}
