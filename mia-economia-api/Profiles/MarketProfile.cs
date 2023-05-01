using AutoMapper;
using miaEconomiaApi.Model;
using miaEconomiaApi.VOs.Enter.Market;

namespace miaEconomiaApi.Profiles
{
    public class MarketProfile : Profile
    {
        public MarketProfile()
        {
            CreateMap<MarketVOEnter, Market>()
                .ForPath(dest => dest.MarketName, opts => opts.MapFrom(x => x.MarketName))
                .ForPath(dest => dest.Email, opts => opts.MapFrom(x => x.Email))
                .ForPath(dest => dest.Password, opts => opts.MapFrom(x => x.Password))
                .ForPath(dest => dest.Region, opts => opts.MapFrom(x => x.Region));
        }
    }
}
