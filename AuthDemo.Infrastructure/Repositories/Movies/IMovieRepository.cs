using Library.Models.Domain;

namespace AuthDemo.Infrastructure.Repositories.Movies;

public interface IMovieRepository : IGenericRepository<User, Guid>
{
}
