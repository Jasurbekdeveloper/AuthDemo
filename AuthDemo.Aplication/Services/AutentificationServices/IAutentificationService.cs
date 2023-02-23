using AuthDemo.Aplication.DTO.AutentificationDTO;
using Azure.Core;

namespace AuthDemo.Aplication.Services.AutentificationServices;

public interface IAutentificationService
{
    ValueTask<AccessToken> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
    ValueTask<AccessToken> LoginAsync(RefreshTokenDto refreshTokenDto);
}
