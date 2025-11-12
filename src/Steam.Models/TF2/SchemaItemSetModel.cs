using System.Collections.Generic;

namespace Steam.Models.TF2
{
    public class SchemaItemSetModel
    {
        public string ItemSet { get; set; }

        public string Name { get; set; }

        public IList<string> Items { get; set; }

        public IList<SchemaItemSetAttributeModel> Attributes { get; set; }

        public string StoreBundleName { get; set; }
    }
}
