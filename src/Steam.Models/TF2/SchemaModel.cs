using System.Collections.Generic;

namespace Steam.Models.TF2
{
    public class SchemaModel
    {
        public string ItemsGameUrl { get; set; }

        public SchemaQualitiesModel Qualities { get; set; }

        public IList<SchemaOriginNameModel> OriginNames { get; set; }

        public IList<SchemaItemModel> Items { get; set; }

        public IList<SchemaAttributeModel> Attributes { get; set; }

        public IList<SchemaItemSetModel> ItemSets { get; set; }

        public IList<SchemaAttributeControlledAttachedParticleModel> AttributeControlledAttachedParticles { get; set; }

        public IList<SchemaItemLevelModel> ItemLevels { get; set; }

        public IList<SchemaKillEaterScoreTypeModel> KillEaterScoreTypes { get; set; }

        public IList<SchemaStringLookupModel> StringLookups { get; set; }
    }
}
