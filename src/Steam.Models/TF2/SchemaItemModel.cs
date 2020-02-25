using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.TF2
{
    public class SchemaItemModel
    {
        public uint DefIndex { get; set; }
        
        public string Name { get; set; }
        
        public string ItemTypeName { get; set; }
    
        public string ItemName { get; set; }
        
        public string ItemDescription { get; set; }
        
        public string ImageInventoryPath { get; set; }
        
        public string ItemClass { get; set; }
        
        public bool ProperName { get; set; }
        
        public string ItemSlot { get; set; }
        
        public string ModelPlayer { get; set; }
        
        public uint ItemQuality { get; set; }
        
        public uint MinIlevel { get; set; }
        
        public uint MaxIlevel { get; set; }
        
        public string ImageUrl { get; set; }
        
        public string ImageUrlLarge { get; set; }
        
        public string CraftClass { get; set; }
        
        public string CraftMaterialType { get; set; }

        public string ItemLogName { get; set; }
        
        public SchemaCapabilitiesModel Capabilities { get; set; }
        
        public IList<string> UsedByClasses { get; set; }
        
        public IList<SchemaStyleModel> Styles { get; set; }
        
        public IList<SchemaItemAttributeModel> Attributes { get; set; }
        
        public string DropType { get; set; }
        
        public string ItemSet { get; set; }
        
        public string HolidayRestriction { get; set; }
        
        public SchemaPerClassLoadoutSlotsModel PerClassLoadoutSlots { get; set; }
        
        public SchemaToolModel Tool { get; set; }
    }
}
