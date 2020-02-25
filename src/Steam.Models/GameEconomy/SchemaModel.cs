using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class SchemaModel
    {
        public uint Status { get; set; }

        public string ItemsGameUrl { get; set; }

        public SchemaQualitiesModel Qualities { get; set; }

        public IReadOnlyCollection<SchemaOriginNameModel> OriginNames { get; set; }

        public IReadOnlyCollection<SchemaItemModel> Items { get; set; }

        public IReadOnlyCollection<SchemaAttributeModel> Attributes { get; set; }

        public IReadOnlyCollection<SchemaItemSetModel> ItemSets { get; set; }

        public IReadOnlyCollection<SchemaAttributeControlledAttachedParticleModel> AttributeControlledAttachedParticles { get; set; }

        public IReadOnlyCollection<SchemaItemLevelModel> ItemLevels { get; set; }

        public IReadOnlyCollection<SchemaKillEaterScoreTypeModel> KillEaterScoreTypes { get; set; }

        public IReadOnlyCollection<SchemaStringLookupModel> StringLookups { get; set; }
    }
}