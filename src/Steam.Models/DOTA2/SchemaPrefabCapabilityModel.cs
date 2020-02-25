namespace Steam.Models.DOTA2
{
    public class SchemaPrefabCapabilityModel
    {
        public bool Nameable { get; set; }

        public bool CanHaveSockets { get; set; }

        public bool GemsCanBeExtracted { get; set; }

        public bool CanGiftWrap { get; set; }

        public bool UsableGC { get; set; }

        public bool UsableOutOfGame { get; set; }

        public bool Decodable { get; set; }

        public bool Usable { get; set; }

        public bool IsGem { get; set; }
    }
}