using System.Collections.Generic;

namespace Steam.Models.TF2
{
    public class SchemaStringLookupModel
    {
        public string TableName { get; set; }

        public IList<SchemaStringModel> Strings { get; set; }
    }
}
