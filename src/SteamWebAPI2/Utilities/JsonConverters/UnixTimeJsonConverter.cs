using Newtonsoft.Json;
using System;
using System.Reflection;

namespace SteamWebAPI2.Utilities.JsonConverters
{
    internal class UnixTimeJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ulong unixTime = ulong.Parse(reader.Value.ToString());
            return unixTime.ToDateTime();
        }

        public override bool CanWrite { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            return typeof(long).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
    }
}