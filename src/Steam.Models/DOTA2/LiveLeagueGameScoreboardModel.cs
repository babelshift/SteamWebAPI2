namespace Steam.Models.DOTA2
{
    public class LiveLeagueGameScoreboardModel
    {
        public double Duration { get; set; }

        public uint RoshanRespawnTimer { get; set; }

        public LiveLeagueGameTeamRadiantDetailModel Radiant { get; set; }
        public LiveLeagueGameTeamDireDetailModel Dire { get; set; }
    }
}