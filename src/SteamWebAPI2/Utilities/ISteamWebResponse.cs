using System;

namespace SteamWebAPI2.Utilities
{
    public interface ISteamWebResponse<T>
    {
        // Data returned from Steam Web API (this is probably what you care about)
        T Data { get; set; }
        // Content length from the HTTP response
        long? ContentLength { get; set; }
        // Content type of the HTTP response
        string ContentType { get; set; }
        // Charset of the content type of the HTTP response
        string ContentTypeCharSet { get; set; }
        // Expires header from the HTTP response
        DateTimeOffset? Expires { get; set; }
        // Last modified header from the HTTP response
        DateTimeOffset? LastModified { get; set; }
    }
}