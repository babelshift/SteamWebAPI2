using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.TF2
{
    public class SchemaCapabilitiesModel
    {
        public bool Nameable { get; set; }
        
        public bool CanCraftMark { get; set; }
        
        public bool CanBeRestored { get; set; }
        
        public bool StrangeParts { get; set; }
        
        public bool CanCardUpgrade { get; set; }
        
        public bool CanStrangify { get; set; }
        
        public bool CanKillstreakify { get; set; }
        
        public bool CanConsume { get; set; }
        
        public bool? CanGiftWrap { get; set; }
        
        public bool? CanCollect { get; set; }
        
        public bool? Paintable { get; set; }
        
        public bool? CanCraftIfPurchased { get; set; }
        
        public bool? CanCraftCount { get; set; }
        
        public bool? UsableGc { get; set; }
        
        public bool? Usable { get; set; }
        
        public bool? CanCustomizeTexture { get; set; }
        
        public bool? UsableOutOfGame { get; set; }
        
        public bool? CanSpellPage { get; set; }
        
        public bool? DuckUpgradable { get; set; }
        
        public bool? Decodable { get; set; }
    }
}
