using System;

namespace SteamWebAPI2.Exceptions
{
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