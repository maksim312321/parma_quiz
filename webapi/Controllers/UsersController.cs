using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Infrastructure.Dtos;
using webapi.Infrastructure.Models;
//using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace webapi.Controllers;
[Route("api/[controller]")]
[ApiController]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
    }

    [HttpGet]
    //[AuthentificationPermission(Permissions = "UserManagement")]
    public Task<List<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        => _userService.GetUsersAsync(cancellationToken);

    [HttpGet("{userId}")]
    public async Task<UserDto> GetUserById(int userId) =>
        await _userService.GetUserByIdAsync(userId);
    

    //[HttpPost]
    ////[AuthentificationPermission(Permissions = "UserManagement")]
    //public async Task<UserDto> AddUserAsync(UserItem user, CancellationToken cancellationToken = default)
    //{
    //    //if (await _userService.IsUserExist(user.UserLogin))
    //    //    throw new UserAlreadyExistException();

    //    return await _userService.AddUserAsync(user, cancellationToken);
    //}

    //[HttpPut("{id}")]
    ////[AuthentificationPermission(Permissions = "UserManagement")]
    //public Task ChangeUserAsync(int id, [FromBody] UserChangeModel changes, CancellationToken cancellationToken = default)
    //    => _userService.ChangeUserAsync(id, changes, cancellationToken);
}