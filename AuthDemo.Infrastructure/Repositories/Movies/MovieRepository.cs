using AuthDemo.Infrastructure.Context;
using Library.Models.Domain;

namespace AuthDemo.Infrastructure.Repositories.Movies;
public sealed class MovieRepository : GenericRepository<Movie, Guid>, IMovieRepository
{
    public MovieRepository(AuthDbContext authDbContext) 
        : base(authDbContext)
    {
    }
}
