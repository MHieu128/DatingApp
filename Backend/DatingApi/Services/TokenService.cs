using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using DatingApi.Entities;
using DatingApi.IServices;
using Microsoft.IdentityModel.Tokens;

namespace DatingApi.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public string CreateToken(AppUser user)
    {
        // Implementation for creating a token
        var TokenKey = config["TokenKey"] ?? throw new ArgumentNullException("TokenKey");
        if (string.IsNullOrEmpty(TokenKey))
        {
            throw new ArgumentNullException("TokenKey");
        }

        if (TokenKey.Length < 64)
        {
            throw new ArgumentException("TokenKey must be at least 64 characters long.");
        }

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(TokenKey));

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
