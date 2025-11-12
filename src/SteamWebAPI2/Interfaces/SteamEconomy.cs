
using Steam.Models.SteamEconomy;
using SteamWebAPI2.Models.SteamEconomy;
using SteamWebAPI2.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SteamWebAPI2.Interfaces
{
    public class SteamEconomy : ISteamEconomy
    {
        private readonly ISteamWebInterface steamWebInterface;

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebApiKey"></param>
        public SteamEconomy(ISteamWebRequest steamWebRequest, ISteamWebInterface steamWebInterface = null)
        {
            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("ISteamEconomy", steamWebRequest)
                : steamWebInterface;
        }

        /// <summary>
        /// Returns some economic meta data regarding item qualities, levels, rarities, and more.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="classIds"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<AssetClassInfoResultModel>> GetAssetClassInfoAsync(uint appId, IReadOnlyList<ulong> classIds, string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(classIds.Count, "class_count");

            for (int i = 0; i < classIds.Count; i++)
            {
                parameters.AddIfHasValue(classIds[i], string.Format("classid{0}", i));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<AssetClassInfoResultContainer>("GetAssetClassInfo", 1, parameters);

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new AssetClassInfoResultModel
                {
                    Success = result.Success,
                    AssetClasses = result.AssetClasses?.Select(ac => new AssetClassInfoModel
                    {
                        ClassId = ac.ClassId,
                        Name = ac.Name,
                        MarketName = ac.MarketName,
                        Type = ac.Type,
                        MarketHashName = ac.MarketHashName,
                        Descriptions = ac.Descriptions?.Select(d => new AssetClassDescriptionModel
                        {
                            Value = d.Value,
                            Color = d.Color,
                            Type = d.Type,
                            AppData = d.AppData
                        }).ToList().AsReadOnly(),
                        Tradable = ac.Tradable,
                        Marketable = ac.Marketable,
                        Tags = ac.Tags?.Select(t => new AssetClassTagModel
                        {
                            Category = t.Category,
                            InternalName = t.InternalName,
                            Name = t.Name,
                            Color = t.Color,
                            CategoryName = t.CategoryName
                        }).ToList().AsReadOnly(),
                        Actions = ac.Actions?.Select(a => new AssetClassActionModel
                        {
                            Name = a.Name,
                            Link = a.Link
                        }).ToList().AsReadOnly(),
                        MarketActions = ac.MarketActions?.Select(ma => new AssetClassMarketActionModel
                        {
                            Name = ma.Name,
                            Link = ma.Link
                        }).ToList().AsReadOnly(),
                        Commodity = ac.Commodity,
                        BackgroundColor = ac.BackgroundColor,
                        IconUrl = ac.IconUrl,
                        IconUrlLarge = ac.IconUrlLarge,
                        FraudWarnings = ac.FraudWarnings,
                        AppData = ac.AppData == null ? null : new AssetClassAppDataModel
                        {
                            DefIndex = ac.AppData.DefIndex,
                            FilterData = ac.AppData.FilterData?.Select(fd => new AssetClassAppDataFilterModel
                            {
                                ElementIds = fd.ElementIds?.ToList().AsReadOnly(),
                            }).ToList().AsReadOnly(),
                            HighlightColor = ac.AppData.HighlightColor,
                            PlayerClassIds = ac.AppData.PlayerClassIds?.ToList().AsReadOnly(),
                            Quality = ac.AppData.Quality,
                            Slot = ac.AppData.Slot
                        },
                        IconDragUrl = ac.IconDragUrl,
                        MarketMarketableRestriction = ac.MarketMarketableRestriction,
                        MarketTradableRestriction = ac.MarketTradableRestriction,
                        NameColor = ac.NameColor
                    }).ToList().AsReadOnly()
                };
            });
        }

        /// <summary>
        /// Returns economic asset prices.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="currency"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<AssetPriceResultModel>> GetAssetPricesAsync(uint appId, string currency = "", string language = "en_us")
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(appId, "appid");
            parameters.AddIfHasValue(currency, "currency");
            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<AssetPriceResultContainer>("GetAssetPrices", 1, parameters);

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new AssetPriceResultModel
                {
                    Success = result.Success,
                    Assets = result.Assets?.Select(a => new AssetModel
                    {
                        Class = a.Class?.Select(c => new AssetClassModel
                        {
                            Name = c.Name,
                            Value = c.Value
                        }).ToList().AsReadOnly(),
                        ClassId = a.ClassId,
                        Date = a.Date,
                        Name = a.Name,
                        Prices = a.Prices == null ? null : new AssetPricesModel
                        {
                            USD = a.Prices.USD,
                            GBP = a.Prices.GBP,
                            EUR = a.Prices.EUR,
                            RUB = a.Prices.RUB,
                            CNY = a.Prices.CNY,
                            JPY = a.Prices.JPY,
                            KRW = a.Prices.KRW,
                            AUD = a.Prices.AUD,
                            CAD = a.Prices.CAD,
                            NZD = a.Prices.NZD,
                            MXN = a.Prices.MXN,
                            BRL = a.Prices.BRL,
                            SGD = a.Prices.SGD,
                            THB = a.Prices.THB,
                            VND = a.Prices.VND,
                            IDR = a.Prices.IDR,
                            MYR = a.Prices.MYR,
                            PHP = a.Prices.PHP,
                            NOK = a.Prices.NOK,
                            TRY = a.Prices.TRY,
                            UAH = a.Prices.UAH,
                            AED = a.Prices.AED,
                            SAR = a.Prices.SAR,
                            ZAR = a.Prices.ZAR,
                            HKD = a.Prices.HKD,
                            INR = a.Prices.INR,
                            TWD = a.Prices.TWD
                        },
                        TagIds = a.TagIds.ToList().AsReadOnly(),
                        Tags = a.Tags.ToList().AsReadOnly()
                    }).ToList().AsReadOnly(),
                    TagIds = result.TagIds == null ? null : new AssetTagIdsModel
                    {
                        Tag0 = result.TagIds.Tag0,
                        Tag1 = result.TagIds.Tag1,
                        Tag2 = result.TagIds.Tag2,
                        Tag3 = result.TagIds.Tag3,
                        Tag4 = result.TagIds.Tag4,
                        Tag5 = result.TagIds.Tag5,
                        Tag6 = result.TagIds.Tag6,
                        Tag7 = result.TagIds.Tag7,
                        Tag8 = result.TagIds.Tag8
                    },
                    Tags = result.Tags == null ? null : new AssetTagsModel
                    {
                        Cosmetics = result.Tags.Cosmetics,
                        Bundles = result.Tags.Bundles,
                        Halloween = result.Tags.Halloween,
                        Limited = result.Tags.Limited,
                        Maps = result.Tags.Maps,
                        New = result.Tags.New,
                        Taunts = result.Tags.Taunts,
                        Tools = result.Tags.Tools,
                        Weapons = result.Tags.Weapons
                    }
                };
            });
        }
    }
}