using Library.Models.Domain;

namespace AuthDemo.Infrastructure.Repositories.Users;

public interface IUserRepository : IGenericRepository<User, Guid>
{
}
