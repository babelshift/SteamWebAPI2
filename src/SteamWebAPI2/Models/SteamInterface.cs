using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models
{
    internal class SteamInterface
    {
        public string Name { get; set; }
        public IList<SteamMethod> Methods { get; private set; }

        public SteamInterface()
        {
            Methods = new List<SteamMethod>();
        }
    }

    internal class SteamMethod
    {
        public string Name { get; set; }
        public uint Version { get; set; }
        public string HttpMethod { get; set; }
        public string Description { get; set; }
        public IList<SteamParameter> Parameters { get; private set; }

        public SteamMethod()
        {
            Parameters = new List<SteamParameter>();
        }
    }

    internal class SteamParameter
    {
        public string Name { get; set; }
        public string Type { get; set; }

        [JsonProperty(PropertyName = "optional")]
        public bool IsOptional { get; set; }

        public string Description { get; set; }
    }
}