using System;

namespace SteamWebAPI2
{
    internal class SteamWebRequestParameter
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public SteamWebRequestParameter(string name, string value)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            this.Name = name;
            this.Value = value;
        }
    }
}