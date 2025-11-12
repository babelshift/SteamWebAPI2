using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Steam.Models.GameEconomy;
using SteamWebAPI2.Models.GameEconomy;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Interfaces
{
    public class EconItems : IEconItems
    {
        private readonly ISteamWebInterface steamWebInterface;

        private uint appId;

        // The API only exposes certain methods for certain App Ids in the EconItems interface
        // I'm hard coding the values for now until I come up with a better, more dynamic solution
        private List<uint> validSchemaAppIds = new List<uint>();
        private List<uint> validSchemaUrlAppIds = new List<uint>();
        private List<uint> validStoreMetaDataAppIds = new List<uint>();
        private List<uint> validStoreStatusAppIds = new List<uint>();

        /// <summary>
        /// Default constructor established the Steam Web API key and initializes for subsequent method calls
        /// </summary>
        /// <param name="steamWebRequest"></param>
        public EconItems(ISteamWebRequest steamWebRequest, AppId appId, ISteamWebInterface steamWebInterface = null)
        {
            if (appId <= 0)
            {
                throw new ArgumentOutOfRangeException("appId");
            }

            this.steamWebInterface = steamWebInterface == null
                ? new SteamWebInterface("IEconItems_" + (uint)appId, steamWebRequest)
                : steamWebInterface;

            this.appId = (uint)appId;

            validSchemaAppIds.Add((uint)AppId.TeamFortress2);
            validSchemaAppIds.Add((uint)AppId.Dota2);
            validSchemaAppIds.Add((uint)AppId.Portal2);
            validSchemaAppIds.Add((uint)AppId.Portal2_Beta);
            validSchemaAppIds.Add((uint)AppId.CounterStrikeGO);

            validSchemaUrlAppIds.Add((uint)AppId.TeamFortress2);
            validSchemaUrlAppIds.Add((uint)AppId.Dota2);
            validSchemaUrlAppIds.Add((uint)AppId.CounterStrikeGO);

            validStoreMetaDataAppIds.Add((uint)AppId.TeamFortress2);
            validStoreMetaDataAppIds.Add((uint)AppId.Dota2);
            validStoreMetaDataAppIds.Add((uint)AppId.CounterStrikeGO);

            validStoreStatusAppIds.Add((uint)AppId.TeamFortress2);
        }

        /// <summary>
        /// Returns all player earned Steam items for a specific Steam user.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<EconItemResultModel>> GetPlayerItemsAsync(ulong steamId)
        {
            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(steamId, "steamid");

            var steamWebResponse = await steamWebInterface.GetAsync<EconItemResultContainer>("GetPlayerItems", 1, parameters);

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new EconItemResultModel
                {
                    Status = result.Status,
                    NumBackpackSlots = result.NumBackpackSlots,
                    Items = result.Items?.Select(i => new EconItemModel
                    {
                        Id = i.Id,
                        OriginalId = i.OriginalId,
                        DefIndex = i.DefIndex,
                        Level = i.Level,
                        Quality = i.Quality,
                        Inventory = i.Inventory,
                        Quantity = i.Quantity,
                        Origin = i.Origin,
                        Equipped = i.Equipped?.Select(e => new EconItemEquippedModel
                        {
                            ClassId = e.ClassId,
                            Slot = e.Slot
                        }).ToList().AsReadOnly(),
                        Style = i.Style,
                        Attributes = i.Attributes?.Select(a => new EconItemAttributeModel
                        {
                            DefIndex = a.DefIndex,
                            Value = a.Value,
                            FloatValue = a.FloatValue,
                            AccountInfo = a.AccountInfo == null ? null : new EconItemAttributeAccountInfoModel
                            {
                                SteamId = a.AccountInfo.SteamId,
                                PersonaName = a.AccountInfo.PersonaName
                            }
                        }).ToList().AsReadOnly(),
                        FlagCannotTrade = i.FlagCannotTrade,
                        FlagCannotCraft = i.FlagCannotCraft
                    }).ToList().AsReadOnly()
                };
            });
        }

        /// <summary>
        /// Returns the item schema for TF2 specifically.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SchemaItemsResultContainer>> GetSchemaItemsForTF2Async(string language = "en_us", uint? start = null)
        {
            if (appId != (int)AppId.TeamFortress2)
            {
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetSchemaTF2 method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");
            parameters.AddIfHasValue(start, "start");

            var steamWebResponse = await steamWebInterface.GetAsync<SchemaItemsResultContainer>("GetSchemaItems", 1, parameters);

            return steamWebResponse;
        }

        /// <summary>
        /// Returns the schema overview for TF2 specifically.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<SchemaOverviewResultContainer>> GetSchemaOverviewForTF2Async(string language = "en_us")
        {
            if (appId != (int)AppId.TeamFortress2)
            {
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetSchemaTF2 method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<SchemaOverviewResultContainer>("GetSchemaOverview", 1, parameters);

            return steamWebResponse;
        }

        /// <summary>
        /// Returns a URL which can be used to access the economy / item schema for a specific App ID.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<string>> GetSchemaUrlAsync()
        {
            if (!validSchemaUrlAppIds.Contains(appId))
            {
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetSchemaUrl method.", appId));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<SchemaUrlResultContainer>("GetSchemaURL", 1);

            return steamWebResponse.MapTo((from) =>
            {
                return from?.Result?.ItemsGameUrl;
            });
        }

        /// <summary>
        /// Returns some store meta data for a specific App ID such as banner placement, image placement, drop down behaviors, and more. This seems to drive the game's store pages.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public async Task<ISteamWebResponse<StoreMetaDataModel>> GetStoreMetaDataAsync(string language = "")
        {
            if (!validStoreMetaDataAppIds.Contains(appId))
            {
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetStoreMetaData method.", appId));
            }

            List<SteamWebRequestParameter> parameters = new List<SteamWebRequestParameter>();

            parameters.AddIfHasValue(language, "language");

            var steamWebResponse = await steamWebInterface.GetAsync<StoreMetaDataResultContainer>("GetStoreMetaData", 1, parameters);

            return steamWebResponse.MapTo((from) =>
            {
                var result = from?.Result;
                if (result == null)
                {
                    return null;
                }

                return new StoreMetaDataModel
                {
                    CarouselData = result.CarouselData == null ? null : new StoreCarouselDataModel
                    {
                        Banners = result.CarouselData.Banners?.Select(b => new StoreBannerModel
                        {
                            BaseFileName = b.BaseFileName,
                            Action = b.Action,
                            Placement = b.Placement,
                            ActionParam = b.ActionParam
                        }).ToList().AsReadOnly(),
                        MaxDisplayBanners = result.CarouselData.MaxDisplayBanners
                    },
                    Tabs = result.Tabs?.Select(t => new StoreTabModel
                    {
                        Children = t.Children?.Select(c => new StoreTabChildModel
                        {
                            Name = t.ParentName,
                            Id = t.Id,
                        }).ToList().AsReadOnly(),
                        Default = t.Default,
                        Home = t.Home,
                        DropdownPrefabId = t.DropdownPrefabId,
                        Id = t.Id,
                        Label = t.Label,
                        ParentId = t.ParentId,
                        ParentName = t.ParentName,
                        UseLargeCells = t.UseLargeCells
                    }).ToList().AsReadOnly(),
                    DropdownData = result.DropdownData == null ? null : new StoreDropdownDataModel
                    {
                        Dropdowns = result.DropdownData.Dropdowns?.Select(d => new StoreDropdownModel
                        {
                            Id = d.Id,
                            Name = d.Name,
                            LabelText = d.LabelText,
                            Type = d.Type,
                            UrlHistoryParamName = d.UrlHistoryParamName
                        }).ToList().AsReadOnly(),
                        Prefabs = result.DropdownData.Prefabs.Select(p => new StorePrefabModel
                        {
                            Id = p.Id,
                            Name = p.Name,
                            Config = p.Config?.Select(c => new StoreConfigModel
                            {
                                DefaultSelectionId = c.DefaultSelectionId,
                                DropdownId = c.DropdownId,
                                Enabled = c.Enabled,
                                Name = c.Name
                            }).ToList().AsReadOnly()
                        }).ToList().AsReadOnly()
                    },
                    Filters = result.Filters?.Select(f => new StoreFilterModel
                    {
                        Id = f.Id,
                        Name = f.Name,
                        UrlHistoryParamName = f.UrlHistoryParamName,
                        Count = f.Count,
                        AllElement = f.AllElement == null ? null : new StoreFilterAllElementModel
                        {
                            Id = f.AllElement.Id,
                            LocalizedText = f.AllElement.LocalizedText
                        },
                        Elements = f.Elements?.Select(e => new StoreFilterElementModel
                        {
                            Id = e.Id,
                            LocalizedText = e.LocalizedText,
                            Name = e.Name
                        }).ToList().AsReadOnly()
                    }).ToList().AsReadOnly(),
                    HomePageData = result.HomePageData == null ? null : new StoreHomePageDataModel
                    {
                        HomeCategoryId = result.HomePageData.HomeCategoryId,
                        PopularItems = result.HomePageData.PopularItems?.Select(i => new StorePopularItemModel
                        {
                            DefIndex = i.DefIndex,
                            Order = i.Order,
                        }).ToList().AsReadOnly()
                    },
                    PlayerClassData = result.PlayerClassData?.Select(pc => new StorePlayerClassDataModel
                    {
                        BaseName = pc.BaseName,
                        Id = pc.Id,
                        LocalizedText = pc.LocalizedText
                    }).ToList().AsReadOnly(),
                    Sorting = result.Sorting == null ? null : new StoreSortingModel
                    {
                        Sorters = result.Sorting.Sorters?.Select(s => new StoreSorterModel
                        {
                            Id = s.Id,
                            Name = s.Name,
                            DataType = s.DataType,
                            LocalizedText = s.LocalizedText,
                            SortField = s.SortField,
                            SortReversed = s.SortReversed
                        }).ToList().AsReadOnly(),
                        SortingPrefabs = result.Sorting.SortingPrefabs?.Select(sp => new StoreSortingPrefabModel
                        {
                            Id = sp.Id,
                            Name = sp.Name,
                            UrlHistoryParamName = sp.UrlHistoryParamName,
                            SorterIds = sp.SorterIds?.Select(si => new StoreSorterIdModel
                            {
                                Id = si.Id
                            }).ToList().AsReadOnly()
                        }).ToList().AsReadOnly()
                    }
                };
            });
        }

        /// <summary>
        /// Returns a status indicator of the current status of a specific App ID.
        /// </summary>
        /// <returns></returns>
        public async Task<ISteamWebResponse<uint>> GetStoreStatusAsync()
        {
            if (!validStoreStatusAppIds.Contains(appId))
            {
                throw new InvalidOperationException(string.Format("AppId {0} is not valid for the GetStoreStatus method.", appId));
            }

            var steamWebResponse = await steamWebInterface.GetAsync<StoreStatusResultContainer>("GetStoreStatus", 1);

            return steamWebResponse.MapTo((from) =>
            {
                return from?.Result?.StoreStatus ?? 0;
            });
        }
    }
}