using System;
using webapi.Infrastructure.Dtos;

namespace webapi.Services;

public interface IUserService
{
    Task<List<UserDto>> GetUsersAsync();

    Task<UserDto> GetUserByIdAsync(int id);

    //Task ChangeUserAsync(
    //    int id,
    //    UserChangeModel changes,
    //    CancellationToken cancellationToken = default);

    Task<int> AddUserAsync(UserDto user);

    Task<bool> IsUserExist(string userLogin);

    //Task<IReadOnlyCollection<string>> GetUserPermissionsByIdAsync(
    //    int id,
    //    CancellationToken cancellationToken = default);
}