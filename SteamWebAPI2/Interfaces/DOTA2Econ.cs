using SteamWebAPI2.Models.DOTA2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SteamWebAPI2.Interfaces
{
    public class DOTA2Econ : SteamWebInterface, IDOTA2Econ
    {
        public DOTA2Econ(string steamWebApiKey)
            : base(steamWebApiKey, "IEconDOTA2_570")
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="eventId">This is possibly the same as League Id according to documentation...why?</param>
        /// <param name="steamId"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public void GetSteamAccountValidForEvent(int eventId, long steamId, string language = "")
        {
            throw new NotImplementedException("I can't find good test conditions for this, so I don't know how to implement a response parser.");
        }

        public async Task<IReadOnlyCollection<GameItem>> GetGameItemsAsync(string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(language, "language", parameters);

            var gameItems = await CallMethodAsync<GameItemResultContainer>("GetGameItems", 1, parameters);
            return new ReadOnlyCollection<GameItem>(gameItems.Result.Items);
        }

        public async Task<IReadOnlyCollection<Hero>> GetHeroesAsync(string language = "", bool itemizedOnly = false)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            int itemizedOnlyValue = itemizedOnly ? 1 : 0;

            AddToParametersIfHasValue(language, "language", parameters);
            AddToParametersIfHasValue(itemizedOnlyValue, "itemizedonly", parameters);

            var heroes = await CallMethodAsync<HeroResultContainer>("GetHeroes", 1, parameters);
            return new ReadOnlyCollection<Hero>(heroes.Result.Heroes);
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

            AddToParametersIfHasValue(iconName, "iconname", parameters);
            AddToParametersIfHasValue(iconType, "icontype", parameters);

            var itemIconPath = await CallMethodAsync<ItemIconPathResultContainer>("GetItemIconPath", 1, parameters);
            return itemIconPath.Result.Path;
        }

        public async Task<RarityResult> GetRaritiesAsync(string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(language, "language", parameters);

            var raritiesContainer = await CallMethodAsync<RarityResultContainer>("GetRarities", 1, parameters);
            return raritiesContainer.Result;
        }

        public async Task<PrizePoolResult> GetTournamentPrizePool(int? leagueId = null)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue(leagueId, "leagueid", parameters);

            var raritiesContainer = await CallMethodAsync<PrizePoolResultContainer>("GetTournamentPrizePool", 1, parameters);
            return raritiesContainer.Result;
        }
    }
}