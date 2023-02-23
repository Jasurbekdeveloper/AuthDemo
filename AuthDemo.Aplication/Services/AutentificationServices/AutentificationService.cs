using AuthDemo.Aplication.DTO.AutentificationDTO;
using Azure.Core;

namespace AuthDemo.Aplication.Services.AutentificationServices;

public class AutentificationService : IAutentificationService
{

    public ValueTask<AccessToken> LoginAsync(RefreshTokenDto refreshTokenDto)
    {
        throw new NotImplementedException();
    }

    public ValueTask<AccessToken> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
    {
        throw new NotImplementedException();
    }
}
