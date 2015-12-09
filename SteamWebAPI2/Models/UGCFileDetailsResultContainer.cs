using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2.Models
{
    public class UGCFileDetailsResultContainer
    {
        [JsonProperty("data")]
        public UGCFileDetails Result { get; set; }
    }

    public class UGCFileDetails
    {
        public string FileName { get; set; }
        public string URL { get; set; }
        public int Size { get; set; }
    }
}
