using System;

namespace SteamWebAPI2.Exceptions
{
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