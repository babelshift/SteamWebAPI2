﻿using Steam.Models.DOTA2;
using SteamWebAPI2.Models.DOTA2;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    /// <summary>
    /// Represents a Steam Web API interface endpoint located at IDOTA2Econ
    /// </summary>
    public class DOTA2Econ : IDOTA2Econ
    {
        private ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public DOTA2Econ(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("IEconDOTA2_570", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns a collection of in game Dota 2 items. Example: blink dagger.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<GameItemModel>>> GetGameItemsAsync(string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<GameItemResultContainer>("GetGameItems", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<GameItemResultContainer>, ISteamWebResponse<IReadOnlyCollection<GameItemModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a collection of heroes and basic hero data.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="itemizedOnly"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<HeroModel>>> GetHeroesAsync(string language = "en_us", bool itemizedOnly = false)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            int itemizedOnlyValue = itemizedOnly ? 1 : 0;

            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(itemizedOnlyValue, "itemizedonly");

            var steamWebResponse = await steamWebInterface.GetAsync<HeroResultContainer>("GetHeroes", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<HeroResultContainer>, ISteamWebResponse<IReadOnlyCollection<HeroModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a collection of item rarities.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<RarityModel>>> GetRaritiesAsync(string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<RarityResultContainer>("GetRarities", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<RarityResultContainer>, ISteamWebResponse<IReadOnlyCollection<RarityModel>>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a tournament prize pool amount for a specific league.
        /// </summary>
        /// <param name="leagueId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<uint>> GetTournamentPrizePoolAsync(uint? leagueId = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(leagueId, "leagueid");

            var steamWebResponse = await steamWebInterface.GetAsync<PrizePoolResultContainer>("GetTournamentPrizePool", 1, parameters);

            var steamWebResponseModel = AutoMapperConfiguration.Mapper.Map<ISteamWebResponse<PrizePoolResultContainer>, ISteamWebResponse<uint>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}