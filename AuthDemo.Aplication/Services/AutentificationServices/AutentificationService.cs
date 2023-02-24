using AuthDemo.Aplication.DTO.AutentificationDTO;
using AuthDemo.Infrastructure.Audentification;
using AuthDemo.Infrastructure.Repositories.Users;
using Azure.Core;
using Microsoft.Extensions.Options;

namespace AuthDemo.Aplication.Services.AutentificationServices;

public class AutentificationService : IAutentificationService
{
    private readonly IUserRepository userRepository;
    private readonly GenerateToken generateToken;
    private readonly PasswordHasher passwordHasher;
    private readonly JwtOptions jwtOptions;

    public AutentificationService(
        IUserRepository userRepository, 
        GenerateToken generateToken,
        PasswordHasher passwordHasher,
        IOptions<JwtOptions> options)
    {
        this.userRepository = userRepository;
        this.generateToken = generateToken;
        this.passwordHasher = passwordHasher;
        this.jwtOptions = options.Value;
    }

    public ValueTask<AccessToken> LoginAsync(
        RefreshTokenDto refreshTokenDto)
    {
        
    }

    public ValueTask<AccessToken> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
    {
        throw new NotImplementedException();
    }
}
