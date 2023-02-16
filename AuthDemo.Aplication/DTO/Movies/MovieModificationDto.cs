namespace AuthDemo.Aplication.DTO;

public record MovieModificationDto(
    string? title,
    string? description,
    double? rating);