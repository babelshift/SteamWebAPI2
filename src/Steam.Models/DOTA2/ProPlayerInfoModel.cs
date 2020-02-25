namespace Steam.Models.DOTA2
{
    public class ProPlayerInfoModel
    {
        public uint AccountId { get; set; }

        public string Name { get; set; }

        public string CountryCode { get; set; }

        public uint FantasyRole { get; set; }

        public uint TeamId { get; set; }

        public string TeamName { get; set; }

        public string TeamTag { get; set; }

        public bool IsPro { get; set; }

        public string Sponsor { get; set; }
    }
}