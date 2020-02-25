using System;
using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class MatchDetailModel
    {
        public IReadOnlyCollection<MatchPlayerModel> Players { get; set; }

        public bool RadiantWin { get; set; }

        public uint Duration { get; set; }

        public DateTime StartTime { get; set; }

        public ulong MatchId { get; set; }

        public ulong MatchSequenceNumber { get; set; }

        public uint TowerStatusRadiant { get; set; }

        public TowerStateModel TowerStatesRadiant { get { return new TowerStateModel(TowerStatusRadiant); } }

        public uint TowerStatusDire { get; set; }

        public TowerStateModel TowerStatesDire { get { return new TowerStateModel(TowerStatusDire); } }

        public uint BarracksStatusRadiant { get; set; }

        public BarracksStateModel BarracksStatesRadiant { get { return new BarracksStateModel(BarracksStatusRadiant); } }

        public uint BarracksStatusDire { get; set; }

        public BarracksStateModel BarracksStatesDire { get { return new BarracksStateModel(BarracksStatusDire); } }

        public uint Cluster { get; set; }

        public uint FirstBloodTime { get; set; }

        public uint LobbyType { get; set; }

        public uint HumanPlayers { get; set; }

        public uint LeagueId { get; set; }

        public uint PositiveVotes { get; set; }

        public uint NegativeVotes { get; set; }

        public uint GameMode { get; set; }

        public uint Engine { get; set; }

        public uint RadiantTeamId { get; set; }

        public string RadiantName { get; set; }

        public ulong RadiantLogo { get; set; }

        public uint RadiantTeamComplete { get; set; }

        public uint DireTeamId { get; set; }

        public string DireName { get; set; }

        public ulong DireLogo { get; set; }

        public uint DireTeamComplete { get; set; }

        public uint RadiantCaptain { get; set; }

        public uint DireCaptain { get; set; }

        public IReadOnlyCollection<MatchPickBanModel> PicksAndBans { get; set; }
    }
}