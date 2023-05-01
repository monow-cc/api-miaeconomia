using miaEconomiaApi.Atribute;
using miaEconomiaApi.Model;
using miaEconomiaApi.Services;
using miaEconomiaApi.VOs.Enter.Products;
using miaEconomiaApi.VOs.Exit.Products;
using Microsoft.AspNetCore.Mvc;

namespace miaEconomiaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices _services;

        public ProductController(ProductServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVOExit>> CreateProduct(ProductVOEnter product)
        {
            var service = await _services.CreateProduct(product, HttpContext);
            return Ok(service);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductVOExit>> UpdateProduct(Product product)
        {
            var service = await _services.UpdateProduct(product, HttpContext);
            return Ok(service);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVOExit>>> GetAll()
        {
            var service = await _services.GetAll();
            return Ok(service);
        }
        [HttpGet("productsbydesc/{desc}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVOExit>>> ProductsByDesc(string desc)
        {
            var service = await _services.ProductsByDesc(desc);
            return Ok(service);
        }

        [HttpPost("getlistproducts")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVOExit>>> GetListProducts(ProductListVOEnter product)
        {
            var service = await _services.GetProductList(product);
            return Ok(service);
        }
    }
}
