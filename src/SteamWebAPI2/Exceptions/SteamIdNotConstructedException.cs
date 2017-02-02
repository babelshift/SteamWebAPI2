using System;

namespace SteamWebAPI2.Exceptions
{
    /// <summary>
    /// Represents an exception that has been thrown as a result of all parsing options failing to work with a given Steam ID.
    /// </summary>
    public class SteamIdNotConstructedException : Exception
    {
        public SteamIdNotConstructedException()
        {
        }

        public SteamIdNotConstructedException(string message) : base(message)
        {
        }

        public SteamIdNotConstructedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}