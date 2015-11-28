using System;

namespace SteamWebAPI2.Exceptions
{
    /// <summary>
    /// Represents an exception that has been thrown as a result of parsing a Uri that wasn't a Steam Community Uri.
    /// </summary>
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