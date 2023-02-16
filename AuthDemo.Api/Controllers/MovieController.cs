using AuthDemo.Api.Services;
using Library.Models.Domain;
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
        public async Task<IActionResult> GetMovies()
        {
            try
            {
                return Ok(_movieService.GetList());
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet("getById")]
        public async Task<IActionResult> GetMovie(int Id)
        {
            try
            {
                return Ok(_movieService.MovieGet(Id));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong!");
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddMovie(User movie)
        {
            try
            {
                return Ok(_movieService.Create(movie));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateMovie(User movie)
        {
            try
            {
                return Ok( _movieService.Update(movie));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteMovie(int userId)
        {
            try
            {
                _movieService.Delete(userId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
