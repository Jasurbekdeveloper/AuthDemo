using AuthDemo.Api.Services;
using AuthDemo.Aplication.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthDemo.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet("getAll")]
        public IActionResult GetUsers()
        {
            var users = this.userService.RetrieveUsers();

            return Ok(users);

        }
        [HttpGet("getById : Guid")]
        public async ValueTask<ActionResult<UserDto>> GetUserById(Guid Id)
        {
            var user = await this.userService
                .RetrieveUserByIdAsync(Id);
            return Ok(user);
        }
        [HttpPost("add")]
        public async ValueTask<ActionResult<UserDto>> AddUser(UserCreationDto user)
        {
            var createdUser = this.userService.CreateUserAsync(user);

            return Created("", createdUser);
        }
        [HttpPut("update")]
        public async ValueTask<ActionResult<UserDto>> PutUserAsync(UserModificationDto user)
        {
            var updateUser = this.userService.ModifyUserAsync(user);
            return Ok(updateUser);
        }
        [HttpDelete("delete : Guid")]
        public async ValueTask<ActionResult<UserDto>> DeleteUser(Guid userId)
        {
            var deletedUser = await this.userService
                .RemoveUserAsync(userId);

            return Ok(deletedUser);
        }
    }
}
