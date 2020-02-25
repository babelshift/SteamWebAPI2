using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class StoreTabModel
    {
        public string Label { get; set; }

        public uint Id { get; set; }

        public uint ParentId { get; set; }

        public bool UseLargeCells { get; set; }

        public bool Default { get; set; }

        public IReadOnlyCollection<StoreTabChildModel> Children { get; set; }

        public bool Home { get; set; }

        public ulong? DropdownPrefabId { get; set; }

        public string ParentName { get; set; }
    }
}