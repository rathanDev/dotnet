using UserService.DTOs;

namespace UserService.Services.Interfaces;

public interface IAuthService
{
    string GenerateToken(LoginRequest req);
}
