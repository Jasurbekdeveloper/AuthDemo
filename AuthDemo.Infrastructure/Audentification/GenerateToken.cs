using Library.Models.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthDemo.Infrastructure.Audentification;

public  class GenerateToken
{
    private readonly JwtOptions jwtOptions;

    public GenerateToken(IOptions<JwtOptions> jwtOptions)
    {
        this.jwtOptions = jwtOptions.Value;
    }

    public JwtSecurityToken GenerateAccess(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimNames.Id, user.Id.ToString()),
            new Claim(ClaimNames.userName, user.Username),
            new Claim(ClaimNames.Email, user.EmailAddres),
            new Claim(ClaimNames.Role, user.Role.ToString())
        };

        SymmetricSecurityKey simmetricSecurutyKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtOptions.SecretKey));

        var accessToken = new JwtSecurityToken(
            issuer : jwtOptions.Issuer,
            audience : jwtOptions.Audience,
            claims : claims,
            expires : DateTime.Now.AddMinutes(jwtOptions.ExpirationInMinutes),
            signingCredentials : new SigningCredentials(
                key: simmetricSecurutyKey,
                algorithm: SecurityAlgorithms.HmacSha256));

        return accessToken;
    }

    public string GenerateRefreshToken()
    {
        byte[] bytes = new byte[64];

        var randomGenerator = RandomNumberGenerator.Create();

        randomGenerator.GetBytes(bytes);

        return Convert.ToBase64String(bytes);
    }
}
