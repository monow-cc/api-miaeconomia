using Api_Mercado.Context;
using Api_Mercado.Exeption;
using Api_Mercado.Model;
using Api_Mercado.VOs.Enter.Products;
using Api_Mercado.VOs.Exit.Products;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Api_Mercado.Services
{
    public class ProductServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductServices(AppDbContext service, IMapper mapper)
        {
            _context = service;
            _mapper = mapper;
        }

        public async Task<ProductVOExit> CreateProduct (ProductVOEnter product, HttpContext httpContext)
        {
            var id = int.Parse(httpContext.Items["Id"]!.ToString()!);

            var verify = await _context.Products.Where(x => x.MarketId == product.MarketId && x.BarCode == x.BarCode).FirstOrDefaultAsync();
            if (verify != null) throw new AplicationRequestException("Produto com codigo de barra já cadastrado", HttpStatusCode.BadRequest);

            var entity = _mapper.Map<ProductVOEnter,Product>(product);
            entity.CreatedAt = DateTime.Now;
            entity.UserId = id;

            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();

            await _context.Entry(entity).Reference(x => x.Market).LoadAsync();
            await _context.Entry(entity).Reference(x => x.User).LoadAsync();

            return _mapper.Map<Product, ProductVOExit>(entity);
        }
        public async Task<Product> GetProductUpdateMarket (ProductGetUpdateVOEnter product)
        {
            var verify = await _context.Products.Where(x => x.MarketId == product.MarketId && x.BarCode == product.BarCode).FirstOrDefaultAsync() 
                ?? throw new AplicationRequestException("Produto nao encontrado",HttpStatusCode.NotFound);
            return verify;
        }
        public async Task<IEnumerable<ProductVOExit>> GetAll()
        {
            var verify = await _context.Products.Include(x => x.Market).Include(x => x.User).ToListAsync();
            return _mapper.Map<List<Product>, List<ProductVOExit>>(verify);
        }
        public async Task<ProductVOExit> UpdateProduct(Product product, HttpContext httpContext)
        {
            var id = int.Parse(httpContext.Items["Id"]!.ToString()!);

            var verify = await _context.Products.Where(x => x.MarketId == product.MarketId && x.BarCode == product.BarCode).FirstOrDefaultAsync()
                 ?? throw new AplicationRequestException("Produto nao encontrado", HttpStatusCode.NotFound);

            product.UserId = id;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            await _context.Entry(product).Reference(x => x.Market).LoadAsync();
            await _context.Entry(product).Reference(x => x.User).LoadAsync();

            return _mapper.Map<Product, ProductVOExit>(product);
        }
    }
}
