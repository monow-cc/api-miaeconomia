using Api_Mercado.Services;
using Api_Mercado.VOs.Enter.Market;
using Api_Mercado.VOs.Exit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Mercado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly MarketServices _services;

        public MarketController(MarketServices services)
        {
            _services = services;
        }
        [HttpPost]
        public async Task <ActionResult<AuthToken>> CreateMarket(MarketVOEnter market)
        {
            var service = await _services.CreateMarket(market);
            return Ok(service);
        }
        [HttpPost("auth")]
        public async Task<ActionResult<AuthToken>> Auth(MarketAuthVOEnter market)
        {
            var service = await _services.Auth(market);
            return Ok(service);
        }
    }
}
