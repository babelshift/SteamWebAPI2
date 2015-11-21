using Newtonsoft.Json;
using SteamWebAPI2.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class CSGOServerStatusResult
    {
        public CSGOApp App { get; set; }
        public CSGOServices Services { get; set; }

        /// <summary>
        /// We have to use a custom converter here because the JSON response for data centers is badly formatted. Instead of using a JSON array in which
        /// all data centers are listed, Valve decided to make individual objects for each data center. So we fix that by parsing them into an array.
        /// </summary>
        [JsonConverter(typeof(CSGODataCenterJsonConverter))]
        public IList<CSGODatacenter> Datacenters { get; set; }

        public CSGOMatchmaking Matchmaking { get; set; }
    }
}
