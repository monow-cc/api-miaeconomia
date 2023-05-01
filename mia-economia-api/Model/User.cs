namespace miaEconomiaApi.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; }
        public string Password { get; set; } = default!;

        public DateTime CreatedAt = default!;
        public ICollection<MarketEmployed>? Markets { get; set; }
    }
}
