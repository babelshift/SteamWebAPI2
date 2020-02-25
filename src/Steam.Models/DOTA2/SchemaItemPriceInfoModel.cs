using System;

namespace Steam.Models.DOTA2
{
    public class SchemaItemPriceInfoModel
    {
        public string Bucket { get; set; }

        public string Class { get; set; }

        public string CategoryTags { get; set; }

        public DateTime? Date { get; set; }

        public decimal? Price { get; set; }

        public bool? IsPackItem { get; set; }
    }
}