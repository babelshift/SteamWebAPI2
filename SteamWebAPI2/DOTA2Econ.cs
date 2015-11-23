using SteamWebAPI2.Models.DOTA2;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamWebAPI2
{
    public class DOTA2Econ : SteamWebInterface
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
        public async Task GetSteamAccountValidForEventAsync(int eventId, long steamId, string language = "")
        {
            throw new NotImplementedException("I can't find good test conditions for this, so I don't know how to implement a response parser.");
        }

        public async Task<IReadOnlyCollection<GameItem>> GetGameItemsAsync(string language = "")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            AddToParametersIfHasValue("language", language, parameters);

            var teamInfos = await CallMethodAsync<GameItemResultContainer>("GetGameItems", 1);
            return new ReadOnlyCollection<GameItem>(teamInfos.Result.Items);
        }

        public async Task<IReadOnlyCollection<Hero>> GetHeroesAsync(string language = "", bool itemizedOnly = false)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            int itemizedOnlyValue = itemizedOnly ? 1 : 0;

            AddToParametersIfHasValue("language", language, parameters);
            AddToParametersIfHasValue("itemizedonly", itemizedOnlyValue, parameters);

            var teamInfos = await CallMethodAsync<HeroResultContainer>("GetHeroes", 1);
            return new ReadOnlyCollection<Hero>(teamInfos.Result.Heroes);
        }
    }
}
