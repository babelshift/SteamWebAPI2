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

        public SteamWebResponse<TNew> MapTo<TNew>(Func<T, TNew> mapFunction)
        {
            var mappedTo = new SteamWebResponse<TNew>
            {
                ContentLength = this.ContentLength,
                ContentType = this.ContentType,
                ContentTypeCharSet = this.ContentTypeCharSet,
                Expires = this.Expires,
                LastModified = this.LastModified
            };

            if (this.Data == null)
            {
                return mappedTo;
            }

            mappedTo.Data = mapFunction(this.Data);

            return mappedTo;
        }
    }
}