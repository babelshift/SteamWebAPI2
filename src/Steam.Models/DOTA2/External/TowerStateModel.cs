namespace Steam.Models.DOTA2
{
    public class TowerStateModel
    {
        public TowerStateModel()
        {
        }

        public TowerStateModel(uint towerState)
        {
            IsAncientBottomAlive = ((towerState >> 10) & 1) == 1 ? true : false;
            IsAncientTopAlive = ((towerState >> 9) & 1) == 1 ? true : false;
            IsBottomTier3Alive = ((towerState >> 8) & 1) == 1 ? true : false;
            IsBottomTier2Alive = ((towerState >> 7) & 1) == 1 ? true : false;
            IsBottomTier1Alive = ((towerState >> 6) & 1) == 1 ? true : false;
            IsMiddleTier3Alive = ((towerState >> 5) & 1) == 1 ? true : false;
            IsMiddleTier2Alive = ((towerState >> 4) & 1) == 1 ? true : false;
            IsMiddleTier1Alive = ((towerState >> 3) & 1) == 1 ? true : false;
            IsTopTier3Alive = ((towerState >> 2) & 1) == 1 ? true : false;
            IsTopTier2Alive = ((towerState >> 1) & 1) == 1 ? true : false;
            IsTopTier1Alive = ((towerState >> 0) & 1) == 1 ? true : false;
        }

        public bool IsAncientTopAlive { get; set; }
        public bool IsAncientBottomAlive { get; set; }
        public bool IsBottomTier3Alive { get; set; }
        public bool IsBottomTier2Alive { get; set; }
        public bool IsBottomTier1Alive { get; set; }
        public bool IsMiddleTier3Alive { get; set; }
        public bool IsMiddleTier2Alive { get; set; }
        public bool IsMiddleTier1Alive { get; set; }
        public bool IsTopTier3Alive { get; set; }
        public bool IsTopTier2Alive { get; set; }
        public bool IsTopTier1Alive { get; set; }
    }
}