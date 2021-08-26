using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.DataLayer.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using API.Errors;
using System.Net;
using API.DataAccess.Repositories.User;
using API.Services.DTOs;

namespace API.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IUserRepository _userRepository;
        public TokenService(IConfiguration config, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public async Task<AuthorizedDto> AuthorizeUser(LoginDto loginDto)
        {
            var user = await _userRepository.GetUser(loginDto.Username);

            if (user == null)
                throw new AppException(HttpStatusCode.NotFound, $"User with username '${loginDto.Username}' does not exist.");

            var checkPassword = await _userRepository.CheckPassword(user, loginDto.Password);

            if (checkPassword == false)
                throw new AppException(HttpStatusCode.Unauthorized, "Wrong password. Please try again.");

            return new AuthorizedDto
            {
                Username = loginDto.Username,
                Token = CreateToken(user)
            };
        }

        public string CreateToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}