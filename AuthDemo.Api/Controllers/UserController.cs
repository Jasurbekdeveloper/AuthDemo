using AuthDemo.Api.Services;
using AuthDemo.Aplication.DTO;
using AuthDemo.Aplication.PagenationModel;
using Microsoft.AspNetCore.Mvc;


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
        [HttpGet]
        public IActionResult GetAllUsers(
             [FromQuery] QueryParam queryParameter)
        {
            var users = this.userService.RetrieveUsers(queryParameter);

            return Ok(users);

        }
        [HttpGet("Id : Guid")]
        public async ValueTask<ActionResult<UserDto>> GetUserById(Guid Id)
        {
            var user = await this.userService
                .RetrieveUserByIdAsync(Id);
            return Ok(user);
        }
        [HttpPost]
        public async ValueTask<ActionResult<UserDto>> AddUser(UserCreationDto user)
        {
            var createdUser = this.userService.CreateUserAsync(user);

            return Created("", createdUser);
        }
        [HttpPut]
        public async ValueTask<ActionResult<UserDto>> PutUserAsync(UserModificationDto user)
        {
            var updateUser = this.userService.ModifyUserAsync(user);
            return Ok(updateUser);
        }
        [HttpDelete("userId: Guid")]
        public async ValueTask<ActionResult<UserDto>> DeleteUser(Guid userId)
        {
            var deletedUser = await this.userService
                .RemoveUserAsync(userId);

            return Ok(deletedUser);
        }
    }
}
