namespace Steam.Models
{
    public class SteamAppUpToDateCheckModel
    {
        public bool Success { get; set; }

        public bool UpToDate { get; set; }

        public bool VersionIsListable { get; set; }

        public uint RequiredVersion { get; set; }

        public string Message { get; set; }
    }
}