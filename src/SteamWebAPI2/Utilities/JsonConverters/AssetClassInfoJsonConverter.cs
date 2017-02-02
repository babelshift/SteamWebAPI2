using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SteamWebAPI2.Models.SteamEconomy;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SteamWebAPI2.Utilities.JsonConverters
{
    /// <summary>
    /// Handles manual deserialization of the response from ISteamEconomy/GetAssetClassInfo.
    /// I could not rely on automatic deserialization with property attribute decorators because the JSON structure of the response is completely awful.
    /// Instead of using JSON arrays, the JSON response contains multiple dynamically built objects with varying numbers of properties whose values correspond to
    /// what appear to be arrays indices. The response appears to be a conversion from Valve Data Format (VDF) to JSON.
    /// So to clean this up, I manually deserialize into objects that aren't awful.
    ///
    /// Example of the bad JSON response:
    /// "descriptions": {
    ///		"0": {
    ///	        "type": "text",
    ///			"value": "Paint Color: Color No. 216-190-216",
    ///		    "color": "756b5e",
    ///         "app_data": ""
    ///	       },
    ///     "1": {
    ///         "type": "text",
    ///		    "value": "You wouldn't mind if I read this top secret document with my beard, would you?",
    ///		    "app_data": ""
    ///     }
    /// }
    ///
    /// You can see in the above that the properties "0" and "1" seem to be array indices. Each AssetClassInfo in the response can have a varying number of these
    /// properties. So I fixed that by deserializing into sane arrays.
    /// </summary>
    internal class AssetClassInfoJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            JObject o = JObject.Load(reader);

            AssetClassInfoResult result = new AssetClassInfoResult();
            List<AssetClassInfo> assetClasses = new List<AssetClassInfo>();

            foreach (var assetClassRootProperty in o.Children<JProperty>())
            {
                if (assetClassRootProperty.Name == "success") { result.Success = bool.Parse(assetClassRootProperty.Value.ToString()); }
                else
                {
                    AssetClassInfo assetClassInfo = new AssetClassInfo();
                    List<AssetClassDescription> descriptions = new List<AssetClassDescription>();
                    List<AssetClassAction> actions = new List<AssetClassAction>();
                    List<AssetClassMarketAction> marketActions = new List<AssetClassMarketAction>();
                    List<AssetClassTag> tags = new List<AssetClassTag>();

                    foreach (var assetClassProperty in assetClassRootProperty.Value.Children<JProperty>())
                    {
                        string name = assetClassProperty.Name;
                        string value = assetClassProperty.Value.ToString();

                        ulong ulongValue = 0;
                        ulong.TryParse(value, out ulongValue);

                        if (name == "icon_url") { assetClassInfo.IconUrl = value; }
                        if (name == "icon_url_large") { assetClassInfo.IconUrlLarge = value; }
                        if (name == "icon_drag_url") { assetClassInfo.IconDragUrl = value; }
                        if (name == "name") { assetClassInfo.Name = value; }
                        if (name == "market_hash_name") { assetClassInfo.MarketHashName = value; }
                        if (name == "market_name") { assetClassInfo.MarketName = value; }
                        if (name == "name_color") { assetClassInfo.NameColor = value; }
                        if (name == "background_color") { assetClassInfo.BackgroundColor = value; }
                        if (name == "type") { assetClassInfo.Type = value; }
                        if (name == "tradable") { assetClassInfo.Tradable = value; }
                        if (name == "marketable") { assetClassInfo.Marketable = value; }
                        if (name == "commodity") { assetClassInfo.Commodity = value; }
                        if (name == "market_tradable_restriction") { assetClassInfo.MarketTradableRestriction = value; }
                        if (name == "market_marketable_restriction") { assetClassInfo.MarketMarketableRestriction = value; }
                        if (name == "fraudwarnings") { assetClassInfo.FraudWarnings = value; }
                        if (name == "classid") { assetClassInfo.ClassId = ulongValue; }

                        #region Parse Descriptions Objects

                        if (name == "descriptions")
                        {
                            foreach (var assetClassDescriptionProperty in assetClassProperty.Value.Children<JProperty>())
                            {
                                AssetClassDescription description = new AssetClassDescription();

                                foreach (var assetClassDescriptionDetailProperty in assetClassDescriptionProperty.Value.Children<JProperty>())
                                {
                                    if (assetClassDescriptionDetailProperty.Name == "type") { description.Type = assetClassDescriptionDetailProperty.Value.ToString(); }
                                    if (assetClassDescriptionDetailProperty.Name == "value") { description.Value = assetClassDescriptionDetailProperty.Value.ToString(); }
                                    if (assetClassDescriptionDetailProperty.Name == "color") { description.Color = assetClassDescriptionDetailProperty.Value.ToString(); }
                                    if (assetClassDescriptionDetailProperty.Name == "app_data") { description.AppData = assetClassDescriptionDetailProperty.Value.ToString(); }
                                }

                                descriptions.Add(description);
                            }
                        }

                        #endregion Parse Descriptions Objects

                        #region Parse Actions Objects

                        if (name == "actions")
                        {
                            foreach (var assetClassActionProperty in assetClassProperty.Value.Children<JProperty>())
                            {
                                AssetClassAction action = new AssetClassAction();

                                foreach (var assetClassActionDetailProperty in assetClassActionProperty.Value.Children<JProperty>())
                                {
                                    if (assetClassActionDetailProperty.Name == "name") { action.Name = assetClassActionDetailProperty.Value.ToString(); }
                                    if (assetClassActionDetailProperty.Name == "link") { action.Link = assetClassActionDetailProperty.Value.ToString(); }
                                }

                                actions.Add(action);
                            }
                        }

                        #endregion Parse Actions Objects

                        #region Parse Market Actions Objects

                        if (name == "market_actions")
                        {
                            foreach (var assetClassMarketActionProperty in assetClassProperty.Value.Children<JProperty>())
                            {
                                AssetClassMarketAction marketAction = new AssetClassMarketAction();

                                foreach (var assetClassMarketActionDetailProperty in assetClassMarketActionProperty.Value.Children<JProperty>())
                                {
                                    if (assetClassMarketActionDetailProperty.Name == "name") { marketAction.Name = assetClassMarketActionDetailProperty.Value.ToString(); }
                                    if (assetClassMarketActionDetailProperty.Name == "link") { marketAction.Link = assetClassMarketActionDetailProperty.Value.ToString(); }
                                }

                                marketActions.Add(marketAction);
                            }
                        }

                        #endregion Parse Market Actions Objects

                        #region Parse Tags Objects

                        if (name == "tags")
                        {
                            foreach (var assetClassTagProperty in assetClassProperty.Value.Children<JProperty>())
                            {
                                AssetClassTag tag = new AssetClassTag();

                                foreach (var assetClassTagDetailProperty in assetClassTagProperty.Value.Children<JProperty>())
                                {
                                    if (assetClassTagDetailProperty.Name == "name") { tag.Name = assetClassTagDetailProperty.Value.ToString(); }
                                    if (assetClassTagDetailProperty.Name == "internal_name") { tag.InternalName = assetClassTagDetailProperty.Value.ToString(); }
                                    if (assetClassTagDetailProperty.Name == "category") { tag.Category = assetClassTagDetailProperty.Value.ToString(); }
                                    if (assetClassTagDetailProperty.Name == "color") { tag.Color = assetClassTagDetailProperty.Value.ToString(); }
                                    if (assetClassTagDetailProperty.Name == "category_name") { tag.CategoryName = assetClassTagDetailProperty.Value.ToString(); }
                                }

                                tags.Add(tag);
                            }
                        }

                        #endregion Parse Tags Objects

                        #region Parse AppData Object

                        if (name == "app_data")
                        {
                            AssetClassAppData appData = new AssetClassAppData();

                            foreach (var assetClassAppDataProperty in assetClassProperty.Value.Children<JProperty>())
                            {
                                uint uintValue = 0;
                                uint.TryParse(assetClassAppDataProperty.Value.ToString(), out uintValue);

                                if (assetClassAppDataProperty.Name == "def_index") { appData.DefIndex = uintValue; }
                                if (assetClassAppDataProperty.Name == "quality") { appData.Quality = assetClassAppDataProperty.Value.ToString(); }
                                if (assetClassAppDataProperty.Name == "slot") { appData.Slot = assetClassAppDataProperty.Value.ToString(); }
                                if (assetClassAppDataProperty.Name == "highlight_color") { appData.HighlightColor = assetClassAppDataProperty.Value.ToString(); }

                                if (assetClassAppDataProperty.Name == "filter_data")
                                {
                                    List<AssetClassAppDataFilter> filters = new List<AssetClassAppDataFilter>();

                                    foreach (var assetClassAppDataFilterProperty in assetClassAppDataProperty.Value.Children<JProperty>())
                                    {
                                        AssetClassAppDataFilter filter = new AssetClassAppDataFilter();

                                        foreach (var assetClassAppDataFilterDetailProperty in assetClassAppDataFilterProperty.Value.Children<JProperty>())
                                        {
                                            if (assetClassAppDataFilterDetailProperty.Name == "element_ids")
                                            {
                                                List<long> elementIds = new List<long>();

                                                foreach (var elementId in assetClassAppDataFilterDetailProperty.Value.Children<JProperty>())
                                                {
                                                    elementIds.Add(long.Parse(elementId.Value.ToString()));
                                                }

                                                filter.ElementIds = elementIds;
                                            }
                                        }

                                        filters.Add(filter);
                                    }

                                    appData.FilterData = filters;
                                }

                                if (assetClassAppDataProperty.Name == "player_class_ids")
                                {
                                    List<ulong> playerClassIds = new List<ulong>();

                                    foreach (var assetClassAppDataPlayerClassIdProperty in assetClassAppDataProperty.Value.Children<JProperty>())
                                    {
                                        ulong.TryParse(assetClassAppDataPlayerClassIdProperty.Value.ToString(), out ulongValue);
                                        playerClassIds.Add(ulongValue);
                                    }

                                    appData.PlayerClassIds = playerClassIds;
                                }
                            }

                            assetClassInfo.AppData = appData;
                        }

                        #endregion Parse AppData Object
                    }

                    assetClassInfo.Descriptions = descriptions;
                    assetClassInfo.Actions = actions;
                    assetClassInfo.MarketActions = marketActions;
                    assetClassInfo.Tags = tags;
                    assetClasses.Add(assetClassInfo);
                }
            }

            result.AssetClasses = assetClasses;

            return result;
        }

        public override bool CanWrite { get { return false; } }

        public override bool CanConvert(Type objectType)
        {
            return typeof(AssetClassInfoResult).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }
    }
}