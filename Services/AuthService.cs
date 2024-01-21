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
        key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secure-key-with-more-than-128-bits"));
        credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    public string GenerateJwtToken(string userId)
    {
        var token = new JwtSecurityToken(
            issuer: "your-issuer",
            audience: "your-audience",
            claims: new[] { new Claim("sub", userId) },
            expires: DateTime.Now.AddMinutes(1000),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    // public string GetUserFromJwt(string token){

    //     return "";
    // }
    public string GetUserFromJwt(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidIssuer = "your-issuer", // Replace with your actual issuer
            ValidAudience = "your-audience", // Replace with your actual audience
            ValidateIssuer = true, // Modify as needed
            ValidateAudience = true // Modify as needed
        };

        try
        {
            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            var userIdClaim = principal.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");

            if (userIdClaim != null)
            {
                return userIdClaim.Value;
            }

            Console.WriteLine("User ID not found in the token.");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Token validation failed: {ex.Message}");
            return null;
        }
    }
}