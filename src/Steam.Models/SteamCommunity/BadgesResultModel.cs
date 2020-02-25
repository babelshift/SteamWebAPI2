using System.Collections.Generic;

namespace Steam.Models.SteamCommunity
{
    public class BadgesResultModel
    {
        public IReadOnlyCollection<BadgeModel> Badges { get; set; }

        public uint PlayerXp { get; set; }

        public uint PlayerLevel { get; set; }

        public uint PlayerXpNeededToLevelUp { get; set; }

        public uint PlayerXpNeededCurrentLevel { get; set; }
    }
}