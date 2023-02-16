namespace AuthDemo.Aplication.DTO;

public record UserDto(
    Guid id,
    string userName,
    string email,
    string role);
