using System;

namespace SteamWebAPI2.Exceptions
{
    /// <summary>
    /// Represents an exception that has been thrown as a result of using the Steam Web API to resolve a vanity url only to have the response indicate "no match".
    /// </summary>
    public class VanityUrlNotResolvedException : Exception
    {
        public VanityUrlNotResolvedException()
        {
        }

        public VanityUrlNotResolvedException(string message) : base(message)
        {
        }

        public VanityUrlNotResolvedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}