using AuthDemo.Aplication.DTO.AutentificationDTO;
using AuthDemo.Domain.Exceptions;
using AuthDemo.Infrastructure.Audentification;
using AuthDemo.Infrastructure.Repositories.Users;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthDemo.Aplication.Services;

public partial class AuthenticationService2 : IAutentificationService2
{
    private readonly IUserRepository userRepository;
    private readonly GenerateToken generateToken;
    private readonly PasswordHasher passwordHasher;
    private readonly JwtOptions jwtOptions;

    public AuthenticationService2(
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

    public async ValueTask<AccessTokenDto> LoginAsync(
        LoginDto LogInDto)
    {
        var users = await this.userRepository.GetByExpression(
            expression: user => user.EmailAddres == LogInDto.email,
            includes: new string[] { });
        var storageUser = users.FirstOrDefault();

        ValidateStorageUser(storageUser);

        ValidateStoragePassword(storageUser, LogInDto);

        var createdRefreshToken = generateToken
            .GenerateRefreshToken();

        storageUser.RefreshToken = createdRefreshToken;

        storageUser.ExpiredRefreshToken = DateTime.Now.AddDays(5);

        var updateUser = await this.userRepository
            .UpdateAsync(storageUser);

        await this.userRepository.SaveChangesAsync();

        var createdAccessToken = generateToken
            .GenerateAccessToken(updateUser);

        return new AccessTokenDto(
            accessToken: new JwtSecurityTokenHandler().WriteToken(createdAccessToken),
            refreshToken: createdRefreshToken,
            expireDate: createdAccessToken.ValidTo);
    }

    public async ValueTask<AccessTokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
    {
        var claimsPrincipls = GetPrincipalFromExpiredToken(refreshTokenDto.accessToken);
        string userId = claimsPrincipls.FindFirst(ClaimNames.Id).Value;

        var users = await this.userRepository
            .GetByExpression(expression:
            user => user.Id == Guid.Parse(userId),
            includes: new string[] { });

        var storageUser = await users.FirstOrDefaultAsync();

        ValidateUser(storageUser);

        ValidateRefreshToken(
            refreshTokenDto: refreshTokenDto,
            user: storageUser);

        ValidateRefreshTokenExpiredDate(
            user: storageUser);

        var accessToken = this.generateToken.
            GenerateAccessToken(storageUser);

        return new AccessTokenDto(
            accessToken: new JwtSecurityTokenHandler().WriteToken(accessToken),
            refreshToken: storageUser.RefreshToken,
            expireDate: accessToken.ValidTo);


    }

    private ClaimsPrincipal GetPrincipalFromExpiredToken(
        string accessToken)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = this.jwtOptions.Audience,
            ValidateIssuer = true,
            ValidIssuer = this.jwtOptions.Issuer,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this.jwtOptions.SecretKey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var principal = tokenHandler.ValidateToken(
            token: accessToken,
            validationParameters: tokenValidationParameters,
            validatedToken: out SecurityToken securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;

        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(
            SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new ValidationException("Invalid token");
        }

        return principal;
    }
}
