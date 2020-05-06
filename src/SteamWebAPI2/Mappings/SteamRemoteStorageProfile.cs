using System.Collections.Generic;
using AutoMapper;
using Steam.Models;
using SteamWebAPI2.Models;
using System.Linq;
using System;

namespace SteamWebAPI2.Mappings
{
    public class SteamRemoteStorageProfile : Profile
    {
        public SteamRemoteStorageProfile()
        {
            CreateMap<uint, PublishedFileVisibility>()
                .ConvertUsing((src, dest) =>
                {
                    return (PublishedFileVisibility)src;
                });
            CreateMap<PublishedFileDetails, PublishedFileDetailsModel>()
                .ForMember(dest => dest.FileUrl, opts => opts.MapFrom(source => !string.IsNullOrWhiteSpace(source.FileUrl) ? new Uri(source.FileUrl) : null))
                .ForMember(dest => dest.PreviewUrl, opts => opts.MapFrom(source => !string.IsNullOrWhiteSpace(source.PreviewUrl) ? new Uri(source.PreviewUrl) : null));
            CreateMap<PublishedFileDetailsResultContainer, IReadOnlyCollection<PublishedFileDetailsModel>>()
                .ConvertUsing((src, dest, context) =>
                    context.Mapper.Map<IList<PublishedFileDetails>, IReadOnlyCollection<PublishedFileDetailsModel>>(
                        src.Result?.Result == 1 ? src.Result.Details : null
                    )
                );
            CreateMap<PublishedFileDetailsResultContainer, PublishedFileDetailsModel>()
                .ConvertUsing((src, dest, context) => 
                    context.Mapper.Map<PublishedFileDetails, PublishedFileDetailsModel>(
                        src.Result?.Result == 1 ? src.Result.Details?.SingleOrDefault() : null
                    )
                );

            CreateMap<UGCFileDetails, UGCFileDetailsModel>();
            CreateMap<UGCFileDetailsResultContainer, UGCFileDetailsModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<UGCFileDetails, UGCFileDetailsModel>(src.Result)
            );
        }
    }
}