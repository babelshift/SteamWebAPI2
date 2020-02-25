using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class SchemaItemSetModel
    {
        public string RawName { get; set; }

        public string ItemSet { get; set; }

        public string Name { get; set; }

        public IReadOnlyCollection<string> Items { get; set; }

        public IReadOnlyCollection<SchemaItemSetAttributeModel> Attributes { get; set; }

        public string StoreBundleName { get; set; }
    }
}