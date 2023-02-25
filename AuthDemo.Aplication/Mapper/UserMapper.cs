using AuthDemo.Aplication.DTO;
using AuthDemo.Domain.Enums;
using AuthDemo.Infrastructure.Audentification;
using Library.Models.Domain;

namespace AuthDemo.Aplication.Mapper;

public static class UserMapper
{
    public static User MapToUser(
        UserCreationDto userCreationDto,
        PasswordHasher passwordHasher)
    {
        string randomsalt = Guid.NewGuid().ToString();

        return new User()
        {
            Id = Guid.NewGuid(),
            Username = userCreationDto.userName,
            PasswordHash = passwordHasher.GenerationPassword(
                userCreationDto.password,
                randomsalt),
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
