using System.Net.Http;
using SteamWebAPI2.Interfaces;

namespace SteamWebAPI2.Utilities
{
    public interface ISteamWebInterfaceFactory
    {
        SteamStore CreateSteamStoreInterface(HttpClient httpClient = null);
        T CreateSteamWebInterface<T>(HttpClient httpClient = null);
        T CreateSteamWebInterface<T>(AppId appId, HttpClient httpClient = null);
    }
}