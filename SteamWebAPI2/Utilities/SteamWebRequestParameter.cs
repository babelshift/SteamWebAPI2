using System;

namespace SteamWebAPI2.Utilities
{
    /// <summary>
    /// Represents a single parameter to be included in a web API request. Each parameter must have a name and a value, both of which will be serialized to
    /// a URL parameter.
    /// </summary>
    public class SteamWebRequestParameter
    {
        /// <summary>
        /// Name of the parameter (such as "key" in "key=123456" parameter)
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Value of the parameter (such as "123456" in "key=123456" parameter)
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Constructs a parameter with the given name and value. Name must not be null or empty.
        /// </summary>
        /// <param name="name">Name to give this parameter</param>
        /// <param name="value">Value to give this parameter</param>
        public SteamWebRequestParameter(string name, string value)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name");
            }

            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Returns a string which concatenates the name and value together with '=' symbol as it would appear in a URL
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0}={1}", Name, Value.ToString());
        }
    }
}