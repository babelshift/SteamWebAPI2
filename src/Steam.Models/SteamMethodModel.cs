using System.Collections.Generic;

namespace Steam.Models
{
    public class SteamMethodModel
    {
        public string Name { get; set; }
        public uint Version { get; set; }
        public string HttpMethod { get; set; }
        public string Description { get; set; }
        public IReadOnlyCollection<SteamParameterModel> Parameters { get; private set; }
    }
}