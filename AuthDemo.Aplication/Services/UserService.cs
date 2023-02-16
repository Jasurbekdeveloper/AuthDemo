using AuthDemo.Aplication.DTO;
using Library.Models.Domain;

namespace AuthDemo.Api.Services
{
    public class UserService : IUserService
    {
        public ValueTask<UserDto> CreateUserAsync(UserCreationDto userForCreationDto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<UserDto> ModifyUserAsync(UserModificationDto userForModificationDto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<UserDto> RemoveUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<UserDto> RetrieveUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IQueryable<UserDto>> RetrieveUsers()
        {
            throw new NotImplementedException();
        }
    }
}
