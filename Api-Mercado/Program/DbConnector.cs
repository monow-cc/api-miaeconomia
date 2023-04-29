using Api_Mercado.Context;
using Microsoft.EntityFrameworkCore;

namespace Api_Mercado.Program
{
    public static class DbConnector
    {
        public static void DbConnectorSetup(this IServiceCollection services,IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("ApiConnectorString");
            if(connectionString != null )
            {
                services.AddDbContext<AppDbContext>(option => option.UseSqlite(connectionString));
            }
        }
    }
}
