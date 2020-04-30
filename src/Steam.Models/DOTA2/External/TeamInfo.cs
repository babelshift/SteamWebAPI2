using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class TeamInfo
    {
        public uint TeamId { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public ulong TimeCreated { get; set; }
        public string Rating { get; set; }
        public ulong Logo { get; set; }
        public ulong LogoSponsor { get; set; }
        public string CountryCode { get; set; }
        public string Url { get; set; }
        public uint GamesPlayedWithCurrentRoster { get; set; }
        public uint AdminAccountId { get; set; }
        public IReadOnlyCollection<uint> PlayerIds { get; set; }
        public IReadOnlyCollection<uint> LeagueIds { get; set; }
    }
}