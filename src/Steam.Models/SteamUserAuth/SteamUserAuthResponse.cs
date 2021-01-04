namespace Steam.Models.SteamUserAuth
{
    public class SteamUserAuthResponse
    {
        public SteamAuthResponseParams Params { get; set; }
        public SteamAuthError Error { get; set; }
        public bool Success => Error == null && Params != null;
    }
}