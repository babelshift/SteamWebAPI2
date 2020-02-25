namespace Steam.Models.GameEconomy
{
    public class SchemaUsageCapabilitiesModel
    {
        public bool Nameable { get; set; }

        public bool? Decodable { get; set; }

        public bool? Paintable { get; set; }

        public bool? CanCustomizeTexture { get; set; }

        public bool? CanGiftWrap { get; set; }

        public bool? PaintableTeamColors { get; set; }

        public bool? CanStrangify { get; set; }

        public bool? CanKillstreakify { get; set; }

        public bool? DuckUpgradable { get; set; }

        public bool? StrangeParts { get; set; }

        public bool? CanCardUpgrade { get; set; }

        public bool? CanSpellPage { get; set; }

        public bool? CanConsume { get; set; }
    }
}