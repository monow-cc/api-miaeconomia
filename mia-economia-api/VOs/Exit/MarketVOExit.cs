using miaEconomiaApi.VOs.Exit.Products;

namespace miaEconomiaApi.VOs.Exit
{
    public class MarketVOExit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductVOExit> Products { get; set; }
    }
}
