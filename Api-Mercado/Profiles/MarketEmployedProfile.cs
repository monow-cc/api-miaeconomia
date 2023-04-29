using Api_Mercado.Model;
using Api_Mercado.VOs.Exit.MarketEmployed;
using AutoMapper;

namespace Api_Mercado.Profiles
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
