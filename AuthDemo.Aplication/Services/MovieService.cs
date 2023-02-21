using AuthDemo.Aplication.DTO;
using AuthDemo.Aplication.Mapper;
using AuthDemo.Aplication.PagenationModel;
using AuthDemo.Aplication.QueryExtentions;
using AuthDemo.Infrastructure.Repositories.Movies;
using Microsoft.AspNetCore.Http;

namespace AuthDemo.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IHttpContextAccessor httpContextAccesssor;


        public MovieService(IMovieRepository movieRepository,
            IHttpContextAccessor httpContextAccesssor)
        {
            this.movieRepository = movieRepository;
            this.httpContextAccesssor = httpContextAccesssor;
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

        public async ValueTask<IQueryable<MovieDto>> RetrieveMovies(QueryParam queryParam)
        {

            var movies = this.movieRepository.SelectAll();

            var pagedMovie = movies.PagedList(
                httpContext: httpContextAccesssor.HttpContext,
                queryParameter: queryParam);

            return pagedMovie.Select(u => MovieMapper.MapToMovieDto(u));
        }
    }
}
