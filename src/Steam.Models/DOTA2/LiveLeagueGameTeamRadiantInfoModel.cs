namespace Steam.Models.DOTA2
{
    public class LiveLeagueGameTeamRadiantInfoModel
    {
        public string TeamName { get; set; }

        public uint TeamId { get; set; }

        public ulong TeamLogo { get; set; }

        public bool Complete { get; set; }
    }
}