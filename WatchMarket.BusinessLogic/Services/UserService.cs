using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WatchMarket.BusinessLogic.Dto_s;
using WatchMarket.BusinessLogic.Interfaces;
using WatchMarketApp.DataAccess.Entities;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarket.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public async Task<UserDto> CreateUserAsync(UserDto user)
        {
            var userLooked = await _userRepository.GetByEmailAsync(user.Email);

            if (userLooked is not null)
            {
                throw new Exception("This user already exists");
            }

            var newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.Password
            };

            var userWithRole = SetUserRole(newUser);
            await _userRepository.AddAsync(userWithRole);

            return new UserDto
            {
                Username = newUser.Username,
                Email = newUser.Email,
            };
        }

        public async Task DeleteUserAsync(string email)
        {
            var userLooked = await _userRepository.GetByEmailAsync(email)
                            ?? throw new Exception("This user does not exist");

            await _userRepository.DeleteAsync(userLooked);
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            var userDtos = users.Select(user => new UserDto
            {
                Username = user.Username,
                Email = user.Email,
            }).ToList();

            return userDtos;
        }

        public async Task<UserDto> UpdateUserAsync(UserDto user)
        {
            var userLooked = await _userRepository.GetByEmailAsync(user.Email)
                            ?? throw new Exception("This user does not exist");

            userLooked.Username = user.Username;
            userLooked.Password = user.Password;
            var updatedUser = await _userRepository.UpdateAsync(userLooked);

            return new UserDto
            {
                Username = updatedUser.Username,
                Email = updatedUser.Email,
            };
        }
        public async Task<string> LoginAsync(UserDto userLogin)
        {
            var user = await _userRepository.GetByEmailAsync(userLogin.Email);

            if (!IsValidUser(user, userLogin))
            {
                throw new Exception("Wrong email, please try again or sign up");
            }

            return GenerateToken(user);
        }
        private User SetUserRole(User user)
        {
            user.RoleId = -2;

            return user;
        }
        private bool IsValidUser(User user, UserDto userModel)
        {
            if (user is null)
            {
                throw new Exception("The user was not found");
            }

            if (user.Password != userModel.Password)
            {
                return false;
            }

            return true;
        }
        private string GenerateToken(User user)
        {
            var claimsIdentity = new ClaimsIdentity(new Claim[] {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.Name)
        });

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:key"])), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
