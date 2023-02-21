using AuthDemo.Aplication.DTO;
using AuthDemo.Aplication.Mapper;
using AuthDemo.Aplication.PagenationModel;
using AuthDemo.Aplication.QueryExtentions;
using AuthDemo.Infrastructure.Repositories.Users;
using Microsoft.AspNetCore.Http;

namespace AuthDemo.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IHttpContextAccessor httpContextAccesssor;

        public UserService(IUserRepository userRepository,
            IHttpContextAccessor httpContextAccesssor)
        {
            this.userRepository = userRepository;
            this.httpContextAccesssor = httpContextAccesssor;
        }

        public async ValueTask<UserDto> CreateUserAsync(UserCreationDto userForCreationDto)
        {
            var user = UserMapper.MapToUser(userForCreationDto);

            var storageUser = await userRepository.InsertAsync(user);

            await userRepository.SaveChangesAsync();

            return UserMapper.MapToUserDto(user);
        }

        public async ValueTask<UserDto> ModifyUserAsync(
            UserModificationDto userForModificationDto)
        {
            var user = await userRepository
                .SelectByIdAsync(userForModificationDto.id);

            UserMapper.MapToUser(userForModificationDto, user);

            var modifyUser = await userRepository.UpdateAsync(user);
            await userRepository.SaveChangesAsync();

            return UserMapper.MapToUserDto(modifyUser);
        }

        public async ValueTask<UserDto> RemoveUserAsync(Guid userId)
        {
            var user = await this.userRepository.SelectByIdAsync(userId);

            var deletedUser = await this.userRepository.DeleteAsync(user);

            await userRepository.SaveChangesAsync();

            return UserMapper.MapToUserDto(deletedUser);
        }

        public async ValueTask<UserDto> RetrieveUserByIdAsync(Guid userId)
        {
            var user = await this.userRepository.SelectByIdAsync(userId);
            return UserMapper.MapToUserDto(user);
        }

        public async ValueTask<IQueryable<UserDto>> RetrieveUsers(QueryParam queryParam)
        {
            var users = this.userRepository.SelectAll();

            var pagedUser = users.PagedList(
                httpContextAccesssor.HttpContext, queryParam);

            return pagedUser.Select(u => UserMapper.MapToUserDto(u));
        }
    }
}
