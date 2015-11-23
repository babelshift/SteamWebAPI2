using System.Collections.Generic;

namespace SteamWebAPI2.Models
{
    public class SteamApiList
    {
        public IList<SteamInterface> Interfaces { get; set; }
    }

    public class SteamApiListContainer
    {
        public SteamApiList ApiList { get; set; }
    }
}