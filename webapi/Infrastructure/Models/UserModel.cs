using System;
using webapi.Enums;

namespace webapi.Infrastructure.Models;

public class UserModel
{
    public string UserName { get; set; }

    public string UserPassword { get; set; }

    public string UserLogin { get; set; }

    public string UserSurname { get; set; }

    public int UserId { get; set; }

    public Role RoleId { get; set; }
}

