using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class ItemBuildGroupSchemaItemModel
    {
        public string Name { get; set; }
        public IList<string> Items { get; set; }
    }
}