using AuthDemo.Aplication.DTO;
using AuthDemo.Domain.Enums;
using Library.Models.Domain;

namespace AuthDemo.Aplication.Mapper;

public static class UserMapper
{
    public static User MapToUser(UserCreationDto userCreationDto)
    {
        return new User()
        {
            Id = Guid.NewGuid(),
            Username = userCreationDto.userName,
            Password = userCreationDto.password,
            EmailAddres = userCreationDto.email,
            Role = UserRole.User,
                                  
        };
    }

    public static UserDto MapToUserDto(User user)
    {
        return new UserDto(user.Id, user.Username,
            user.EmailAddres, user.Role.ToString());
    }
    public static void MapToUser(
        UserModificationDto userModify,
        User user)
    {
        user.Username = userModify.userName ?? user.Username;
        user.EmailAddres = userModify.email ?? user.EmailAddres;
        user.Role = userModify.role ?? user.Role;
    }
}
