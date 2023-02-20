using AuthDemo.Aplication.DTO;

namespace AuthDemo.Api.Services
{
    public interface IMovieService
    {
        ValueTask<MovieDto> CreateMovieAsync(MovieCreationDto movieCreationDto);
        ValueTask<IQueryable<MovieDto>> RetrieveMovies();
        ValueTask<MovieDto> RetrieveMovieByIdAsync(Guid movieId);
        ValueTask<MovieDto> ModifyMovieAsync(MovieModificationDto movieModificationDto);
        ValueTask<MovieDto> RemoveMovieAsync(Guid movieId);
    }
}
