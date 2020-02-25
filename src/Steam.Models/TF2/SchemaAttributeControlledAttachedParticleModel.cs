using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.TF2
{
    public class SchemaAttributeControlledAttachedParticleModel
    {
        public string System { get; set; }
        
        public uint Id { get; set; }
        
        public bool AttachToRootbone { get; set; }
    
        public string Name { get; set; }
        
        public string Attachment { get; set; }
    }
}
