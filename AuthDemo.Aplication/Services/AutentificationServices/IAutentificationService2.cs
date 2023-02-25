using AuthDemo.Aplication.DTO.AutentificationDTO;
using Azure.Core;

namespace AuthDemo.Aplication.Services;

public interface IAutentificationService2
{
    ValueTask<AccessTokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
    ValueTask<AccessTokenDto> LoginAsync(LoginDto LogInDto);
}
