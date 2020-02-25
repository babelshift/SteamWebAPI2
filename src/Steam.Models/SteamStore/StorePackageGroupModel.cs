using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.SteamStore
{
    public class StorePackageGroupModel
    {
        public string Name { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string SelectionText { get; set; }
        
        public string SaveText { get; set; }
        
        public uint DisplayType { get; set; }
        
        public string IsRecurringSubscription { get; set; }
        
        public StoreSubModel[] Subs { get; set; }
    }
}
