namespace Api_Mercado.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int MarketId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;} = DateTime.Now;

        public Market? Market { get; set; }
    }
}
