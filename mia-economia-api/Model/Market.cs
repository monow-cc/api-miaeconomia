using miaEconomiaApi.Enums;

namespace miaEconomiaApi.Model
{
    public class Market
    {
        public int Id { get; set; }
        public string MarketName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }
        public Region Region { get; set; }
        public ICollection<MarketEmployed>? Employeds { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
