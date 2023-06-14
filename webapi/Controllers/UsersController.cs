using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Infrastructure;
using webapi.Infrastructure.Dtos;
using webapi.Infrastructure.Models;
using webapi.Services;
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
    public Task<List<UserDto>?> GetAllUsersAsync()
        => _userService.GetUsersAsync();

    [HttpGet("{userId}")]
    public async Task<UserDto> GetUserById(int userId) =>
        await _userService.GetUserByIdAsync(userId);


    [HttpPost]
    //[AuthentificationPermission(Permissions = "UserManagement")]
    public async Task<int> AddUserAsync(UserDto user)
    {
        //if (await _userService.IsUserExist(user.UserLogin))
        //    throw new UserAlreadyExistException();

        return await _userService.AddUserAsync(user);
    }

    [HttpGet("checkexists/{userLogin}")]
    public async Task<bool> IsUserExist(string userLogin)
    {
        return await _userService.IsUserExist(userLogin);
    }
    //[HttpPut("{id}")]
    ////[AuthentificationPermission(Permissions = "UserManagement")]
    //public Task ChangeUserAsync(int id, [FromBody] UserChangeModel changes, CancellationToken cancellationToken = default)
    //    => _userService.ChangeUserAsync(id, changes, cancellationToken);
}