
using Steam.Models;
using SteamWebAPI2.Models;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SteamWebAPI2.Interfaces
{
    public class SteamWebAPIUtil : ISteamWebAPIUtil
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public SteamWebAPIUtil(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ISteamWebAPIUtil", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns the Steam Servers' known dates and times.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SteamServerInfoModel>> GetServerInfoAsync()
        {
            var steamWebResponse = await steamWebInterface.GetAsync<SteamServerInfo>("GetServerInfo", 1);

            return steamWebResponse.MapTo((from) =>
            {
                return new SteamServerInfoModel
                {
                    ServerTime = from?.ServerTime ?? 0,
                    ServerTimeString = from?.ServerTimeString
                };
            });
        }

        /// <summary>
        /// Returns a collection of data related to all available supported Steam Web API endpoints.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<SteamInterfaceModel>>> GetSupportedAPIListAsync()
        {
            var steamWebResponse = await steamWebInterface.GetAsync<SteamApiListContainer>("GetSupportedAPIList", 1);

            return steamWebResponse.MapTo<IReadOnlyCollection<SteamInterfaceModel>>((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return result.Interfaces?.Select(i => new SteamInterfaceModel
                {
                    Name = i.Name,
                    Methods = i.Methods?.Select(m => new SteamMethodModel
                    {
                        Description = m.Description,
                        HttpMethod = m.HttpMethod,
                        Name = m.Name,
                        Version = m.Version,
                        Parameters = m.Parameters?.Select(p => new SteamParameterModel
                        {
                            Name = p.Name,
                            Type = p.Type,
                            Description = p.Description,
                            IsOptional = p.IsOptional
                        }).ToList().AsReadOnly()
                    }).ToList().AsReadOnly()
                }).ToList().AsReadOnly();
            });
        }
    }
}