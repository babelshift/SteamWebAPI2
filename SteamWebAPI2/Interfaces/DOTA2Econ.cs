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
        public async Task<IReadOnlyCollection<GameItemModel>> GetGameItemsAsync(string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var gameItems = await CallMethodAsync<GameItemResultContainer>("GetGameItems", 1);

            var gameItemModels = gameItems.Result.Items.Select(x => new GameItemModel()
            {
                Id = x.Id,
                Cost = x.Cost,
                IsAvailableAtSecretShop = x.SecretShop == 1 ? true : false,
                IsAvailableAtSideShop = x.SideShop == 1 ? true : false,
                IsRecipe = x.Recipe == 1 ? true : false,
                Name = x.Name
            })
            .ToList()
            .AsReadOnly();

            return gameItemModels;
        }

        /// <summary>
        /// Some items have an incorrect id in the schema file. This method returns the corrected id based on the wrong id and the item name.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static int GetCorrectedId(int id, string name)
        {
            // iron talon
            if (id == 239 && name == "item_iron_talon")
            {
                return 273;
            }
            // aether lens
            else if (id == 232 && name == "item_aether_lens")
            {
                return 1028;
            }
            // faerie fire
            else if (id == 237 && name == "item_faerie_fire")
            {
                return 1023;
            }
            // dragon lance
            else if (id == 236 && name == "item_dragon_lance")
            {
                return 1025;
            }
            // recipe: iron talon
            else if (id == 238 && name == "item_recipe_iron_talon")
            {
                return 272;
            }
            // recipe: aether lens
            else if (id == 233 && name == "item_recipe_aether_lens")
            {
                return 1027;
            }
            // recipe: dragon lance
            else if (id == 234 && name == "item_dragon_lance")
            {
                return 1024;
            }
            else
            {
                return id;
            }
        }

        /// <summary>
        /// Returns a collection of heroes and basic hero data.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="itemizedOnly"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<HeroModel>> GetHeroesAsync(string language = "", bool itemizedOnly = false)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            int itemizedOnlyValue = itemizedOnly ? 1 : 0;

            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(itemizedOnlyValue, "itemizedonly");

            var heroes = await CallMethodAsync<HeroResultContainer>("GetHeroes", 1, parameters);

            var heroModels = heroes.Result.Heroes.Select(x => new HeroModel()
            {
                Id = x.Id,
                Name = x.Name
            })
            .ToList()
            .AsReadOnly();

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

            var itemIconPath = await CallMethodAsync<ItemIconPathResultContainer>("GetItemIconPath", 1, parameters);
            return itemIconPath.Result.Path;
        }

        /// <summary>
        /// Returns a collection of item rarities.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<RarityModel>> GetRaritiesAsync(string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var raritiesContainer = await CallMethodAsync<RarityResultContainer>("GetRarities", 1, parameters);

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

            var raritiesContainer = await CallMethodAsync<PrizePoolResultContainer>("GetTournamentPrizePool", 1, parameters);
            return raritiesContainer.Result.PrizePool;
        }
    }
}