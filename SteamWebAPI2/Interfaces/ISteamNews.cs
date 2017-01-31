using Steam.Models;
using System;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamNews
    {
        Task<SteamNewsResultModel> GetNewsForAppAsync(uint appId, uint? maxLength = null, DateTime? endDate = null, uint? count = null);
    }
}