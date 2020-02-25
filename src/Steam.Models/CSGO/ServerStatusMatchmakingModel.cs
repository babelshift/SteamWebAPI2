namespace Steam.Models.CSGO
{
    public class ServerStatusMatchmakingModel
    {
        public string Scheduler { get; set; }

        public uint OnlineServers { get; set; }

        public uint OnlinePlayers { get; set; }

        public uint SearchingPlayers { get; set; }

        public uint SearchSecondsAverage { get; set; }
    }
}