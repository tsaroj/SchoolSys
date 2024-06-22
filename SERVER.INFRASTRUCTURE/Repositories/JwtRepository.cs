using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SERVER.CORE.Entities;
using SERVER.CORE.Interface;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SERVER.INFRASTRUCTURE.Repositories;

public class JwtRepository: IJwtRepository
{
    private readonly IConfiguration _configuration;

    public JwtRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string Token(User user)
    {
        if (user is not null)
        {
            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                new Claim("Id",user.Id.ToString()),
                new Claim("FirstName",user.FirstName),
                new Claim("UserName",user.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], Claims,
                expires: DateTime.UtcNow.AddMinutes(60), signingCredentials: signIn);
            var generateToken = new JwtSecurityTokenHandler().WriteToken(token);
            return generateToken;
        }
        else
        {
            return "Invalid Credentials";
        }
    }
}