namespace AuthDemo.Aplication.DTO.AutentificationDTO;

public record AccessTokenDto(
    string accessToken,
    string? refreshToken,
    DateTime expireDate);
