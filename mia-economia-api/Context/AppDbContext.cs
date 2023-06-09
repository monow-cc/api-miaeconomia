﻿using miaEconomiaApi.Model;
using Microsoft.EntityFrameworkCore;

namespace miaEconomiaApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Market> Markets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MarketEmployed> MarketEmployeds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LowestPrice> LowestPrices { get; set; }
    }
}
