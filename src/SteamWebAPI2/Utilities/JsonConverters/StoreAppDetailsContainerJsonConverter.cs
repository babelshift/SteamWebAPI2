using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamWebAPI2.Models.SteamStore;
using System;
using System.Reflection;

namespace SteamWebAPI2.Utilities.JsonConverters
{
    /// <summary>
    /// Take some special steps when deserializing the AppDetails response since the response has a dynamic property based on the app id which is passed as a parameter.
    /// For example, passing app id "570" to the AppDetails endpoint will give a response like so:
    /// "570": {
    ///     "success": true
    /// }
    /// </summary>
    internal class StoreAppDetailsContainerJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            JObject o = JObject.Load(reader);

            foreach (var x in o)
            {
                // Edit by Jir : Previously returning Data; should return the correct object AppDetailsContainer instead. Sorry for ugly code
                var data = x.Value["data"].ToObject<Data>();
                var success = x.Value["success"].ToObject<bool>();
                AppDetailsContainer appDetailsContainer = new AppDetailsContainer { Data = data, Success = success };
                return appDetailsContainer;

                // return data;
            }

            return null;
        }

        public override bool CanWrite { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            return typeof(AppDetailsContainer).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
    }
}