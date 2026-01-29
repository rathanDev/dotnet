using UserService.DTOs;
using UserService.Models;

namespace UserService.Mappers;

public static class UserMapper
{

    public static UserDto ToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Role = user.Role
        };
    }

}
