using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using webapi.Infrastructure;
using webapi.Infrastructure.DatabaseUtils;
using webapi.Infrastructure.Dtos;
using webapi.Infrastructure.Models;

namespace webapi.Services.Implementations;

public class UserService : IUserService
{
    private readonly IRepository _repository;

    public UserService(IRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<UserDto>?> GetUsersAsync()
    {
        var users = (await _repository.QueryAsync<UserModel>(
            sql: SqlFiles.GetAllUsers));

        if (users is null)
            return null;

        return users.Select(u => new UserDto
        {
            Id = u.UserId,
            Password = u.UserPassword,
            Login = u.UserLogin,
            Surname = u.UserSurname,
            Role = u.RoleId,
            Name = u.UserName
        }).ToList();
    }

    public async Task<UserDto> GetUserByIdAsync(
        int id)
    {
      
        var user = (await _repository.QueryAsync<UserModel>(sql: SqlFiles.GetUserById, param: new 
            {
                UserId = id
            })).FirstOrDefault();

        if (user is null)
            return null;

        return new UserDto
        {
            Id = user.UserId,
            Password = user.UserPassword,
            Login = user.UserLogin,
            Surname = user.UserSurname,
            Role = user.RoleId,
            Name = user.UserName
        };
    }

    public async Task<int> AddUserAsync(UserDto user)
    {
        ArgumentNullException.ThrowIfNull(user);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, 14);
       
        return (await _repository.QueryAsync<int>(
            sql: SqlFiles.AddNewUser,
            param: new
            {
                UserPassword = user.Password,
                UserLogin = user.Login,
                UserSurname = user.Surname,
                UserName = user.Name,
                UserRoleId = (int)user.Role
            })).FirstOrDefault(-1);
    }

    public async Task<bool> IsUserExist(string userLogin)
    {
        var currentUser = (await _repository.QueryAsync<UserModel>(
            sql: SqlFiles.GetUserByLogin,
            param: new
            {
                UserLogin = userLogin
            })).FirstOrDefault();
        return currentUser is not null;
    }

    public async Task<bool> UpdateUserAsync(UserDto user)
    {
        var userId = (await _repository.QueryAsync<int>(
            sql: SqlFiles.UpdateUserById,
            param: new
            {
                UserId = user.Id,
                UserPassword = user.Password,
                UserLogin = user.Login,
                UserSurname = user.Surname,
                UserName = user.Name,
                UserRoleId = (int)user.Role
            })).FirstOrDefault(-1);
        return userId == user.Id;
    }
}
