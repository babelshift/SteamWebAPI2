using Steam.Models.DOTA2;
using SteamWebAPI2.Models.DOTA2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Interfaces
{
    /// <summary>
    /// Represents a Steam Web API interface endpoint located at IDOTA2Econ
    /// </summary>
    public class DOTA2Econ : SteamWebInterface, IDOTA2Econ
    {
        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public DOTA2Econ(string steamWebApiKey)
            : base(steamWebApiKey, "IEconDOTA2_570")
        {
        }

        /// <summary>
        /// Returns a collection of in game Dota 2 items. Example: blink dagger.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<GameItemModel>> GetGameItemsAsync(string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var gameItems = await GetAsync<GameItemResultContainer>("GetGameItems", 1, parameters);

            var gameItemModels = AutoMapperConfiguration.Mapper.Map<IList<GameItem>, IReadOnlyCollection<GameItemModel>>(gameItems.Result.Items);

            return gameItemModels;
        }

        /// <summary>
        /// Returns a collection of heroes and basic hero data.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="itemizedOnly"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<HeroModel>> GetHeroesAsync(string language = "en_us", bool itemizedOnly = false)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            int itemizedOnlyValue = itemizedOnly ? 1 : 0;

            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(itemizedOnlyValue, "itemizedonly");

            var heroes = await GetAsync<HeroResultContainer>("GetHeroes", 1, parameters);

            var heroModels = AutoMapperConfiguration.Mapper.Map<IList<Hero>, IReadOnlyCollection<HeroModel>>(heroes.Result.Heroes);

            return heroModels;
        }

        /// <summary>
        /// It is important to note that the "items" this method is referring to are not the in game items. These are actually cosmetic items found in the DOTA 2 store and workshop.
        /// </summary>
        /// <param name="iconName"></param>
        /// <param name="iconType"></param>
        /// <returns></returns>
        public async Task<string> GetItemIconPathAsync(string iconName, string iconType = "")
        {
            if (String.IsNullOrEmpty(iconName))
            {
                throw new ArgumentNullException("iconName");
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(iconName, "iconname");
            parameters.AddIfHasValue(iconType, "icontype");

            var itemIconPath = await GetAsync<ItemIconPathResultContainer>("GetItemIconPath", 1, parameters);
            return itemIconPath.Result.Path;
        }

        /// <summary>
        /// Returns a collection of item rarities.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<RarityModel>> GetRaritiesAsync(string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var raritiesContainer = await GetAsync<RarityResultContainer>("GetRarities", 1, parameters);

            var rarityModels = raritiesContainer.Result.Rarities.Select(x => new RarityModel()
            {
                Id = x.Id,
                Name = x.Name,
                Color = x.Color,
                Order = x.Order
            })
            .ToList()
            .AsReadOnly();

            return rarityModels;
        }

        /// <summary>
        /// Returns a tournament prize pool amount for a specific league.
        /// </summary>
        /// <param name="leagueId"></param>
        /// <returns></returns>
        public async Task<int> GetTournamentPrizePoolAsync(int? leagueId = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(leagueId, "leagueid");

            var raritiesContainer = await GetAsync<PrizePoolResultContainer>("GetTournamentPrizePool", 1, parameters);
            return raritiesContainer.Result.PrizePool;
        }
    }
}