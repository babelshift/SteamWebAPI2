namespace Steam.Models.SteamUserAuth
{
    public class SteamAuthResponseParams
    {
        public string Result { get; set; }
        public string SteamId { get; set; }
        public string OwnerSteamId { get; set; }
        public bool VacBanned { get; set; }
        public bool PublisherBanned { get; set; }
    }
}