using System;
using AutoMapper;
using Steam.Models.SteamEconomy;
using SteamWebAPI2.Models.SteamEconomy;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Mappings
{
    public class EconServiceProfile : Profile
    {
        public EconServiceProfile()
        {
            CreateMap<Steam.Models.SteamEconomy.TradeStatus, Steam.Models.SteamEconomy.TradeStatus>();
            CreateMap<Steam.Models.SteamEconomy.TradeOfferState, Steam.Models.SteamEconomy.TradeOfferState>();
            CreateMap<Steam.Models.SteamEconomy.TradeOfferConfirmationMethod, Steam.Models.SteamEconomy.TradeOfferConfirmationMethod>();
            CreateMap<TradeAsset, TradeAssetModel>();
            CreateMap<TradedAsset, TradedAssetModel>();
            CreateMap<TradedCurrency, TradedCurrencyModel>();
            CreateMap<Trade, TradeModel>()
                .ForMember(dest => dest.TimeTradeStarted, opts => opts.MapFrom(source => source.TimeTradeStarted.ToDateTime()))
                .ForMember(dest => dest.TimeEscrowEnds, opts => opts.MapFrom(source => source.TimeEscrowEnds.ToDateTime()));
            CreateMap<TradeOffer, TradeOfferModel>()
                .ForMember(dest => dest.TimeCreated, opts => opts.MapFrom(source => source.TimeCreated.ToDateTime()))
                .ForMember(dest => dest.TimeEscrowEnds, opts => opts.MapFrom(source => source.TimeEscrowEnds.ToDateTime()))
                .ForMember(dest => dest.TimeExpiration, opts => opts.MapFrom(source => source.TimeExpiration.ToDateTime()))
                .ForMember(dest => dest.TimeUpdated, opts => opts.MapFrom(source => source.TimeUpdated.ToDateTime()));
            CreateMap<TradeHistoryResult, TradeHistoryModel>();
            CreateMap<TradeOfferResult, TradeOfferResultModel>();
            CreateMap<TradeOffersResult, TradeOffersResultModel>();
            CreateMap<TradeHistoryResultContainer, TradeHistoryModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<TradeHistoryResult, TradeHistoryModel>(src.Result)
            );
            CreateMap<TradeOfferResultContainer, TradeOfferResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<TradeOfferResult, TradeOfferResultModel>(src.Result)
            );
            CreateMap<TradeOffersResultContainer, TradeOffersResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<TradeOffersResult, TradeOffersResultModel>(src.Result)
            );
            CreateMap<TradeHoldDurationsResultContainer, TradeHoldDurationsResultModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<TradeHoldDurationsResult, TradeHoldDurationsResultModel>(src.Result)
            );
            CreateMap<TradeHoldDurationsResult, TradeHoldDurationsResultModel>();
            CreateMap<TradeHoldDurations, TradeHoldDurationsModel>()
                .ForMember(dest => dest.EscrowEndDate, 
                    opts => opts.MapFrom(src => src.EscrowEndDateRfc3339))
                .ForMember(dest => dest.EscrowEndDuration, 
                    opts => opts.MapFrom(src => TimeSpan.FromSeconds(src.EscrowEndDurationSeconds)));
        }
    }
}