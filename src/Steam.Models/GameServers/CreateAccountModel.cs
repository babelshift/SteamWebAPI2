namespace Steam.Models.GameServers
{
    public class CreateAccountModel
    {
        public ulong SteamId { get; set; }
        
        public string LoginToken { get; set; }
    }
}