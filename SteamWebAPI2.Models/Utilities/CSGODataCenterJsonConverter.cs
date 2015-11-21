using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamWebAPI2.Models.CSGO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models.Utilities
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

            List<Datacenter> dataCenters = new List<Datacenter>();

            JObject o = JObject.Load(reader);

            foreach (var x in o)
            {
                Datacenter dataCenter = new Datacenter()
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
            return typeof(Datacenter).IsAssignableFrom(objectType);
        }
    }
}