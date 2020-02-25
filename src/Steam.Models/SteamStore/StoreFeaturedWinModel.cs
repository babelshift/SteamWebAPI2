using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.SteamStore
{
    public class StoreFeaturedWinModel
    {
        public uint Id { get; set; }
        
        public uint Type { get; set; }
        
        public string Name { get; set; }
        
        public bool Discounted { get; set; }
        
        public uint DiscountPercent { get; set; }
        
        public uint? OriginalPrice { get; set; }
        
        public uint FinalPrice { get; set; }
        
        public string Currency { get; set; }
        
        public string LargeCapsuleImage { get; set; }
        
        public string SmallCapsuleImage { get; set; }
        
        public bool WindowsAvailable { get; set; }
        
        public bool MacAvailable { get; set; }
        
        public bool LinuxAvailable { get; set; }
        
        public bool StreamingvideoAvailable { get; set; }
        
        public string HeaderImage { get; set; }
        
        public string ControllerSupport { get; set; }
        
        public uint? DiscountExpiration { get; set; }
    }
}
