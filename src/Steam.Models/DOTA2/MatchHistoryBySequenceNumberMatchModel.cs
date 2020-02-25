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

        public TowerStateModel TowerStatesRadiant { get { return new TowerStateModel(TowerStatusRadiant); } }
        
        public uint TowerStatusRadiant { get; set; }

        public TowerStateModel TowerStatesDire { get { return new TowerStateModel(TowerStatusRadiant); } }

        public uint TowerStatusDire { get; set; }

        public BarracksStateModel BarracksStatesRadiant { get { return new BarracksStateModel(BarracksStatusRadiant); } }

        public uint BarracksStatusRadiant { get; set; }

        public BarracksStateModel BarracksStatesDire { get { return new BarracksStateModel(BarracksStatusDire); } }

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
