using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class SchemaStringLookupModel
    {
        public string TableName { get; set; }

        public IReadOnlyCollection<SchemaStringModel> Strings { get; set; }
    }
}