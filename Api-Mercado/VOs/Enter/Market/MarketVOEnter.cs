using Api_Mercado.Enums;

namespace Api_Mercado.VOs.Enter.Market
{
    public class MarketVOEnter
    {
        public string MarketName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Region Region { get; set; }

    }
}
