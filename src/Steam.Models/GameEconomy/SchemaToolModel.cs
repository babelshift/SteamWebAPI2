using Steam.Models.DOTA2;

namespace Steam.Models.GameEconomy
{
    public class SchemaToolModel
    {
        public string Type { get; set; }

        public SchemaUsageCapabilitiesModel UsageCapabilities { get; set; }

        public SchemaItemToolUsageModel Usage { get; set; }

        public string UseString { get; set; }

        public string Restriction { get; set; }
    }
}