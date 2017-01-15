using System.Threading.Tasks;

namespace SteamWebAPI2.Utilities
{
    public interface ISteamWebHttpClient
    {
        Task<string> GetStringAsync(string uri);

        Task<string> PostAsync(string uri);
    }
}