using AutoMapper;
using miaEconomiaApi.Model;
using miaEconomiaApi.VOs.Exit.MarketEmployed;

namespace miaEconomiaApi.Profiles
{
    public class MarketEmployedProfile : Profile
    {
        public MarketEmployedProfile()
        {
            CreateMap<MarketEmployed, MarketEmployedVOExit>()
                .ForPath(dest => dest.MarketId, opts => opts.MapFrom(x => x.MarketId))
                .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Market.MarketName));
        }
    }
}
