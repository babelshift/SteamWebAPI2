using System.Collections.Generic;

namespace Steam.Models.DOTA2
{
    public class ItemBuildGroup
    {
        public string Name { get; set; }
        
        public IList<string> Items { get; set; }
    }
}