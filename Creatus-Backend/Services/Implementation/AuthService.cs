using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using creatus_backend.Exceptions;
using creatus_backend.Models;
using creatus_backend.Repository;

namespace creatus_backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public AuthService(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetByEmail(email);

            if (user == null || !_userService.VerifyPassword(password, user.Password))
            {
                throw new UserNotFoundException();
            }
            return user;
        }

    }
}
