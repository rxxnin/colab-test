using Domain.Entities;

namespace Application.Interfaces.Auth;

public interface IJwtProvider
{
    string GenerateToken(User user);
}