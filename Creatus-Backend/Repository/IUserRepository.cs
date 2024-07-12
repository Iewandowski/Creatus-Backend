using creatus_backend.Models;

namespace creatus_backend.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User?> GetById(int id);
        Task<User> CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
        Task<User?> GetByEmail(string email);
    }
}