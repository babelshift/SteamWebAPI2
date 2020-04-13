using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamWebAPI2.Models.CSGO;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SteamWebAPI2.Utilities.JsonConverters
{
    internal class GameMapsPlaytimeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Custom deserialization required because raw API response is awful. Instead of returning real JSON objects, the API
        /// returns an array of "keys" and a matrix of "rows". We need to match up the keys to the columns within the rows
        /// to figure out which value goes with which key.
        /// 
        /// Example response:
        /// 
        /// "Keys": ["Key 1", "Key 2", "Key 3"],
        /// "Rows": [
        ///             ["A 1", "A 2", "A 3"],
        ///             ["B 1", "B 2", "B 3"]
        ///         ]
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            List<GameMapsPlaytime> playtimes = new List<GameMapsPlaytime>();

            JObject o = JObject.Load(reader);

            var keys = o["Keys"];
            var rows = o["Rows"];

            foreach (var row in rows)
            {
                int columnIndex = 0;
                GameMapsPlaytime playtime = new GameMapsPlaytime();
                foreach (var value in row)
                {
                    var key = keys[columnIndex];
                    if (key.ToString() == "IntervalStartTimeStamp")
                    {
                        playtime.IntervalStartTimeStamp = ulong.Parse(value.ToString());
                    }
                    else if (key.ToString() == "MapName")
                    {
                        playtime.MapName = value.ToString();
                    }
                    else if (key.ToString() == "RelativePercentage")
                    {
                        playtime.RelativePercentage = float.Parse(value.ToString());
                    }
                    columnIndex++;
                }
                playtimes.Add(playtime);
            }

            return new GameMapsPlaytimeResult()
            {
                Playtimes = playtimes
            };
        }

        public override bool CanWrite { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            return typeof(GameMapsPlaytimeResult).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
    }
}