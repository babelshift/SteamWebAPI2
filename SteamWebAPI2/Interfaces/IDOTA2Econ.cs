using System.Collections.Generic;
using System.Threading.Tasks;
using SteamWebAPI2.Models.DOTA2;

namespace SteamWebAPI2.Interfaces
{
    public interface IDOTA2Econ
    {
        Task<IReadOnlyCollection<GameItem>> GetGameItemsAsync(string language = "");
        Task<IReadOnlyCollection<Hero>> GetHeroesAsync(string language = "", bool itemizedOnly = false);
        Task<string> GetItemIconPathAsync(string iconName, string iconType = "");
        Task<RarityResult> GetRaritiesAsync(string language = "");
        void GetSteamAccountValidForEvent(int eventId, long steamId, string language = "");
        Task<PrizePoolResult> GetTournamentPrizePool(int? leagueId = null);
    }
}