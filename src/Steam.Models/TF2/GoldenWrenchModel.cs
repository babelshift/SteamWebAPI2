using System;

namespace Steam.Models.TF2
{
    public class GoldenWrenchModel
    {
        public ulong SteamId { get; set; }

        public DateTime Timestamp { get; set; }

        public uint ItemId { get; set; }

        public uint WrenchNumber { get; set; }
    }
}