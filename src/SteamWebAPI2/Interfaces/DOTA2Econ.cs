using AutoMapper;
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
        private readonly ISteamWebInterface dota2WebInterface;
        private readonly ISteamWebInterface dota2TestWebInterface;
        private readonly IMapper mapper;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public DOTA2Econ(IMapper mapper, ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            this.dota2WebInterface = steamWebInterface == null
                ? new SteamWebInterface("IEconDOTA2_570", steamWebRequest)
                : steamWebInterface;

            this.dota2TestWebInterface = new SteamWebInterface("IEconDOTA2_205790", steamWebRequest);
        }

        /// <summary>
        /// Returns a collection of in game Dota 2 items. Example: blink dagger.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<Steam.Models.DOTA2.GameItem>>> GetGameItemsAsync(string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await dota2WebInterface.GetAsync<GameItemResultContainer>("GetGameItems", 1, parameters);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<GameItemResultContainer>, ISteamWebResponse<IReadOnlyCollection<Steam.Models.DOTA2.GameItem>>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a collection of heroes and basic hero data.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="itemizedOnly"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<Steam.Models.DOTA2.Hero>>> GetHeroesAsync(string language = "en_us", bool itemizedOnly = false)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            int itemizedOnlyValue = itemizedOnly ? 1 : 0;

            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(itemizedOnlyValue, "itemizedonly");

            var steamWebResponse = await dota2WebInterface.GetAsync<HeroResultContainer>("GetHeroes", 1, parameters);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<HeroResultContainer>, ISteamWebResponse<IReadOnlyCollection<Steam.Models.DOTA2.Hero>>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// Returns a collection of item rarities.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<IReadOnlyCollection<Steam.Models.DOTA2.Rarity>>> GetRaritiesAsync(string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await dota2WebInterface.GetAsync<RarityResultContainer>("GetRarities", 1, parameters);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<RarityResultContainer>, ISteamWebResponse<IReadOnlyCollection<Steam.Models.DOTA2.Rarity>>>(steamWebResponse);

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

            var steamWebResponse = await dota2WebInterface.GetAsync<PrizePoolResultContainer>("GetTournamentPrizePool", 1, parameters);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<PrizePoolResultContainer>, ISteamWebResponse<uint>>(steamWebResponse);

            return steamWebResponseModel;
        }

        /// <summary>
        /// It is important to note that the "items" this method is referring to are not the in game items. These are actually cosmetic items found in the DOTA 2 store and workshop.
        /// </summary>
        /// <param name="iconName"></param>
        /// <param name="iconType"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<string>> GetItemIconPathAsync(string iconName, string iconType = "")
        {
            if (string.IsNullOrEmpty(iconName))
            {
                throw new ArgumentNullException("iconName");
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(iconName, "iconname");
            parameters.AddIfHasValue(iconType, "icontype");

            var steamWebResponse = await dota2TestWebInterface.GetAsync<ItemIconPathResultContainer>("GetItemIconPath", 1, parameters);

            var steamWebResponseModel = mapper.Map<ISteamWebResponse<ItemIconPathResultContainer>, ISteamWebResponse<string>>(steamWebResponse);

            return steamWebResponseModel;
        }
    }
}