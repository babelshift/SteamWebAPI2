using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.SteamStore
{
    public class StoreScreenshotModel
    {
        public uint Id { get; set; }
        
        public string PathThumbnail { get; set; }
        
        public string PathFull { get; set; }
    }
}
