using creatus_backend.Dtos.Request;
using creatus_backend.Dtos.Response;

namespace creatus_backend.Services
{
    public interface IUserService {
        Task<IEnumerable<UserResponse>> GetAllUsers();
        Task<UserResponse> GetById(int id);
        Task<UserResponse> CreateUser(UserRequest userRequest);
        Task<UserResponse> UpdateUser(int id, UserRequest userRequest);
        Task DeleteUser(int id);
    }
}