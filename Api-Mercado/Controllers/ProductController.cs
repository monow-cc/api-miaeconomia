using Api_Mercado.Atribute;
using Api_Mercado.Model;
using Api_Mercado.Services;
using Api_Mercado.VOs.Enter.Products;
using Api_Mercado.VOs.Exit.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Mercado.Controllers
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
        public async Task<ActionResult<ProductVOExit>> CreateProduct (ProductVOEnter product)
        {
            var service = await _services.CreateProduct(product, HttpContext);
            return Ok(service);
        }
        [HttpPost("getupdate")]
        [Authorize]
        public async Task<ActionResult<Product>> GetProductUpdateMarket(ProductGetUpdateVOEnter product)
        {
            var service = await _services.GetProductUpdateMarket(product);
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
    }
}
