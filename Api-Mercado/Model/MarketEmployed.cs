namespace Api_Mercado.Model
{
    public class MarketEmployed
    {
        public int Id { get; set; }
        public int MarketId { get; set; }
        public int UserId { get; set; }
        public DateTime Created_At { get; set; }
        public Market? Market { get; set; }
        public User? User { get; set; }
    }
}
