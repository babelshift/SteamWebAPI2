using System.Collections.Generic;

namespace Steam.Models
{
    public class SteamInterfaceModel
    {
        public string Name { get; set; }
        public IReadOnlyCollection<SteamMethodModel> Methods { get; private set; }
    }
}