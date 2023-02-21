using AuthDemo.Api.Services;
using AuthDemo.Aplication.DTO;
using AuthDemo.Aplication.PagenationModel;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.Api.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAllMovies(
             [FromQuery] QueryParam queryParameter)
        {
            var movies = this._movieService.RetrieveMovies(queryParameter);

            return Ok(movies);

        }
        [HttpGet("getById : Guid")]
        public async ValueTask<ActionResult<MovieDto>> GetMovieById(Guid Id)
        {
            var movie = await this._movieService
                .RetrieveMovieByIdAsync(Id);
            return Ok(movie);
        }
        [HttpPost("add")]
        public async ValueTask<ActionResult<MovieDto>> AddMovie(MovieCreationDto movie)
        {
            var createdMovie = this._movieService.CreateMovieAsync(movie);

            return Created("", createdMovie);
        }
        [HttpPut("update")]
        public async ValueTask<ActionResult<MovieDto>> PutMovieAsync(MovieModificationDto movie)
        {
            var updateMovie = this._movieService.ModifyMovieAsync(movie);
            return Ok(updateMovie);
        }
        [HttpDelete("delete : Guid")]
        public async ValueTask<ActionResult<MovieDto>> DeleteMovie(Guid movieId)
        {
            var deletedMovie = await this._movieService
                .RemoveMovieAsync(movieId);

            return Ok(deletedMovie);
        }
    }
}
