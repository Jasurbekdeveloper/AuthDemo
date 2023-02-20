using AuthDemo.Domain.Enums;

namespace AuthDemo.Aplication.DTO;

public record UserModificationDto(
    Guid id,
    string? userName,
    string? email,
    UserRole? role);