using miaEconomiaApi.Services;
using miaEconomiaApi.VOs.Enter.User;
using miaEconomiaApi.VOs.Exit;
using Microsoft.AspNetCore.Mvc;

namespace miaEconomiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _services;

        public UserController(UserServices services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<ActionResult<AuthToken>> CreateUser(UserVOEnter user)
        {
            var service = await _services.CreateUser(user);
            return Ok(service);
        }

        [HttpPost("auth")]
        public async Task<ActionResult<AuthToken>> Auth(UserAuthVOEnter user)
        {
            var service = await _services.Auth(user);
            return Ok(service);
        }
    }
}
