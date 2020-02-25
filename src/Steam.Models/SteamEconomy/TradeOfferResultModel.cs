using System.Collections.Generic;

namespace Steam.Models.SteamEconomy
{
    public class TradeOfferResultModel
    {
        /// <summary>
        /// A CEcon_TradeOffer representing the offer
        /// </summary>
        public TradeOfferModel TradeOffer { get; set; }

        /// <summary>
        /// If language was set, this will be a list of item display information. This is associated with the data in the items_to_receive and items_to_give lists via the classid / instanceid identifier pair.
        /// </summary>
        public IList<string> Descriptions { get; set; }
    }
}