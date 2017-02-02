using Newtonsoft.Json;
using System.Collections.Generic;

namespace SteamWebAPI2.Models
{
    internal class SteamApiListResult
    {
        public IList<SteamInterface> Interfaces { get; set; }
    }

    internal class SteamApiListContainer
    {
        [JsonProperty("apilist")]
        public SteamApiListResult Result { get; set; }
    }
}