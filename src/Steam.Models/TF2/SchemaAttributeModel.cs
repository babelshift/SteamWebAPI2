using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.TF2
{
    public class SchemaAttributeModel
    {
        public string Name { get; set; }
        
        public uint Defindex { get; set; }
        
        public string AttributeClass { get; set; }
        
        public string DescriptionString { get; set; }
        
        public string DescriptionFormat { get; set; }
        
        public string EffectType { get; set; }
        
        public bool Hidden { get; set; }
        
        public bool StoredAsInteger { get; set; }
    }
}
