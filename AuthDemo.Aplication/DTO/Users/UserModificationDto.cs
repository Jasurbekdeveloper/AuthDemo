namespace AuthDemo.Aplication.DTO;

public record UserModificationDto(
    string? userName,
    string? email,
    string? role);