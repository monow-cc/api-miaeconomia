using miaEconomiaApi.Atribute;
using miaEconomiaApi.Services;
using miaEconomiaApi.VOs.Enter.MarketEmployed;
using miaEconomiaApi.VOs.Exit.MarketEmployed;
using Microsoft.AspNetCore.Mvc;

namespace miaEconomiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketEmployedController : ControllerBase
    {
        private readonly MarketEmployesServices _services;

        public MarketEmployedController(MarketEmployesServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<MarketEmployedVOExit>> CreateEmployed(MarketEmployedVOEnter employed)
        {
            var service = await _services.CreateEmployed(employed, HttpContext);
            return Ok(service);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<MarketEmployedVOExit>>> GetMyMarkets()
        {
            var service = await _services.GetMyMarkets(HttpContext);
            return Ok(service);
        }
    }
}
