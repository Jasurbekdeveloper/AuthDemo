using AuthDemo.Aplication.DTO;
using AuthDemo.Aplication.Mapper;
using AuthDemo.Infrastructure.Repositories.Movies;

namespace AuthDemo.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async ValueTask<MovieDto> CreateMovieAsync(MovieCreationDto movieCreationDto)
        {
            var movie = MovieMapper.MapToMovie(movieCreationDto);

            var storedMovie = await this.movieRepository.InsertAsync(movie);

            await this.movieRepository.SaveChangesAsync();

            return MovieMapper.MapToMovieDto(storedMovie);
        }

        public async ValueTask<MovieDto> ModifyMovieAsync(
            MovieModificationDto movieModificationDto)
        {
            var movie = await this.movieRepository
                .SelectByIdAsync(movieModificationDto.id);

            MovieMapper.MapToMovie(movie, movieModificationDto);
            await this.movieRepository.SaveChangesAsync();

            var updateMovie = await this.movieRepository
                .UpdateAsync(movie);

            return MovieMapper.MapToMovieDto(updateMovie);
        }

        public async ValueTask<MovieDto> RemoveMovieAsync(Guid movieId)
        {
            var movie = await this.movieRepository
                .SelectByIdAsync(movieId);

            var removedMovie = await this.movieRepository
                .DeleteAsync(movie);

            await this.movieRepository.SaveChangesAsync();

            return MovieMapper.MapToMovieDto(removedMovie);

        }

        public async ValueTask<MovieDto> RetrieveMovieByIdAsync(Guid movieId)
        {
            var movie = await this.movieRepository
                .SelectByIdAsync(movieId);

            return MovieMapper.MapToMovieDto(movie);
        }

        public async ValueTask<IQueryable<MovieDto>> RetrieveMovies()
        {
            var movies = this.movieRepository.SelectAll();

            return movies.Select(u => MovieMapper.MapToMovieDto(u));
        }
    }
}
