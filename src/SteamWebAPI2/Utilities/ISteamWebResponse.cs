using System;

namespace SteamWebAPI2.Utilities
{
    public interface ISteamWebResponse<T>
    {
        T Data { get; set; }
        long? ContentLength { get; set; }
        string ContentType { get; set; }
        string ContentTypeCharSet { get; set; }
        DateTimeOffset? Expires { get; set; }
        DateTimeOffset? LastModified { get; set; }
    }
}