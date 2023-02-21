using AuthDemo.Aplication.DTO;
using AuthDemo.Aplication.PagenationModel;

namespace AuthDemo.Api.Services
{
    public interface IMovieService
    {
        ValueTask<MovieDto> CreateMovieAsync(MovieCreationDto movieCreationDto);
        ValueTask<IQueryable<MovieDto>> RetrieveMovies(QueryParam queryParam);
        ValueTask<MovieDto> RetrieveMovieByIdAsync(Guid movieId);
        ValueTask<MovieDto> ModifyMovieAsync(MovieModificationDto movieModificationDto);
        ValueTask<MovieDto> RemoveMovieAsync(Guid movieId);
    }
}
