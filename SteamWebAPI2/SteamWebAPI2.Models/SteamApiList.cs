using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class SteamApiList
    {
        public IList<SteamInterface> Interfaces { get; set; }

        public SteamApiList()
        {
            Interfaces = new List<SteamInterface>();
        }
    }
}
