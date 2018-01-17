using System;
using System.Collections.Generic;
using System.Reflection;

using Newtonsoft.Json;

namespace SteamWebAPI2.Utilities.JsonConverters
{
    /// <inheritdoc />
    /// <summary>
    /// Converts the tags stored in a list of dictionaries to a list of the values of the dictionary.
    /// <remarks>The keys seem to always be the string "tag".</remarks>
    /// </summary>
    internal class TagsJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var original = serializer.Deserialize<List<Dictionary<string, string>>>(reader);
            var tags = new List<string>();

            original.ForEach(tag => tags.AddRange(tag.Values));

            return tags;
        }

        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return typeof(IList<IDictionary<string, string>>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
    }
}
