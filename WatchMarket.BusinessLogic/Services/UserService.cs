using WatchMarket.BusinessLogic.Dto_s;
using WatchMarket.BusinessLogic.Interfaces;
using WatchMarketApp.DataAccess.Entities;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarket.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            await _userRepository.AddAsync(newUser);

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
    }
}
