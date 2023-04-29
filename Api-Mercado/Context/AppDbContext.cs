using Microsoft.EntityFrameworkCore;

namespace Api_Mercado.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
     
    }
}
