using Api_Mercado.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Mercado.VOs.Exit.Products
{
    public class ProductVOExit
    {
        public int Id { get; set; }
        public int MarketId { get; set; }
        public string Description { get; set; }
        public int Ammount { get; set; }
        public decimal Value { get; set; }
        public decimal CostValue { get; set; }
        public string LastUpdated { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; }
        public string Market { get; set; }

        
    }
}
