namespace Steam.Models.DOTA2
{
    public class SchemaPrefab
    {
        public string Type { get; set; }

        public string TypeName { get; set; }

        public string Class { get; set; }

        public string Name { get; set; }

        public string Slot { get; set; }

        public string Quality { get; set; }

        public string Rarity { get; set; }

        public string MinItemLevel { get; set; }

        public string MaxItemLevel { get; set; }

        public string ImageInventorySizeWidth { get; set; }

        public string ImageInventorySizeHeight { get; set; }

        public SchemaPrefabCapability Capabilities { get; set; }
    }
}