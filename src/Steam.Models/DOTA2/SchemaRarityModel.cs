namespace Steam.Models.DOTA2
{
    public class SchemaRarityModel
    {
        public string Name { get; set; }

        public uint Value { get; set; }

        public string LocKey { get; set; }

        public string Color { get; set; }

        public string NextRarity { get; set; }
    }
}