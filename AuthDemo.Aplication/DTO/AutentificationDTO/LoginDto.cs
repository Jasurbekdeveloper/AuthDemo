using System.ComponentModel.DataAnnotations;

namespace AuthDemo.Aplication.DTO.AutentificationDTO;

    public record LoginDto(
    [Required(ErrorMessage =$"{ nameof(LoginDto.email)}  berilishi majburiy")]
    string email,

    [Required(ErrorMessage =$"password  berilishi majburiy")]
    string password);
