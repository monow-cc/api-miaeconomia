using Api_Mercado.Model;
using Api_Mercado.Atribute;
using Api_Mercado.Services;
using Api_Mercado.VOs.Enter.MarketEmployed;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Mercado.VOs.Exit.MarketEmployed;

namespace Api_Mercado.Controllers
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
        public async Task<ActionResult<MarketEmployedVOExit>> CreateEmployed (MarketEmployedVOEnter employed)
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
