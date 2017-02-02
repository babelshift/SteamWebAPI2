namespace SteamWebAPI2.Models.DOTA2
{
    internal class PlayerOfficialInfoResult
    {
        public string Name { get; set; }
        public string TeamName { get; set; }
        public string TeamTag { get; set; }
        public string Sponsor { get; set; }
        public uint FantasyRole { get; set; }
    }

    internal class PlayerOfficialInfoResultContainer
    {
        public PlayerOfficialInfoResult Result { get; set; }
    }
}