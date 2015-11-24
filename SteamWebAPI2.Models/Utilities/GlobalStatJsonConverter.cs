using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamWebAPI2.Models.SteamCommunity;
using System;
using System.Collections.Generic;

namespace SteamWebAPI2.Models.Utilities
{
    internal class GlobalStatJsonConverter : JsonConverter
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

            JObject globalStatsObject = JObject.Load(reader);

            List<GlobalStat> globalStats = new List<GlobalStat>();

            foreach (var globalStatProperty in globalStatsObject.Children<JProperty>())
            {
                GlobalStat globalStat = new GlobalStat();

                globalStat.Name = globalStatProperty.Name;

                foreach (var globalStatDetailsProperty in globalStatProperty.Value.Children<JProperty>())
                {
                    string value = globalStatDetailsProperty.Value.ToString();

                    if (globalStatDetailsProperty.Name == "total") { globalStat.Total = Int32.Parse(value); }
                }

                globalStats.Add(globalStat);
            }

            return globalStats;
        }

        public override bool CanWrite { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IList<GlobalStat>).IsAssignableFrom(objectType);
        }
    }
}