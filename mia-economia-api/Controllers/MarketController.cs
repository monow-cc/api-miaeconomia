using miaEconomiaApi.Services;
using miaEconomiaApi.VOs.Enter.Market;
using miaEconomiaApi.VOs.Exit;
using Microsoft.AspNetCore.Mvc;

namespace miaEconomiaApi.Controllers
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
        public async Task<ActionResult<AuthToken>> CreateMarket(MarketVOEnter market)
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
