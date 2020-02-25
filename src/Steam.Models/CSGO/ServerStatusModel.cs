using System.Collections.Generic;

namespace Steam.Models.CSGO
{
    public class ServerStatusModel
    {
        public ServerStatusAppModel App { get; set; }
        public ServerStatusServicesModel Services { get; set; }
        public IReadOnlyCollection<ServerStatusDatacenterModel> Datacenters { get; set; }
        public ServerStatusMatchmakingModel Matchmaking { get; set; }
    }
}