using webapi.Enums;

namespace webapi.Infrastructure.Dtos;

public class UserDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public Role Role { get; set; }

    public string Login { get; set; }

    public string Surname { get; set; }
}
