using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class SteamWebRequestParameter
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public SteamWebRequestParameter(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
