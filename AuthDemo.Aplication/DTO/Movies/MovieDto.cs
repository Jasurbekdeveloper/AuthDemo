namespace AuthDemo.Aplication.DTO;
public record MovieDto(
    Guid id,
    string title,
    string description,
    double rating);
