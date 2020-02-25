using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.TF2
{
    public class SchemaItemSetModel
    {
        public string ItemSet { get; set; }
        
        public string Name { get; set; }
        
        public IList<string> Items { get; set; }
        
        public IList<SchemaItemSetAttributeModel> Attributes { get; set; }
        
        public string StoreBundleName { get; set; }
    }
}
