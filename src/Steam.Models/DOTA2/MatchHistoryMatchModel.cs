using System;
using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class MatchHistoryMatchModel
    {
        public ulong MatchId { get; set; }

        public ulong MatchSequenceNumber { get; set; }

        public DateTime StartTime { get; set; }

        public uint LobbyType { get; set; }

        public uint RadiantTeamId { get; set; }

        public uint DireTeamId { get; set; }

        public IReadOnlyCollection<MatchHistoryPlayerModel> Players { get; set; }
    }
}