using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace miaEconomiaApi.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public long BarCode { get; set; }
        public int MarketId { get; set; }

        [Column(TypeName = "decimal(0,2)")]
        public decimal Value { get; set; }

        [Column(TypeName = "decimal(0,2)")]
        public decimal CostValue { get; set; }

        public int Ammount { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public User? User { get; set; }
        public Market? Market { get; set; }
    }
}
