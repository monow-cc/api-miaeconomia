using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Mercado.VOs.Enter.Products
{
    public class ProductUpdateVOEnter 
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public long BarCode { get; set; }
        public int MarketId { get; set; }
        public decimal Value { get; set; }
        public decimal CostValue { get; set; }
        public int Ammount { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

    
}
