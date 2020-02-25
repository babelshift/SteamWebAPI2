using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steam.Models.TF2
{
    public class SchemaItemLevelModel
    {
        public string Name { get; set; }
        
        public IList<SchemaLevelModel> Levels { get; set; }
    }
}
