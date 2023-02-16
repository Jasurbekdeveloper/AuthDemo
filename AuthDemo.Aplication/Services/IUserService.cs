using AuthDemo.Aplication.DTO;

namespace AuthDemo.Api.Services
{
    public interface IUserService
    {
        ValueTask<UserDto> CreateUserAsync(UserCreationDto userForCreationDto);
        ValueTask<IQueryable<UserDto>> RetrieveUsers();
        ValueTask<UserDto> RetrieveUserByIdAsync(Guid userId);
        ValueTask<UserDto> ModifyUserAsync(UserModificationDto userForModificationDto);
        ValueTask<UserDto> RemoveUserAsync(Guid userId);
    }
}
