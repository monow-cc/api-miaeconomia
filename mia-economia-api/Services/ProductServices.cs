using AutoMapper;
using miaEconomiaApi.Context;
using miaEconomiaApi.Exeption;
using miaEconomiaApi.Model;
using miaEconomiaApi.VOs.Enter.Products;
using miaEconomiaApi.VOs.Exit.Products;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace miaEconomiaApi.Services
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

        public async Task<ProductVOExit> CreateProduct(ProductVOEnter product, HttpContext httpContext)
        {
            var id = int.Parse(httpContext.Items["Id"]!.ToString()!);

            var verify = await _context.Products.Where(x => x.MarketId == product.MarketId && x.BarCode == product.BarCode).FirstOrDefaultAsync();
            if (verify != null) throw new AplicationRequestException("Produto com codigo de barra já cadastrado", HttpStatusCode.BadRequest);

            var entity = _mapper.Map<ProductVOEnter, Product>(product);
            entity.CreatedAt = DateTime.Now;
            entity.UserId = id;

            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();

            await _context.Entry(entity).Reference(x => x.Market).LoadAsync();
            await _context.Entry(entity).Reference(x => x.User).LoadAsync();

            return _mapper.Map<Product, ProductVOExit>(entity);
        }

        public async Task<IEnumerable<ProductVOExit>> GetAll()
        {
            var verify = await _context.Products.Include(x => x.Market).Include(x => x.User).Take(50).ToListAsync();
            return _mapper.Map<List<Product>, List<ProductVOExit>>(verify);
        }

        public async Task<IEnumerable<ProductVOExit>> GetProductList(ProductListVOEnter products)
        {
            var barcodes = products.BarCodes;

            var result = await _context.Products
                .Include(p => p.Market)
                .Include(p => p.User)
                .Where(item => barcodes.Contains(item.BarCode))
                .ToListAsync();

            var groupedItems = result
                .GroupBy(item => item.BarCode)
                .Select(group => new { Barcode = group.Key, MinCost = group.Min(item => item.CostValue) });

            var filteredItems = result
                .Where(item => barcodes.Contains(item.BarCode) && groupedItems.Any(min => min.Barcode == item.BarCode && min.MinCost == item.CostValue))
                .Select(item => new Product
                {
                    Id = item.Id,
                    MarketId = item.MarketId,
                    Description = item.Description,
                    Ammount = item.Ammount,
                    Value = item.Value,
                    CostValue = item.CostValue,
                    User = item.User,
                    Market = item.Market,
                    UpdatedAt = item.UpdatedAt,
                    CreatedAt = item.CreatedAt,
                })
                .ToList();

            return _mapper.Map<List<Product>, List<ProductVOExit>>(filteredItems);
        }

        public async Task<ProductVOExit> UpdateProduct(Product product, HttpContext httpContext)
        {
            var id = int.Parse(httpContext.Items["Id"]!.ToString()!);

            var verify = await _context.Products.AsNoTracking().Where(x => x.MarketId == product.MarketId && x.BarCode == product.BarCode).FirstOrDefaultAsync()
                 ?? throw new AplicationRequestException("Produto nao encontrado", HttpStatusCode.NotFound);
            product.UserId = id;
            product.UpdatedAt = DateTime.Now;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            await _context.Entry(product).Reference(x => x.Market).LoadAsync();
            await _context.Entry(product).Reference(x => x.User).LoadAsync();

            return _mapper.Map<Product, ProductVOExit>(product);
        }
        public async Task<IEnumerable<ProductVOExit>> ProductsByDesc(string desc)
        {
            var get = await _context.Products.Where(x => x.Description.Contains(desc)).ToListAsync();
            var convertToListVO = _mapper.Map<List<Product>,List<ProductVOExit>>(get);
            return convertToListVO;
        }
    }
}


