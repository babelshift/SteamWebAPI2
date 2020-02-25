using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class EconItemModel
    {
        public ulong Id { get; set; }

        public ulong OriginalId { get; set; }

        public uint DefIndex { get; set; }
        public uint Level { get; set; }
        public uint Quality { get; set; }
        public ulong Inventory { get; set; }
        public uint Quantity { get; set; }
        public uint Origin { get; set; }
        public IReadOnlyCollection<EconItemEquippedModel> Equipped { get; set; }
        public uint Style { get; set; }
        public IReadOnlyCollection<EconItemAttributeModel> Attributes { get; set; }

        public bool? FlagCannotTrade { get; set; }

        public bool? FlagCannotCraft { get; set; }
    }
}