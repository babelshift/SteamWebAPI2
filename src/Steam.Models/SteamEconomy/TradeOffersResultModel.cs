using System.Collections.Generic;

namespace Steam.Models.SteamEconomy
{
    public class TradeOffersResultModel
    {
        /// <summary>
        /// If get_sent_offers was set, this will be an array of CEcon_TradeOffer values that you have sent.
        /// </summary>
        public IList<TradeOfferModel> TradeOffersSent { get; set; }

        /// <summary>
        /// If get_received_offers was set, this will be an array of CEcon_TradeOffer values that have been sent to you.
        /// </summary>
        public IList<TradeOfferModel> TradeOffersReceived { get; set; }

        /// <summary>
        /// If get_descriptions was set, this will be a list of item display information. This is associated with the data in the items_to_receive and items_to_give lists via the classid / instanceid identifier pair.
        /// </summary>
        public IList<string> Descriptions { get; set; }
    }
}