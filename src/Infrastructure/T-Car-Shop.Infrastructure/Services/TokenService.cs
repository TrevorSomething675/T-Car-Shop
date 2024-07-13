using System.IdentityModel.Tokens.Jwt;
using T_Car_Shop.Application.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using T_Car_Shop.Core.OptionModels;
using System.Security.Claims;
using System.Text;

namespace T_Car_Shop.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly JwtAuthOptions _options;
        public TokenService(IOptions<JwtAuthOptions> options) 
        {
            _options = options.Value;
        }

        public async Task<string> CreateAccessToken(Guid id, string role)
        {
            var claims = new List<Claim> {
                new Claim("Id", id.ToString()),
                new Claim(ClaimTypes.Role, role),
                };

            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(_options.ExpAccessTokenInDays)),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_options.Key)),
                    SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<string> CreateRefreshToken()
        {
            var jwt = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(_options.ExpRefreshTokenInDays)),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_options.Key)),
                    SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}