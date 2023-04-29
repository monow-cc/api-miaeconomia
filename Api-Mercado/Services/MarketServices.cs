using Api_Mercado.Context;
using Api_Mercado.Exeption;
using Api_Mercado.Model;
using Api_Mercado.VOs.Enter.Market;
using Api_Mercado.VOs.Exit;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using BC = BCrypt.Net.BCrypt;

namespace Api_Mercado.Services
{
    public class MarketServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly JWTService _jwtService;

        public MarketServices(AppDbContext context, IMapper mapper, JWTService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;
        }
        public async Task<AuthToken> CreateMarket (MarketVOEnter market)
        {
            var verify = await _context.Markets.FirstOrDefaultAsync(x => x.Email == market.Email);
            if (verify != null) throw new AplicationRequestException("Email já cadastrado", HttpStatusCode.NotFound);

            var entity = _mapper.Map<MarketVOEnter,Market>(market);
            entity.CreatedAt = DateTime.Now;
            entity.Password =  BC.HashPassword(entity.Password, 12);

            await _context.Markets.AddAsync(entity);
            await _context.SaveChangesAsync();

            var Token = new AuthToken() { Token = _jwtService.GerarToken(entity)};
            return Token;
        }
        public async Task<AuthToken> Auth(MarketAuthVOEnter market)
        {
            var verify = await _context.Markets.Where(x => x.Email == market.Email).FirstOrDefaultAsync() ?? throw new AplicationRequestException("Dados incorretos", HttpStatusCode.Unauthorized);
            
            if (!BC.Verify(market.Password, verify.Password)) throw new AplicationRequestException("Dados incorretos", HttpStatusCode.Unauthorized);

            var Token = new AuthToken() { Token = _jwtService.GerarToken(verify) };
            return Token;
        }
    }
}
