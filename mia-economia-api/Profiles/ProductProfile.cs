using AutoMapper;
using miaEconomiaApi.Model;
using miaEconomiaApi.VOs.Enter.Products;
using miaEconomiaApi.VOs.Exit.Products;

namespace miaEconomiaApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductVOEnter, Product>()
                .ForPath(dest => dest.MarketId, opts => opts.MapFrom(o => o.MarketId))
                .ForPath(dest => dest.BarCode, opts => opts.MapFrom(o => o.BarCode))
                .ForPath(dest => dest.Description, opts => opts.MapFrom(o => o.Description))
                .ForPath(dest => dest.Value, opts => opts.MapFrom(o => o.Value))
                .ForPath(dest => dest.CostValue, opts => opts.MapFrom(o => o.CostValue))
                .ForPath(dest => dest.Ammount, opts => opts.MapFrom(o => o.Ammount));

            CreateMap<Product, ProductVOExit>()
               .ForPath(dest => dest.Id, opts => opts.MapFrom(o => o.Id))
               .ForPath(dest => dest.MarketId, opts => opts.MapFrom(o => o.MarketId))
               .ForPath(dest => dest.Description, opts => opts.MapFrom(o => o.Description))
               .ForPath(dest => dest.Value, opts => opts.MapFrom(o => o.Value))
               .ForPath(dest => dest.CostValue, opts => opts.MapFrom(o => o.CostValue))
               .ForPath(dest => dest.Ammount, opts => opts.MapFrom(o => o.Ammount))
               .ForPath(dest => dest.LastUpdated, opts => opts.MapFrom(o => o.User.Name))
               .ForPath(dest => dest.UpdatedAt, opts => opts.MapFrom(o => o.UpdatedAt))
               .ForPath(dest => dest.CreatedAt, opts => opts.MapFrom(o => o.CreatedAt))
               .ForPath(dest => dest.Market, opts => opts.MapFrom(o => o.Market.MarketName));

            CreateMap<ProductUpdateVOEnter, Product>()
               .ForPath(dest => dest.Id, opts => opts.MapFrom(o => o.Id))
               .ForPath(dest => dest.MarketId, opts => opts.MapFrom(o => o.MarketId))
               .ForPath(dest => dest.Description, opts => opts.MapFrom(o => o.Description))
               .ForPath(dest => dest.Value, opts => opts.MapFrom(o => o.Value))
               .ForPath(dest => dest.CostValue, opts => opts.MapFrom(o => o.CostValue))
               .ForPath(dest => dest.Ammount, opts => opts.MapFrom(o => o.Ammount))
               .ForPath(dest => dest.BarCode, opts => opts.MapFrom(o => o.BarCode))
               .ForPath(dest => dest.UserId, opts => opts.MapFrom(o => o.UserId))
               .ForPath(dest => dest.UpdatedAt, opts => opts.MapFrom(o => o.UpdatedAt))
               .ForPath(dest => dest.CreatedAt, opts => opts.MapFrom(o => o.CreatedAt));
        }
    }
}
