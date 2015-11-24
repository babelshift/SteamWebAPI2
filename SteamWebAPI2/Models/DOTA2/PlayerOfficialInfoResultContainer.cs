namespace SteamWebAPI2.Models.DOTA2
{
    public class PlayerOfficialInfoResult
    {
        public string Name { get; set; }
        public string TeamName { get; set; }
        public string TeamTag { get; set; }
        public string Sponsor { get; set; }
        public int FantasyRole { get; set; }
    }

    public class PlayerOfficialInfoResultContainer
    {
        public PlayerOfficialInfoResult Result { get; set; }
    }
}