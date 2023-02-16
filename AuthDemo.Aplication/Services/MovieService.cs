using AuthDemo.Aplication.DTO;
using Library.Models.Domain;

namespace AuthDemo.Api.Services
{
    public class MovieService : IMovieService
    {
        public ValueTask<MovieDto> CreateMovieAsync(MovieCreationDto movieCreationDto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<MovieDto> ModifyMovieAsync(MovieModificationDto movieModificationDto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<MovieDto> RemoveMovieAsync(Guid movieId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<MovieDto> RetrieveMovieByIdAsync(Guid movieId)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IQueryable<MovieDto>> RetrieveMovies()
        {
            throw new NotImplementedException();
        }
    }
}
