using Api_Mercado.Services;

namespace Api_Mercado.Program
{
    public static class InjectorSetup
    {
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<JWTService>();
            services.AddScoped<MarketServices>();

        }
    }
}
