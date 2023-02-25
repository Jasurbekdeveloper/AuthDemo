using AuthDemo.Aplication.DTO.AutentificationDTO;
using AuthDemo.Aplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : Controller
{
    private readonly IAutentificationService2 _service;

    public AuthController(IAutentificationService2 service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async ValueTask<IActionResult> LoginAsync(LoginDto loginDto)
    {
        var authenticationDto = this._service
            .LoginAsync(loginDto);

        return Ok(authenticationDto);
    }

    [HttpPost("refreshToken")]
    public async ValueTask<IActionResult> RefreshTokenAsync(
        RefreshTokenDto refreshTokenDto)
    {
        var token = this._service
            .RefreshTokenAsync(refreshTokenDto);

        return Ok(token);
    }
}
