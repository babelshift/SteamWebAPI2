using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class LiveLeagueGameTeamDireDetailModel
    {
        public uint Score { get; set; }

        public uint TowerState { get; set; }

        public uint BarracksState { get; set; }

        public IReadOnlyCollection<LiveLeagueGamePickModel> Picks { get; set; }
        public IReadOnlyCollection<LiveLeagueGameBanModel> Bans { get; set; }
        public IReadOnlyCollection<LiveLeagueGamePlayerDetailModel> Players { get; set; }
        public IReadOnlyCollection<LiveLeagueGameAbilityModel> Abilities { get; set; }

        public TowerStateModel TowerStates { get { return new TowerStateModel(TowerState); } }
    }
}