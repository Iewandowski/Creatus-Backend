using System.Threading.Tasks;
using creatus_backend.Models;

namespace creatus_backend.Services
{
    public interface IAuthService
    {
        Task<User> Authenticate(string email, string password);
    }
}
