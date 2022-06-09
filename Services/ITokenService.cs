using ContactWebAPI.Models;

namespace ContactWebAPI.Services;

public interface ITokenService
{
    string BuildToken(string key, string issuer, UserResponseDto user);
    bool ValidateToken(string key, string issuer, string audience, string token);
}
