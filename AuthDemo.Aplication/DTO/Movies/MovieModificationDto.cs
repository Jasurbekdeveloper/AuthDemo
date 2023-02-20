namespace AuthDemo.Aplication.DTO;

public record MovieModificationDto(
    Guid id,
    string? title,
    string? description,
    double? rating);