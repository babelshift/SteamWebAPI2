using Steam.Models;
using System;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamNews
    {
        Task<SteamNewsResultModel> GetNewsForAppAsync(int appId, int? maxLength = default(int?), DateTime? endDate = default(DateTime?), int? count = default(int?));
    }
}