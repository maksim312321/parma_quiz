using System;
using webapi.Infrastructure.Dtos;
using webapi.Services;

public interface IUserService
{
    Task<List<UserDto>> GetUsersAsync(
        CancellationToken cancellationToken = default);

    Task<UserDto> GetUserByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    //Task<UserItem> GetUserByIdAsync(
    //    HttpContext httpContext,
    //    CancellationToken cancellationToken = default);

    //Task ChangeUserAsync(
    //    int id,
    //    UserChangeModel changes,
    //    CancellationToken cancellationToken = default);

    //Task<UserViewModel> AddUserAsync(
    //    UserItem user,
    //    CancellationToken cancellationToken = default);

    //Task<bool> IsUserExist(
    //    string userLogin,
    //    CancellationToken cancellationToken = default);

    //Task<IReadOnlyCollection<string>> GetUserPermissionsByIdAsync(
    //    int id,
    //    CancellationToken cancellationToken = default);
}
