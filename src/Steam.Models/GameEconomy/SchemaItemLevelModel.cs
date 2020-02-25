using System.Collections.Generic;

namespace Steam.Models.GameEconomy
{
    public class SchemaItemLevelModel
    {
        public string Name { get; set; }

        public IReadOnlyCollection<SchemaLevelModel> Levels { get; set; }
    }
}