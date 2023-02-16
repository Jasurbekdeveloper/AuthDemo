using AuthDemo.Infrastructure.Context;
using Library.Models.Domain;

namespace AuthDemo.Infrastructure.Repositories.Users
{
    public sealed class UserRepository : GenericRepository<User, Guid>, IUserRepository
    {
        public UserRepository(AuthDbContext authDbContext) : base(authDbContext)
        {
        }
    }
}
