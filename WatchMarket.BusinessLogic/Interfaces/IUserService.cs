using WatchMarket.BusinessLogic.Dto_s;

namespace WatchMarket.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateUserAsync(UserDto user);
        Task<UserDto> UpdateUserAsync(UserDto user);
        Task DeleteUserAsync(string email);
        Task<List<UserDto>> GetAllUsersAsync();
    }
}
