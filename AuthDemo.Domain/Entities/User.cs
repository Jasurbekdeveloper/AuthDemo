using AuthDemo.Domain.Entities;
using AuthDemo.Domain.Enums;
    
namespace Library.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string EmailAddres { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public string Salt { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpiredRefreshToken { get; set; }
        public ICollection<UserMovie>? UserMovies { get; set; }

    }
}
