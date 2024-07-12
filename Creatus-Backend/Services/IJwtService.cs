using creatus_backend.Models;

namespace creatus_backend.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}