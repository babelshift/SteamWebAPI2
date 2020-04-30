using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class Schema
    {
        public SchemaGameInfo GameInfo { get; set; }

        public IList<SchemaRarity> Rarities { get; set; }

        public IList<SchemaQuality> Qualities { get; set; }

        public IList<SchemaColor> Colors { get; set; }

        public IList<SchemaPrefab> Prefabs { get; set; }

        public IList<SchemaItem> Items { get; set; }

        public IList<SchemaItemSet> ItemSets { get; set; }

        public IList<SchemaItemAutograph> ItemAutographs { get; set; }
    }
}