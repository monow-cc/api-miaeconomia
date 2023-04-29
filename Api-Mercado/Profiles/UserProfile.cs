using Api_Mercado.Model;
using Api_Mercado.VOs.Enter.Market;
using Api_Mercado.VOs.Enter.User;
using AutoMapper;

namespace Api_Mercado.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserVOEnter, User>()
               .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Name))
               .ForPath(dest => dest.Email, opts => opts.MapFrom(x => x.Email))
               .ForPath(dest => dest.Password, opts => opts.MapFrom(x => x.Password));
        }
    }
}
