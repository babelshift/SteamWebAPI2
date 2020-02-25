using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.TF2
{
    public class SchemaLevelModel
    {
        public uint Level { get; set; }
        
        public uint RequiredScore { get; set; }
        
        public string Name { get; set; }
    }
}
