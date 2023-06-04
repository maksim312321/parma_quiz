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
    public async Task<List<UserDto>> GetUsersAsync(
       CancellationToken cancellationToken = default)
    {
        var usersQuery = string.Format(@"select u.user_id as UserId,
											u.user_password as UserPassword,
										   	u.user_name as UserName,
										   	u.user_surname as UserSurname,
										  	u.user_login as UserLogin,
										  	u.user_role_id as RoleId,
                                           	from users u");

        var users = (await _repository.QueryAsync<UserModel>(
            sql: usersQuery));

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
        int id,
        CancellationToken cancellationToken = default)
    {
        var usersQuery = string.Format(@"select u.user_id as UserId,
											u.user_password as UserPassword,
										   	u.user_name as UserName,
										   	u.user_surname as UserSurname,
										  	u.user_login as UserLogin,
										  	u.user_role_id as RoleId,
                                           	from users u
                                            where u.user_id = {0}", id);

        var user = (await _repository.QueryAsync<UserModel>(
            sql: usersQuery)).FirstOrDefault();

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
}
