using miaEconomiaApi.Services;

namespace miaEconomiaApi.Program
{
    public static class InjectorSetup
    {
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<JWTService>();
            services.AddScoped<MarketServices>();
            services.AddScoped<UserServices>();
            services.AddScoped<MarketEmployesServices>();
            services.AddScoped<ProductServices>();
        }
    }
}
