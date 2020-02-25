using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class StoreSortingPrefabModel
    {
        public ulong Id { get; set; }

        public string Name { get; set; }

        public string UrlHistoryParamName { get; set; }

        public IReadOnlyCollection<StoreSorterIdModel> SorterIds { get; set; }
    }
}