﻿using AutoMapper;
using miaEconomiaApi.Context;
using miaEconomiaApi.Exeption;
using miaEconomiaApi.Model;
using miaEconomiaApi.VOs.Enter.User;
using miaEconomiaApi.VOs.Exit;
using Microsoft.EntityFrameworkCore;
using System.Net;
using BC = BCrypt.Net.BCrypt;

namespace miaEconomiaApi.Services
{
    public class UserServices
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly JWTService _jwtService;

        public UserServices(AppDbContext context, IMapper mapper, JWTService jwtService)
        {
            _context = context;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<AuthToken> CreateUser(UserVOEnter user)
        {
            var verify = await _context.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (verify != null) throw new AplicationRequestException("Email já cadastrado", HttpStatusCode.NotFound);

            var entity = _mapper.Map<UserVOEnter, User>(user);
            entity.CreatedAt = DateTime.Now;
            entity.Password = BC.HashPassword(entity.Password, 12);

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            var Token = new AuthToken() { Token = _jwtService.UserToken(entity) };
            return Token;
        }

        public async Task<AuthToken> Auth(UserAuthVOEnter user)
        {
            var verify = await _context.Users.Where(x => x.Email == user.Email).FirstOrDefaultAsync() ?? throw new AplicationRequestException("Dados incorretos", HttpStatusCode.Unauthorized);

            if (!BC.Verify(user.Password, verify.Password)) throw new AplicationRequestException("Dados incorretos", HttpStatusCode.Unauthorized);

            var Token = new AuthToken() { Token = _jwtService.UserToken(verify) };
            return Token;
        }
    }
}
