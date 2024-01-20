using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace app_api.Services;


public class AuthService
{
    private readonly SymmetricSecurityKey key;
    private readonly SigningCredentials credentials;

    public AuthService()
    {
        Console.WriteLine("Auth Service");
        key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secure-key-with-more-than-128-bits"));
        credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    public string GenerateJwtToken(string userId)
    {
        var token = new JwtSecurityToken(
            issuer: "yourissuer",
            audience: "youraudience",
            claims: new[] { new Claim("sub", userId) },
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}