using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Aplication.DTO.AutentificationDTO;

public record RefreshTokenDto(
    [Required(ErrorMessage =$"{ nameof(RefreshTokenDto.accessToken)}  berilishi majburiy")]
    string accessToken,

    [Required(ErrorMessage =$"{ nameof(RefreshTokenDto.refreshToken)}  berilishi majburiy")]
    string refreshToken);
