namespace Steam.Models.DOTA2
{
    public class Rarity
    {
        public string Name { get; set; }
        
        public uint Id { get; set; }

        public uint Order { get; set; }

        public string Color { get; set; }

        public string LocalizedName { get; set; }
    }
}