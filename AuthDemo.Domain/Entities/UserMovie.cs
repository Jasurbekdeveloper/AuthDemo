using Library.Models.Domain;

namespace AuthDemo.Domain.Entities;

public class UserMovie
{
    public Guid UserId { get; set; }
    public Guid MovieId { get; set; }
    public User User { get; set; }
    public Movie Movie { get; set; }
}
