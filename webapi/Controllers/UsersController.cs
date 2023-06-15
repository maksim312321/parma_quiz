using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.Infrastructure.Dtos;
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
    public async Task<List<UserDto>?> GetAllUsersAsync()
        => await _userService.GetUsersAsync();

    [HttpGet("{userId}")]
    public async Task<UserDto> GetUserById(int userId) =>
        await _userService.GetUserByIdAsync(userId);


    [HttpPost]
    //[AuthentificationPermission(Permissions = "UserManagement")]
    public async Task<int> AddUserAsync(UserDto user)
    {
        if (await _userService.IsUserExist(user.Login))
            throw new Exception("Пользователь существует");

        return await _userService.AddUserAsync(user);
    }

    [HttpGet("checkexists/{userLogin}")]
    public async Task<bool> IsUserExist(string userLogin) =>
        await _userService.IsUserExist(userLogin);

    [HttpPut("{id}")]
    ////[AuthentificationPermission(Permissions = "UserManagement")]
    public async Task<bool> UpdateUserAsync(UserDto user)
      => await _userService.UpdateUserAsync(user);
}