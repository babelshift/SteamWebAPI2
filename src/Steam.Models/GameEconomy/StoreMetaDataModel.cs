using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class StoreMetaDataModel
    {
        public StoreCarouselDataModel CarouselData { get; set; }

        public IReadOnlyCollection<StoreTabModel> Tabs { get; set; }

        public IReadOnlyCollection<StoreFilterModel> Filters { get; set; }

        public StoreSortingModel Sorting { get; set; }

        public StoreDropdownDataModel DropdownData { get; set; }

        public IReadOnlyCollection<StorePlayerClassDataModel> PlayerClassData { get; set; }

        public StoreHomePageDataModel HomePageData { get; set; }
    }
}