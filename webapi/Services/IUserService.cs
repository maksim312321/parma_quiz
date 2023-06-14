using webapi.Infrastructure.Dtos;

namespace webapi.Services;

public interface IUserService
{
    Task<List<UserDto>> GetUsersAsync();

    Task<UserDto> GetUserByIdAsync(int id);

    Task<int> AddUserAsync(UserDto user);

    Task<bool> IsUserExist(string userLogin);

    Task<bool> UpdateUserAsync(UserDto user);

    //Task<IReadOnlyCollection<string>> GetUserPermissionsByIdAsync(
    //    int id,
    //    CancellationToken cancellationToken = default);
}