namespace miaEconomiaApi.Model
{
    public class LowestPrice
    {
        public int Id { get; set; }
        public int MarketId { get; set; }
        public int ProductId { get; set; }
        public Market? Market { get; set; }
        public Product? Product { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
