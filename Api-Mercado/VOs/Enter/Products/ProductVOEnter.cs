using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Mercado.VOs.Enter.Products
{
    public class ProductVOEnter
    {
        public int MarketId { get; set; }
        public int BarCode { get; set; }
        public string Description { get; set; }
        public int Ammount { get; set; }
        public decimal Value { get; set; }
        public decimal CostValue { get; set; }
    }
}
