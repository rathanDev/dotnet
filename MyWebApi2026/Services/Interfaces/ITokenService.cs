using MyWebApi2026.DTOs;

namespace MyWebApi2026.Services.Interfaces;

public interface ITokenService
{
    string GenerateToken(LoginRequest req);
}
