using Newtonsoft.Json;

namespace SteamWebAPI2.Models
{
    internal class SteamAppUpToDateCheckResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("up_to_date")]
        public bool UpToDate { get; set; }

        [JsonProperty("version_is_listable")]
        public bool VersionIsListable { get; set; }

        [JsonProperty("required_version")]
        public uint RequiredVersion { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    internal class SteamAppUpToDateCheckResultContainer
    {
        [JsonProperty("response")]
        public SteamAppUpToDateCheckResult Result { get; set; }
    }
}