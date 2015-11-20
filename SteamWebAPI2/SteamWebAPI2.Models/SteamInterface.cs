using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class SteamInterface
    {
        public string Name { get; set; }
        public IList<SteamMethod> Methods { get; private set; }

        public SteamInterface()
        {
            Methods = new List<SteamMethod>();
        }
    }

    public class SteamMethod
    {
        public string Name { get; set; }
        public int Version { get; set; }
        public string HttpMethod { get; set; }
        public IList<SteamParameter> Parameters { get; private set; }

        public SteamMethod()
        {
            Parameters = new List<SteamParameter>();
        }
    }

    public class SteamParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsOptional { get; set; }
        public string Description { get; set; }
    }
}
