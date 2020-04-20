using AutoMapper;
using Steam.Models.GameServers;
using SteamWebAPI2.Models.GameServers;
using SteamWebAPI2.Utilities;

namespace SteamWebAPI2.Mappings
{
    public class GameServersProfile : Profile
    {
        public GameServersProfile()
        {
            CreateMap<AccountListContainer, AccountListModel>().ConvertUsing((src, dest, context) =>
                context.Mapper.Map<AccountList, AccountListModel>(src.Response)
            );
            
            CreateMap<AccountList, AccountListModel>()
                .ForMember(dest => dest.LastActionTime, opts => opts.MapFrom(src => src.LastActionTime.ToDateTime()));
            
            CreateMap<AccountServer, AccountServerModel>()
                .ForMember(dest => dest.RtLastLogon, opts => opts.MapFrom(src => src.RtLastLogon.ToDateTime()));

            CreateMap<CreateAccountContainer, CreateAccountModel>().ConvertUsing((src, dest, context) => 
                context.Mapper.Map<CreateAccount, CreateAccountModel>(src.Response)
            );

            CreateMap<CreateAccount, CreateAccountModel>();

            CreateMap<ResetLoginTokenContainer, string>().ConvertUsing(
                src => src.Response.LoginToken
            );

            CreateMap<AccountPublicInfoContainer, AccountPublicInfoModel>().ConvertUsing((src, dest, context) => 
                context.Mapper.Map<AccountPublicInfo, AccountPublicInfoModel>(src.Response)
            );

            CreateMap<AccountPublicInfo, AccountPublicInfoModel>();

            CreateMap<QueryLoginTokenContainer, QueryLoginTokenModel>().ConvertUsing((src, dest, context) => 
                context.Mapper.Map<QueryLoginTokenResponse, QueryLoginTokenModel>(src.Response)
            );

            CreateMap<QueryLoginTokenResponse, QueryLoginTokenModel>();
        }
    }
}