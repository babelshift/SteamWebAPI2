using Steam.Models;
using SteamWebAPI2.Utilities;
using System;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public interface ISteamNews
    {
        Task<ISteamWebResponse<SteamNewsResultModel>> GetNewsForAppAsync(uint appId, uint? maxLength = null, DateTime? endDate = null, uint? count = null);
    }
}