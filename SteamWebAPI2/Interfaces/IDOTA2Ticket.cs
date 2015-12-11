namespace SteamWebAPI2.Interfaces
{
    public interface IDOTA2Ticket
    {
        void GetSteamAccountValidForEvent(int eventId, long steamId);
    }
}