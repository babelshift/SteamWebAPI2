using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamWebAPI2.Models.CSGO;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SteamWebAPI2.Utilities.JsonConverters
{
    internal class CSGODataCenterJsonConverter : JsonConverter
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

            List<ServerStatusDatacenter> dataCenters = new List<ServerStatusDatacenter>();

            JObject o = JObject.Load(reader);

            foreach (var x in o)
            {
                ServerStatusDatacenter dataCenter = new ServerStatusDatacenter()
                {
                    Name = x.Key,
                    Capacity = x.Value.Value<string>("capacity") ?? "unknown",
                    Load = x.Value.Value<string>("load") ?? "unknown"
                };

                dataCenters.Add(dataCenter);
            }

            return dataCenters;
        }

        public override bool CanWrite { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ServerStatusDatacenter).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
    }
}