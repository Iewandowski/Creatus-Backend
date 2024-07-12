using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using creatus_backend.Dtos.Request;
using creatus_backend.Dtos.Response;
using creatus_backend.Exceptions;
using creatus_backend.Models;
using creatus_backend.Repository;
using creatus_backend.Services;

namespace creatus_backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            if (!users.Any())
            {
                throw new UserNotFoundException();
            }
            return users.Select(u => MapToUserResponse(u));
        }

        public async Task<UserResponse> GetById(int id)
        {
            var user = await _userRepository.GetById(id) ?? throw new UserNotFoundException();
            return MapToUserResponse(user);
        }

        public async Task<UserResponse> CreateUser(UserRequest userRequest)
        {
            if (string.IsNullOrEmpty(userRequest.Name))
            {
                throw new UserMissingFieldException("O campo Nome é obrigatório.");
            }
            if (string.IsNullOrEmpty(userRequest.Email))
            {
                throw new UserMissingFieldException("O campo Email é obrigatório.");
            }
            Console.WriteLine(GetUserByEmail(userRequest.Email));
            if (await GetUserByEmail(userRequest.Email) != null)
            {
                throw new EmailAlreadyExistsException();
            }

            if (string.IsNullOrEmpty(userRequest.Password))
            {
                throw new UserMissingFieldException("O campo Password é obrigatório.");
            }
            if (userRequest.Level == null) {
                throw new UserMissingFieldException("O campo Level é obrigatório.");
            }

            var newUser = new User
            {
                Name = userRequest.Name,
                Email = userRequest.Email,
                Password = userRequest.Password,
                Level = (int)userRequest.Level
            };

            var createdUser = await _userRepository.CreateUser(newUser);
            return MapToUserResponse(createdUser);
        }

        public async Task<UserResponse> UpdateUser(int id, UserRequest userRequest)
        {
            var existingUser = await _userRepository.GetById(id) ?? throw new UserNotFoundException();

            if (!string.IsNullOrEmpty(userRequest.Name))
            {
                existingUser.Name = userRequest.Name;
            }
            if (!string.IsNullOrEmpty(userRequest.Email))
            {
                existingUser.Email = userRequest.Email;
            }
            if (!string.IsNullOrEmpty(userRequest.Password))
            {
                existingUser.Password = userRequest.Password;
            }
            if (userRequest.Level >= 1 && userRequest.Level <= 5)
            {
                existingUser.Level = (int)userRequest.Level;
            }

            await _userRepository.UpdateUser(existingUser);
            return MapToUserResponse(existingUser);
        }

        public async Task DeleteUser(int id)
        {
            var existingUser = await _userRepository.GetById(id) ?? throw new UserNotFoundException();

            await _userRepository.DeleteUser(existingUser.Id);
        }

        private static UserResponse MapToUserResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Level = user.Level
            };
        }

        private async Task<User?> GetUserByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }
    }
}
