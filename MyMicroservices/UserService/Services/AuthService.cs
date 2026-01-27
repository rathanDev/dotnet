using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UserService.DTOs;
using UserService.Options;
using UserService.Services.Interfaces;

namespace UserService.Services;

public class AuthService : IAuthService
{
    private readonly JwtOptions _jwt;

    public AuthService(IOptions<JwtOptions> jwt)
    {
        _jwt = jwt.Value;
    }

    public string GenerateToken(LoginRequest req)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, req.Username),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwt.Key));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.ExpiryMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
