using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.SteamStore
{
    public class StoreTopSellersModel
    {
        public uint Id { get; set; }
        
        public string Name { get; set; }
        
        public StoreItemModel[] Items { get; set; }
    }
}
