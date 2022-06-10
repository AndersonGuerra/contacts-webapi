using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContactWebAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace ContactWebAPI.Services;


public class TokenService : ITokenService
{
    private const double EXPIRY_DURATION_MINUTES = 30;
    public string BuildToken(string key, string issuer, UserResponseDto user)
    {
        var claims = new[]{
            new Claim(ClaimTypes.Name, user.Name),
            //new Claim(ClaimTypes.Role, user.Name),
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
        };
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
            expires: DateTime.Now.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    public bool ValidateToken(string key, string issuer, string audience, string token)
    {
        var mySecret = Encoding.UTF8.GetBytes(key);
        var myKey = new SymmetricSecurityKey(mySecret);
        var tokenHandler = new JwtSecurityTokenHandler();
        Console.WriteLine("hummmmmmmmmmmmmmmmmmmmm");
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = myKey
            }, out SecurityToken validatedToken);
        }
        catch (System.Exception)
        {

            return false;
        }
        return true;
    }
}
