using System;

namespace SteamWebAPI2.Exceptions
{
    public class InvalidSteamCommunityUriException : Exception
    {
        public InvalidSteamCommunityUriException()
        {
        }

        public InvalidSteamCommunityUriException(string message) : base(message)
        {
        }

        public InvalidSteamCommunityUriException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}