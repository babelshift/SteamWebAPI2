using System.Collections.Generic;

namespace Steam.Models.TF2
{
    public class SchemaItemLevelModel
    {
        public string Name { get; set; }

        public IList<SchemaLevelModel> Levels { get; set; }
    }
}
