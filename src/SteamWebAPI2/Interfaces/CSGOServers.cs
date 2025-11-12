using Steam.Models.CSGO;
using SteamWebAPI2.Models.CSGO;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SteamWebAPI2.Interfaces
{
    /// <summary>
    /// Represents a Steam Web API interface endpoint located at ICSGOServers_730
    /// </summary>
    public class CSGOServers : ICSGOServers
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public CSGOServers(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ICSGOServers_730", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Maps to the Steam Web API interface/method of ICSGOServers_730/GetGameMapsPlaytime/v1
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IEnumerable<GameMapsPlaytimeModel>>> GetGameMapsPlaytimeAsync(
            GameMapsPlaytimeInterval interval,
            GameMapsPlaytimeGameMode gameMode,
            GameMapsPlaytimeMapGroup mapGroup
        )
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(interval.ToString().ToLower(), "interval");
            parameters.AddIfHasValue(gameMode.ToString().ToLower(), "gamemode");
            parameters.AddIfHasValue(mapGroup.ToString().ToLower(), "mapgroup");

            var steamWebResponse = await steamWebInterface.GetAsync<GameMapsPlaytimeContainer>("GetGameMapsPlaytime", 1, parameters);
            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.Playtimes.Select(x => new GameMapsPlaytimeModel
                {
                    MapName = x.MapName,
                    IntervalStartTimeStamp = x.IntervalStartTimeStamp.ToDateTime(),
                    RelativePercentage = x.RelativePercentage
                });
            });
        }

        /// <summary>
        /// Maps to the Steam Web API interface/method of ICSGOServers_730/GetGameServersStatus/v1
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<ServerStatusModel>> GetGameServerStatusAsync()
        {
            var steamWebResponse = await steamWebInterface.GetAsync<ServerStatusResultContainer>("GetGameServersStatus", 1);
            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new ServerStatusModel
                {
                    App = result.App == null ? null : new ServerStatusAppModel
                    {
                        Version = result.App.Version,
                        Timestamp = result.App.Timestamp,
                        Time = result.App.Time
                    },
                    Services = result.Services == null ? null : new ServerStatusServicesModel
                    {
                        SessionsLogon = result.Services.SessionsLogon,
                        SteamCommunity = result.Services.SteamCommunity,
                        IEconItems = result.Services.IEconItems,
                        Leaderboards = result.Services.Leaderboards
                    },
                    Datacenters = result.Datacenters?.Select(d => new ServerStatusDatacenterModel
                    {
                        Name = d.Name,
                        Capacity = d.Capacity,
                        Load = d.Load
                    }).ToList().AsReadOnly(),
                    Matchmaking = result.Matchmaking == null ? null : new ServerStatusMatchmakingModel
                    {
                        Scheduler = result.Matchmaking.Scheduler,
                        OnlineServers = result.Matchmaking.OnlineServers,
                        OnlinePlayers = result.Matchmaking.OnlinePlayers,
                        SearchingPlayers = result.Matchmaking.SearchingPlayers,
                        SearchSecondsAverage = result.Matchmaking.SearchSecondsAverage
                    }
                };
            });
        }
    }
}