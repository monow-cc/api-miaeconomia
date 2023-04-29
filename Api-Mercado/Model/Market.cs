namespace Api_Mercado.Model
{
    public class Market
    {
        public int Id { get; set; }
        public string MarketName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<MarketEmployed>? Employeds { get; set; }
    }
}
