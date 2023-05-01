using AutoMapper;
using miaEconomiaApi.Context;
using miaEconomiaApi.Exeption;
using miaEconomiaApi.Model;
using miaEconomiaApi.VOs.Enter.MarketEmployed;
using miaEconomiaApi.VOs.Exit.MarketEmployed;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace miaEconomiaApi.Services
{
    public class MarketEmployesServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public MarketEmployesServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MarketEmployedVOExit> CreateEmployed(MarketEmployedVOEnter employed, HttpContext httpContext)
        {
            var id = int.Parse(httpContext.Items["Id"]!.ToString()!);
            var getUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == employed.Email) ?? throw new AplicationRequestException("Usuario nao cadastrado", HttpStatusCode.NotFound);

            var verify = await _context.MarketEmployeds.Where(x => x.UserId == getUser.Id && x.MarketId == id).FirstOrDefaultAsync();
            if (verify != null) throw new AplicationRequestException("Usuario Já cadastrado", HttpStatusCode.BadRequest);

            var Employed = new MarketEmployed() { MarketId = id, UserId = getUser.Id, Created_At = DateTime.Now };

            await _context.MarketEmployeds.AddAsync(Employed);
            await _context.SaveChangesAsync();

            await _context.Entry(Employed).Reference(e => e.Market).LoadAsync();
            await _context.Entry(Employed).Reference(e => e.User).LoadAsync();

            var convert = _mapper.Map<MarketEmployed, MarketEmployedVOExit>(Employed);
            return convert;
        }

        public async Task<IEnumerable<MarketEmployedVOExit>> GetMyMarkets(HttpContext httpContext)
        {
            var id = int.Parse(httpContext.Items["Id"]!.ToString()!);
            var get = await _context.MarketEmployeds.Where(x => x.UserId == id).Include(x => x.Market).ToListAsync();
            var convert = _mapper.Map<List<MarketEmployed>, List<MarketEmployedVOExit>>(get);
            return convert;
        }
    }
}
