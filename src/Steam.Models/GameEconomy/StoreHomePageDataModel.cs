using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class StoreHomePageDataModel
    {
        public uint HomeCategoryId { get; set; }

        public IReadOnlyCollection<StorePopularItemModel> PopularItems { get; set; }
    }
}