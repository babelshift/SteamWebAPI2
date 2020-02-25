using System.Collections.Generic;

namespace Steam.Models
{
    public class SteamNewsResultModel
    {
        public uint AppId { get; set; }

        public IReadOnlyCollection<NewsItemModel> NewsItems { get; set; }
    }
}