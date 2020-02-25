using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.SteamStore
{
    public class StoreSubModel
    {
        public uint PackageId { get; set; }
        
        public string PercentSavingsText { get; set; }
        
        public uint PercentSavings { get; set; }
    
        public string OptionText { get; set; }
        
        public string OptionDescription { get; set; }
        
        public string CanGetFreeLicense { get; set; }
        
        public bool IsFreeLicense { get; set; }
        
        public uint PriceInCentsWithDiscount { get; set; }
    }
}
