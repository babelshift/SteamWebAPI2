using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.DOTA2
{
    public class MatchHistoryBySequenceNumberMatchModel
    {
        public IList<MatchHistoryBySequenceNumberMatchPlayerModel> Players { get; set; }
        
        public bool RadiantWin { get; set; }
        
        public uint Duration { get; set; }
        
        public DateTime StartTime { get; set; }
        
        public ulong MatchId { get; set; }
        
        public ulong MatchSequenceNumber { get; set; }

        public TowerState TowerStatesRadiant { get { return new TowerState(TowerStatusRadiant); } }
        
        public uint TowerStatusRadiant { get; set; }

        public TowerState TowerStatesDire { get { return new TowerState(TowerStatusRadiant); } }

        public uint TowerStatusDire { get; set; }

        public BarracksState BarracksStatesRadiant { get { return new BarracksState(BarracksStatusRadiant); } }

        public uint BarracksStatusRadiant { get; set; }

        public BarracksState BarracksStatesDire { get { return new BarracksState(BarracksStatusDire); } }

        public uint BarracksStatusDire { get; set; }
        
        public uint Cluster { get; set; }
        
        public DateTime FirstBloodTime { get; set; }
        
        public uint LobbyType { get; set; }
        
        public uint HumanPlayers { get; set; }
        
        public uint LeagueId { get; set; }
        
        public uint PositiveVotes { get; set; }
        
        public uint NegativeVotes { get; set; }
        
        public uint GameMode { get; set; }
        
        public uint Flags { get; set; }
        
        public uint Engine { get; set; }
        
        public uint RadiantScore { get; set; }
        
        public uint DireScore { get; set; }
    }
}
