using System;
using System.Threading.Tasks;
using SteamWebAPI2.Models;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamNews
    {
        Task<SteamNewsResult> GetNewsForAppAsync(int appId, int? maxLength = default(int?), DateTime? endDate = default(DateTime?), int? count = default(int?));
    }
}