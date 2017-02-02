using System;

namespace SteamWebAPI2.Utilities
{
    public class SteamWebResponse<T> : ISteamWebResponse<T>
    {
        public T Data { get; set; }
        public long? ContentLength { get; set; }
        public string ContentType { get; set; }
        public string ContentTypeCharSet { get; set; }
        public DateTimeOffset? Expires { get; set; }
        public DateTimeOffset? LastModified { get; set; }
    }
}