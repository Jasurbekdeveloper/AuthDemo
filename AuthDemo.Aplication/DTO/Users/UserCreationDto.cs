namespace AuthDemo.Aplication.DTO;

public record UserCreationDto(
    string userName,
    string password,
    string email,
    string? role);